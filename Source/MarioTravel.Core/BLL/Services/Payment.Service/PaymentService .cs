using Dapper;
using EnsureThat;
using MarioTravel.Core.BLL.Models.Payment;
using MarioTravel.Core.Configuration.Application;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MarioTravel.Core.BLL.Services.Payment.Service
{
    public class PaymentService
    {
        private readonly ConnectionFactory connectionFactory;
        private readonly ApplicationOptions applicationOptions;
        private readonly PaymentOptions paymentOptions;
        private const string SIGNATURE_KEY = "signature";

        public PaymentService(
            ConnectionFactory connectionFactory,
            IOptions<ApplicationOptions> applicationOptionsAccessor,
            IOptions<PaymentOptions> paymentOptsAccessor)
        {
            this.connectionFactory = connectionFactory;
            EnsureArg.IsNotNull(applicationOptionsAccessor, nameof(applicationOptionsAccessor));
            applicationOptions = EnsureArg.IsNotNull(applicationOptionsAccessor.Value, nameof(applicationOptionsAccessor.Value));
            EnsureArg.IsNotNull(paymentOptsAccessor, nameof(paymentOptsAccessor));
            EnsureArg.IsNotNull(paymentOptsAccessor.Value.PrivateKey, nameof(paymentOptsAccessor.Value.PrivateKey));
            paymentOptions = paymentOptsAccessor.Value;
        }

        //---------------------------------------------------------------------------------------------------------------------
        //TOUR PAYMENT PROCESSING -----------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------------------
        public async Task ConfirmTourPaymentRequestReceived(PaymentReceived paymentReceived)
        {
            // Check if duplicate request - indicates manual meddling with our API
            using var connection = await connectionFactory.CreateOpenAsync();
            var bookingValidForUpdate = await ValidateTourBookingForUpdateAsync(connection, paymentReceived.ExternalId);

            if (bookingValidForUpdate)
            {
                var sqlParams = new { paymentReceived.RawPaymentResponse, paymentReceived.ExternalId, Application = applicationOptions.ApplicationId };

                await connection.ExecuteAsync(
                    @"UPDATE
                            tour_booking
                        SET
                            raw_payment_response = @RawPaymentResponse
                        WHERE
                            external_id = @ExternalId
                        AND application_id = @Application;",
                    sqlParams);
            }
        }

        private static async Task<bool> ValidateTourBookingForUpdateAsync(DbConnection connection, Guid externalId)
        {
            // check if booking exists and doesn't have the payment received already set
            // if any of that is the case, someone is meddling with our API
            return (await connection.QueryAsync<int>(
                       @"SELECT
                            COUNT(Id)
                        FROM
                            tour_booking
                        WHERE
                            external_id = @ExternalId
                            AND raw_payment_response IS NULL;",
                       new { externalId }))
                   .First() == 1;
        }

        public async Task<bool> ProcessTourPaymentResponse(PaymentResponse paymentResponse)
        {
            var isValid = IsPaymentValid(paymentResponse.Raw);

            const string ADD_PAYMENT_COMMAND = @"INSERT INTO payment(
                    external_payment_id,
                    booking_external_id,
                    type,
                    status,
                    receipt_url,
                    amount,
                    currency,
                    approval_code,
                    processing_code,
                    card_brand,
                    card_masked_pan,
                    card_cardholder_name,
                    card_fingerprint,
                    external_created_at,
                    signature_order,
                    signature,
                    is_valid,
                    created_at,
                    application_id)
                VALUES (
                    @ExternalPaymentId,
                    @BookingExternalId,
                    @Type,
                    @Status,
                    @ReceiptUrl,
                    @Amount,
                    @Currency,
                    @ApprovalCode,
                    @ProcessingCode,
                    @CardBrand,
                    @CardMaskedPan,
                    @CardCardholderName,
                    @CardFingerprint,
                    @ExternalCreatedAt,
                    @SignatureOrder,
                    @Signature,
                    @IsValid,
                    @CreatedAt,
                    @Application);";

            var addPaymentCommandParams = new
            {
                paymentResponse.ExternalPaymentId,
                paymentResponse.BookingExternalId,
                paymentResponse.Type,
                paymentResponse.Status,
                paymentResponse.ReceiptUrl,
                paymentResponse.Amount,
                paymentResponse.Currency,
                paymentResponse.ApprovalCode,
                paymentResponse.ProcessingCode,
                paymentResponse.CardBrand,
                paymentResponse.CardMaskedPan,
                paymentResponse.CardCardholderName,
                paymentResponse.CardFingerprint,
                paymentResponse.ExternalCreatedAt,
                paymentResponse.SignatureOrder,
                paymentResponse.Signature,
                IsValid = isValid,
                paymentResponse.CreatedAt,
                Application = applicationOptions.ApplicationId
            };

            const string UPDATE_TOUR_BOOKING_COMPLETED_NOTIFICATION =
                @"UPDATE
                    tour_booking
                SET
                    send_not_completed_notification = FALSE
                WHERE
                    external_id = @ExternalId
                AND application_id = @Application;";

            var updateTourBookingCompletedNotificationParams = new
            {
                ExternalId = paymentResponse.BookingExternalId,
                Application = applicationOptions.ApplicationId
            };

            using (var connection = await connectionFactory.CreateOpenAsync())
            {
                using var transaction = connection.BeginTransaction();
                try
                {
                    await connection.ExecuteAsync(ADD_PAYMENT_COMMAND, addPaymentCommandParams, transaction);
                    await connection.ExecuteAsync(UPDATE_TOUR_BOOKING_COMPLETED_NOTIFICATION, updateTourBookingCompletedNotificationParams, transaction);

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
            return isValid;
        }

        //END OF TOUR PAYMENT PROCESSING---------------------------------------------------------------------------------------

        //---------------------------------------------------------------------------------------------------------------------
        //TRENSFER PAYMENT PROCESSING -----------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------------------

        public async Task ConfirmTransferPaymentRequestReceived(PaymentReceived paymentReceived)
        {
            // Check if duplicate request - indicates manual meddling with our API
            using var connection = await connectionFactory.CreateOpenAsync();
            var bookingValidForUpdate = await ValidateTransferBookingForUpdateAsync(connection, paymentReceived.ExternalId);

            if (bookingValidForUpdate)
            {
                var sqlParams = new { paymentReceived.RawPaymentResponse, paymentReceived.ExternalId, Application = applicationOptions.ApplicationId };

                await connection.ExecuteAsync(
                    @"UPDATE
                            transfer_booking
                        SET
                            raw_payment_response = @RawPaymentResponse
                        WHERE
                            external_id = @ExternalId
                        AND application_id = @Application;",
                    sqlParams);
            }
        }

        private static async Task<bool> ValidateTransferBookingForUpdateAsync(DbConnection connection, Guid externalId)
        {
            // check if booking exists and doesn't have the payment received already set
            // if any of that is the case, someone is meddling with our API
            return (await connection.QueryAsync<int>(
                       @"SELECT
                            COUNT(Id)
                        FROM
                            transfer_booking
                        WHERE
                            external_id = @ExternalId
                            AND raw_payment_response IS NULL;",
                       new { externalId }))
                   .First() == 1;
        }

        public async Task<bool> ProcessTransferPaymentResponse(PaymentResponse paymentResponse)
        {
            var isValid = IsPaymentValid(paymentResponse.Raw);

            const string ADD_PAYMENT_COMMAND = @"INSERT INTO payment(
                    external_payment_id,
                    booking_external_id,
                    type,
                    status,
                    receipt_url,
                    amount,
                    currency,
                    approval_code,
                    processing_code,
                    card_brand,
                    card_masked_pan,
                    card_cardholder_name,
                    card_fingerprint,
                    external_created_at,
                    signature_order,
                    signature,
                    is_valid,
                    created_at,
                    application_id)
                VALUES (
                    @ExternalPaymentId,
                    @BookingExternalId,
                    @Type,
                    @Status,
                    @ReceiptUrl,
                    @Amount,
                    @Currency,
                    @ApprovalCode,
                    @ProcessingCode,
                    @CardBrand,
                    @CardMaskedPan,
                    @CardCardholderName,
                    @CardFingerprint,
                    @ExternalCreatedAt,
                    @SignatureOrder,
                    @Signature,
                    @IsValid,
                    @CreatedAt,
                    @Application);";

            var addPaymentCommandParams = new
            {
                paymentResponse.ExternalPaymentId,
                paymentResponse.BookingExternalId,
                paymentResponse.Type,
                paymentResponse.Status,
                paymentResponse.ReceiptUrl,
                paymentResponse.Amount,
                paymentResponse.Currency,
                paymentResponse.ApprovalCode,
                paymentResponse.ProcessingCode,
                paymentResponse.CardBrand,
                paymentResponse.CardMaskedPan,
                paymentResponse.CardCardholderName,
                paymentResponse.CardFingerprint,
                paymentResponse.ExternalCreatedAt,
                paymentResponse.SignatureOrder,
                paymentResponse.Signature,
                IsValid = isValid,
                paymentResponse.CreatedAt,
                Application = applicationOptions.ApplicationId
            };

            const string UPDATE_TRANSFER_BOOKING_COMPLETED_NOTIFICATION =
              @"UPDATE
                        transfer_booking
                    SET
                        send_not_completed_notification = FALSE
                    WHERE
                        external_id = @ExternalId
                    AND application_id = @Application;";

            var updateTransferBookingCompletedNotificationParams = new
            {
                ExternalId = paymentResponse.BookingExternalId,
                Application = applicationOptions.ApplicationId
            };

            using (var connection = await connectionFactory.CreateOpenAsync())
            {
                using var transaction = connection.BeginTransaction();
                try
                {
                    await connection.ExecuteAsync(ADD_PAYMENT_COMMAND, addPaymentCommandParams, transaction);
                    await connection.ExecuteAsync(UPDATE_TRANSFER_BOOKING_COMPLETED_NOTIFICATION, updateTransferBookingCompletedNotificationParams, transaction);
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
            return isValid;
        }

        ///// <summary>
        ///// Concatenate all field values in order specified by signature_order, add the the secret at the end,
        ///// hash with SHA-512 and compare with the value of the signature field.
        ///// </summary>
        ///// <param name="raw"></param>
        ///// <returns></returns>
        private bool IsPaymentValid(RawPaymentData raw)
        {
            var data = new Dictionary<string, string>
            {
                {"payment_id", raw.PaymentId},
                {"external_id", raw.ExternalId},
                {"type", raw.Type},
                {"status", raw.Status},
                {"receipt_url", raw.ReceiptUrl},
                {"amount", raw.Amount},
                {"currency", raw.Currency},
                {"approval_code", raw.ApprovalCode},
                {"processing_code", raw.ProcessingCode},
                {"card_brand", raw.CardBrand},
                {"card_masked_pan", raw.CardMaskedPan},
                {"card_cardholder_name", raw.CardCardholderName},
                {"card_fingerprint", raw.CardFingerprint},
                {"created_at", raw.CreatedAt},
                {"signature_order", raw.SignatureOrder},
                {"signature", raw.Signature}
            };

            if (!data.ContainsKey(SIGNATURE_KEY))
            {
                return false;
            }

            var propSignatureOrder = data["signature_order"].Split(',').Where(k => k != "secret");

            var sb = new StringBuilder();
            foreach (var propName in propSignatureOrder)
            {
                sb.Append(data[propName]);
            }

            sb.Append(paymentOptions.PrivateKey);

            string calculatedSignature;
            using (var sha = SHA512.Create())
            {
                var hashedBytes = sha.ComputeHash(Encoding.UTF8.GetBytes(sb.ToString()));
                calculatedSignature = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }

            var signature = data[SIGNATURE_KEY];
            return signature == calculatedSignature;
        }

        public async Task<bool> NotDuplicateAsync(Guid bookingExternalId)
        {
            var sql =
                @"SELECT
                    COUNT(id)
                FROM
                    payment
                WHERE
                    booking_external_id = @BookingExternalId
                AND application_id = @Application;";

            var sqlParams = new { BookingExternalId = bookingExternalId, Application = applicationOptions.ApplicationId };

            using var connection = await connectionFactory.CreateOpenAsync();
            return (await connection.QueryAsync<int>(sql, sqlParams)).First() == 0;
        }

        //END OF TRANSFER PAYMENT PROCESSING---------------------------------------------------------------------------------------
    }
}