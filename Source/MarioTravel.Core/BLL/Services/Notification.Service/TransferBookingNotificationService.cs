using Dapper;
using EnsureThat;
using MarioTravel.Core.BLL.Models.Email.DepositPayment;
using MarioTravel.Core.BLL.Models.Email.FullPayment;
using MarioTravel.Core.BLL.Models.Notification.Transfer;
using MarioTravel.Core.BLL.Services.Email.Service;
using MarioTravel.Core.BLL.Services.EmailTemplate.Service;
using MarioTravel.Core.BLL.Services.EmailTemplate.Service.TemplateRegister;
using MarioTravel.Core.BLL.Services.EmailTemplate.Service.TemplateResources;
using MarioTravel.Core.Configuration.Application;
using MarioTravel.Core.Configuration.Emails;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MarioTravel.Core.BLL.Services.Notification.Service
{
    public class TransferBookingNotificationService
    {
        private readonly ConnectionFactory connectionFactory;
        private readonly ApplicationOptions applicationOptions;
        private readonly EmailAddress emailAddress;
        private readonly EmailSender emailSender;
        private readonly TemplateEngine templateEngine;
        private readonly IStringLocalizer<EmailBodyResources> localizer;

        public TransferBookingNotificationService(
            ConnectionFactory connectionFactory,
            IOptions<ApplicationOptions> applicationOptionsAccessor,
            IOptions<EmailAddress> emailAddressAccessor,
            EmailSender emailSender,
            TemplateEngine templateEngine,
            IStringLocalizer<EmailBodyResources> localizer)
        {
            this.connectionFactory = EnsureArg.IsNotNull(connectionFactory, nameof(connectionFactory));
            EnsureArg.IsNotNull(applicationOptionsAccessor, nameof(applicationOptionsAccessor));
            applicationOptions = EnsureArg.IsNotNull(applicationOptionsAccessor.Value, nameof(applicationOptionsAccessor.Value));
            this.emailSender = EnsureArg.IsNotNull(emailSender, nameof(emailSender));
            EnsureArg.IsNotNull(emailAddressAccessor, nameof(emailAddressAccessor));
            emailAddress = EnsureArg.IsNotNull(emailAddressAccessor.Value);
            this.templateEngine = EnsureArg.IsNotNull(templateEngine, nameof(templateEngine));
            this.localizer = EnsureArg.IsNotNull(localizer, nameof(localizer));
        }

        public async Task<FinishedTransferBookingNotification> GetTransferBookingNotificationAsync(Guid externalId)
        {
            const string GET_COMPLETED_TRANSFER_BOOKINGS = @"SELECT
                    t.title AS transfer_name,
                    b.external_id,
                    b.time_of_day AS time,
                    b.date,
                    b.from_location,
                    b.to_location,
                    b.transfer_distance,
                    b.transfer_duration,
                    b.number_of_persons,
                    b.full_name,
                    b.phone,
                    b.email,
                    b.additional_info,
                    b.total_price as price,
                    b.deposit_price,
                    b.to_be_charged,
                    b.application_id,
                    p.status
                FROM
                    transfer_booking b
                    INNER JOIN transfer t ON b.transfer_id = t.id
                    INNER JOIN payment p ON b.external_id = p.booking_external_id
                WHERE
                    b.external_id = @ExternalId
                AND b.application_id = @Application;";

            var sqlParams = new { ExternalId = externalId, Application = applicationOptions.ApplicationId };

            using var connection = await connectionFactory.CreateOpenAsync();
            var booking = (await connection.QueryAsync<FinishedTransferBookingNotification>(GET_COMPLETED_TRANSFER_BOOKINGS, sqlParams)).FirstOrDefault();

            return booking;
        }

        public async Task<NotFinishedTransferBookingNotification[]> GetNotFinishedTransferBookingsAsync(DateTime latestDateCreated)
        {
            const string GET_NOT_COMPLETED_TRANSFERS = @"SELECT
                    b.id,
                    t.title AS transfer_name,
                    b.external_id,
                    b.time_of_day AS time,
                    b.date,
                    b.from_location,
                    b.to_location,
                    b.transfer_distance,
                    b.transfer_duration,
                    b.number_of_persons,
                    b.full_name,
                    b.phone,
                    b.email,
                    b.additional_info,
                    b.total_price as price,
                    b.deposit_price,
                    b.to_be_charged,
                    b.application_id
                FROM
                    transfer_booking b
                    INNER JOIN transfer t ON b.transfer_id = t.id
                WHERE
                    b.send_not_completed_notification = TRUE
                AND created_at <= @LatestDateCreated
                AND b.application_id = @Application;";

            var queryParams = new { LatestDateCreated = latestDateCreated, Application = applicationOptions.ApplicationId };

            using var connection = await connectionFactory.CreateOpenAsync();
            var bookings = await connection.QueryAsync<NotFinishedTransferBookingNotification>(GET_NOT_COMPLETED_TRANSFERS, queryParams);

            return bookings.ToArray();
        }

        public async Task SendTransferBookingNotificationEmailAsync(Guid externalPaymentId)
        {
            var bookingNotification = await GetTransferBookingNotificationAsync(externalPaymentId);

            if (bookingNotification == null)
            {
                throw new InvalidOperationException("Trying to send email for booking with no payment associated.");
            }

            string subject;

            if (!bookingNotification.IsApproved && bookingNotification.DepositPrice > 0)
            {
                bookingNotification.Status = "DEPOSIT PAYMENT DECLINED";
                subject = $"{localizer["DEPOSIT TRANSFER BOOKING FAILED"]}";
                var depositTransferTemplateModel = new DepositTransferTemplateModel
                {
                    Date = localizer["DATE"],
                    Time = localizer["TIME"],
                    FromLocation = localizer["STARTING LOCATION"],
                    ToLocation = localizer["FINAL DESTINATION"],
                    TransferDistance = localizer["DISTANCE"],
                    TransferDuration = localizer["DURATION"],
                    Price = localizer["PRICE"],
                    DepositPrice = localizer["DEPOSIT"],
                    ToBeCharged = localizer["REQUIRED ON SITE"],
                    NumberOfPersons = localizer["NUMBER OF PERSONS"],
                    FullName = localizer["FULL NAME"],
                    Phone = $"{localizer["PHONE"]}",
                    Email = $"{localizer["EMAIL"]}",
                    AdditionalInfo = localizer["ADDITIONAL INFO"]
                };

                var depositTransferNotificationTemplateModel = new DepositTransferNotificationTemplateModel
                {
                    Transfer = bookingNotification.TransferName,
                    Status = bookingNotification.Status,
                    Date = bookingNotification.Date.ToString("dd-MM-yyyy"),
                    Time = bookingNotification.Time.ToString("hh\\:mm"),
                    FromLocation = bookingNotification.FromLocation,
                    ToLocation = bookingNotification.ToLocation,
                    TransferDistance = bookingNotification.TransferDistance + " km",
                    TransferDuration = bookingNotification.TransferDuration,
                    Price = bookingNotification.Price.ToString("N2"),
                    DepositPrice = bookingNotification.DepositPrice.ToString("N2"),
                    ToBeCharged = bookingNotification.ToBeCharged.ToString("N2"),
                    NumberOfPersons = bookingNotification.NumberOfPersons,
                    FullName = bookingNotification.FullName,
                    Phone = bookingNotification.Phone,
                    Email = bookingNotification.Email,
                    AdditionalInfo = bookingNotification.AdditionalInfo
                };

                var mailBody = templateEngine.Render(TransferTemplates.Email.DepositTransferPaymentDeclined.Name,
                    ("notification", depositTransferNotificationTemplateModel),
                    ("fieldName", depositTransferTemplateModel));

                await emailSender.SendEmailAsync(emailAddress.BookingFrom, emailAddress.BookingTo, subject, mailBody);
                await emailSender.SendEmailAsync(emailAddress.BookingFrom, bookingNotification.Email, subject, mailBody);
            }

            if (!bookingNotification.IsApproved && bookingNotification.DepositPrice == 0)
            {
                bookingNotification.Status = "FULL PAYMENT DECLINED";
                subject = $"{localizer["FULL TRANSFER BOOKING FAILED"]}";
                var fullTransferTemplateModel = new FullTransferTemplateModel
                {
                    Date = localizer["DATE"],
                    Time = localizer["TIME"],
                    FromLocation = localizer["STARTING LOCATION"],
                    ToLocation = localizer["FINAL DESTINATION"],
                    TransferDistance = localizer["DISTANCE"],
                    TransferDuration = localizer["DURATION"],
                    Price = localizer["PRICE"],
                    NumberOfPersons = localizer["NUMBER OF PERSONS"],
                    FullName = localizer["FULL NAME"],
                    Phone = $"{localizer["PHONE"]}",
                    Email = $"{localizer["EMAIL"]}",
                    AdditionalInfo = localizer["ADDITIONAL INFO"]
                };

                var fullTransferBookingNotificationTemplateModel = new FullTransferNotificationTemplateModel
                {
                    Transfer = bookingNotification.TransferName,
                    Status = bookingNotification.Status,
                    Date = bookingNotification.Date.ToString("dd-MM-yyyy"),
                    Time = bookingNotification.Time.ToString("hh\\:mm"),
                    FromLocation = bookingNotification.FromLocation,
                    ToLocation = bookingNotification.ToLocation,
                    TransferDistance = bookingNotification.TransferDistance + " km",
                    TransferDuration = bookingNotification.TransferDuration,
                    Price = bookingNotification.Price.ToString("N2"),
                    NumberOfPersons = bookingNotification.NumberOfPersons,
                    FullName = bookingNotification.FullName,
                    Phone = bookingNotification.Phone,
                    Email = bookingNotification.Email,
                    AdditionalInfo = bookingNotification.AdditionalInfo
                };

                var mailBody = templateEngine.Render(TransferTemplates.Email.FullTransferPaymentDeclined.Name,
                    ("notification", fullTransferBookingNotificationTemplateModel),
                    ("fieldName", fullTransferTemplateModel));

                await emailSender.SendEmailAsync(emailAddress.BookingFrom, emailAddress.BookingTo, subject, mailBody);
                await emailSender.SendEmailAsync(emailAddress.BookingFrom, bookingNotification.Email, subject, mailBody);
            }

            if (bookingNotification.IsApproved && bookingNotification.DepositPrice > 0)
            {
                bookingNotification.Status = "DEPOSIT PAYMENT APPROVED";
                subject = $"{localizer["DEPOSIT TRANSFER BOOKING APPROVED"]}";
                var depositTransferTemplateModel = new DepositTransferTemplateModel
                {
                    Date = localizer["DATE"],
                    Time = localizer["TIME"],
                    FromLocation = localizer["STARTING LOCATION"],
                    ToLocation = localizer["FINAL DESTINATION"],
                    TransferDistance = localizer["DISTANCE"],
                    TransferDuration = localizer["DURATION"],
                    Price = localizer["PRICE"],
                    DepositPrice = localizer["DEPOSIT"],
                    ToBeCharged = localizer["REQUIRED ON SITE"],
                    NumberOfPersons = localizer["NUMBER OF PERSONS"],
                    FullName = localizer["FULL NAME"],
                    Phone = $"{localizer["PHONE"]}",
                    Email = $"{localizer["EMAIL"]}",
                    AdditionalInfo = localizer["ADDITIONAL INFO"]
                };

                var depositTransferBookingNotificationTemplateModel = new DepositTransferNotificationTemplateModel
                {
                    Transfer = bookingNotification.TransferName,
                    Status = bookingNotification.Status,
                    Date = bookingNotification.Date.ToString("dd-MM-yyyy"),
                    Time = bookingNotification.Time.ToString("hh\\:mm"),
                    FromLocation = bookingNotification.FromLocation,
                    ToLocation = bookingNotification.ToLocation,
                    TransferDistance = bookingNotification.TransferDistance + " km",
                    TransferDuration = bookingNotification.TransferDuration,
                    Price = bookingNotification.Price.ToString("N2"),
                    DepositPrice = bookingNotification.DepositPrice.ToString("N2"),
                    ToBeCharged = bookingNotification.ToBeCharged.ToString("N2"),
                    NumberOfPersons = bookingNotification.NumberOfPersons,
                    FullName = bookingNotification.FullName,
                    Phone = bookingNotification.Phone,
                    Email = bookingNotification.Email,
                    AdditionalInfo = bookingNotification.AdditionalInfo
                };

                var mailBody = templateEngine.Render(TransferTemplates.Email.DepositTransferPaymentApproved.Name,
                    ("notification", depositTransferBookingNotificationTemplateModel),
                    ("fieldName", depositTransferTemplateModel));

                await emailSender.SendEmailAsync(emailAddress.BookingFrom, emailAddress.BookingTo, subject, mailBody);
                await emailSender.SendEmailAsync(emailAddress.BookingFrom, bookingNotification.Email, subject, mailBody);
            }

            if (bookingNotification.IsApproved && bookingNotification.DepositPrice == 0)
            {
                bookingNotification.Status = "FULL PAYMENT APPROVED";
                subject = $"{localizer["FULL TRANSFER BOOKING APPROVED"]}";
                var fullTransferTemplateModel = new FullTransferTemplateModel
                {
                    Date = localizer["DATE"],
                    Time = localizer["TIME"],
                    FromLocation = localizer["STARTING LOCATION"],
                    ToLocation = localizer["FINAL DESTINATION"],
                    TransferDistance = localizer["DISTANCE"],
                    TransferDuration = localizer["DURATION"],
                    Price = localizer["PRICE"],
                    NumberOfPersons = localizer["NUMBER OF PERSONS"],
                    FullName = localizer["FULL NAME"],
                    Phone = $"{localizer["PHONE"]}",
                    Email = $"{localizer["EMAIL"]}",
                    AdditionalInfo = localizer["ADDITIONAL INFO"]
                };

                var fullTransferBookingNotificationTemplateModel = new FullTransferNotificationTemplateModel
                {
                    Transfer = bookingNotification.TransferName,
                    Status = bookingNotification.Status,
                    Date = bookingNotification.Date.ToString("dd-MM-yyyy"),
                    Time = bookingNotification.Time.ToString("hh\\:mm"),
                    FromLocation = bookingNotification.FromLocation,
                    ToLocation = bookingNotification.ToLocation,
                    TransferDistance = bookingNotification.TransferDistance + " km",
                    TransferDuration = bookingNotification.TransferDuration,
                    Price = bookingNotification.Price.ToString("N2"),
                    NumberOfPersons = bookingNotification.NumberOfPersons,
                    FullName = bookingNotification.FullName,
                    Phone = bookingNotification.Phone,
                    Email = bookingNotification.Email,
                    AdditionalInfo = bookingNotification.AdditionalInfo
                };

                var mailBody = templateEngine.Render(TransferTemplates.Email.FullTransferPaymentApproved.Name,
                    ("notification", fullTransferBookingNotificationTemplateModel),
                    ("fieldName", fullTransferTemplateModel));

                await emailSender.SendEmailAsync(emailAddress.BookingFrom, emailAddress.BookingTo, subject, mailBody);
                await emailSender.SendEmailAsync(emailAddress.BookingFrom, bookingNotification.Email, subject, mailBody);
            }
        }

        public async Task SendNotCompletedTranferBookingNotificationEmailAsync(TimeSpan notCompletedAge)
        {
            var latestDateCreated = DateTime.UtcNow - notCompletedAge;

            var notCompletedTransferBookingNotifications = await GetNotFinishedTransferBookingsAsync(latestDateCreated);

            if (!notCompletedTransferBookingNotifications.Any())
            {
                return;
            }

            string subject;

            foreach (var notification in notCompletedTransferBookingNotifications)
            {
                if (notification.DepositPrice > 0)
                {
                    subject = "NOTIFICATION:  NOT COMPLETED DEPOSIT TRANSFER BOOKING";
                    var depositTransferTemplateModel = new DepositTransferTemplateModel
                    {
                        Date = localizer["DATE"],
                        Time = localizer["TIME"],
                        FromLocation = localizer["STARTING LOCATION"],
                        ToLocation = localizer["FINAL DESTINATION"],
                        TransferDistance = localizer["DISTANCE"],
                        TransferDuration = localizer["DURATION"],
                        Price = localizer["PRICE"],
                        DepositPrice = localizer["DEPOSIT"],
                        ToBeCharged = localizer["REQUIRED ON SITE"],
                        NumberOfPersons = localizer["NUMBER OF PERSONS"],
                        FullName = localizer["FULL NAME"],
                        Phone = $"{localizer["PHONE"]}",
                        Email = $"{localizer["EMAIL"]}",
                        AdditionalInfo = localizer["ADDITIONAL INFO"]
                    };

                    var depositTransferBookingNotificationTemplateModel = new DepositTransferNotificationTemplateModel
                    {
                        Transfer = notification.TransferName,
                        Date = notification.Date.ToString("dd-MM-yyyy"),
                        Time = notification.Time.ToString("hh\\:mm"),
                        FromLocation = notification.FromLocation,
                        ToLocation = notification.ToLocation,
                        TransferDistance = notification.TransferDistance + " km",
                        TransferDuration = notification.TransferDuration,
                        Price = notification.Price.ToString("N2"),
                        DepositPrice = notification.DepositPrice.ToString("N2"),
                        ToBeCharged = notification.ToBeCharged.ToString("N2"),
                        NumberOfPersons = notification.NumberOfPersons,
                        FullName = notification.FullName,
                        Phone = notification.Phone,
                        Email = notification.Email,
                        AdditionalInfo = notification.AdditionalInfo
                    };

                    var mailBody = templateEngine.Render(TransferTemplates.Email.DepositTransferPaymentNotCompleted.Name,
                        ("notification", depositTransferBookingNotificationTemplateModel),
                        ("fieldName", depositTransferTemplateModel));

                    await emailSender.SendEmailAsync(emailAddress.BookingFrom, emailAddress.BookingTo, subject, mailBody);
                    await MarkTransferBookingsAsNotifiedAsync(notCompletedTransferBookingNotifications.Select(b => b.Id).ToArray());
                }
                else if (notification.DepositPrice == 0)
                {
                    subject = "NOTIFICATION: NOT COMPLETED FULL TRANSFER BOOKING";
                    var fullTransferTemplateModel = new FullTransferTemplateModel
                    {
                        Date = localizer["DATE"],
                        Time = localizer["TIME"],
                        FromLocation = localizer["STARTING LOCATION"],
                        ToLocation = localizer["FINAL DESTINATION"],
                        TransferDistance = localizer["DISTANCE"],
                        TransferDuration = localizer["DURATION"],
                        Price = localizer["PRICE"],
                        NumberOfPersons = localizer["NUMBER OF PERSONS"],
                        FullName = localizer["FULL NAME"],
                        Phone = $"{localizer["PHONE"]}",
                        Email = $"{localizer["EMAIL"]}",
                        AdditionalInfo = localizer["ADDITIONAL INFO"]
                    };

                    var fullTransferBookingNotificationTemplateModel = new FullTransferNotificationTemplateModel
                    {
                        Transfer = notification.TransferName,
                        Date = notification.Date.ToString("dd-MM-yyyy"),
                        Time = notification.Time.ToString("hh\\:mm"),
                        FromLocation = notification.FromLocation,
                        ToLocation = notification.ToLocation,
                        TransferDistance = notification.TransferDistance + " km",
                        TransferDuration = notification.TransferDuration,
                        Price = notification.Price.ToString("N2"),
                        NumberOfPersons = notification.NumberOfPersons,
                        FullName = notification.FullName,
                        Phone = notification.Phone,
                        Email = notification.Email,
                        AdditionalInfo = notification.AdditionalInfo
                    };

                    var mailBody = templateEngine.Render(TransferTemplates.Email.FullTransferPaymentNotCompleted.Name,
                        ("notification", fullTransferBookingNotificationTemplateModel),
                        ("fieldName", fullTransferTemplateModel));

                    await emailSender.SendEmailAsync(emailAddress.BookingFrom, emailAddress.BookingTo, subject, mailBody);
                    await MarkTransferBookingsAsNotifiedAsync(notCompletedTransferBookingNotifications.Select(b => b.Id).ToArray());
                }
            }
        }

        private async Task MarkTransferBookingsAsNotifiedAsync(int[] bookingIds)
        {
            const string MARK_TRANSFER_BOOKINGS_NOTIFIED_COMMAND =
            @"UPDATE
                transfer_booking
              SET
                send_not_completed_notification = FALSE
              WHERE
                id = ANY(@BookingIds)
              AND application_id = @Application;";

            var markBookingsNotifiedArgs = new
            {
                BookingIds = bookingIds,
                Application = applicationOptions.ApplicationId
            };

            using var connection = await connectionFactory.CreateOpenAsync();
            await connection.ExecuteAsync(MARK_TRANSFER_BOOKINGS_NOTIFIED_COMMAND, markBookingsNotifiedArgs);
        }
    }
}