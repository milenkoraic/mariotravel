using Dapper;
using EnsureThat;
using MarioTravel.Core.BLL.Models.Booking.TourBooking;
using MarioTravel.Core.BLL.Models.Booking.TransferBooking;
using MarioTravel.Core.BLL.Models.Payment;
using MarioTravel.Core.Configuration.Application;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Threading.Tasks;

namespace MarioTravel.Core.BLL.Services.Booking.Service
{
    public class BookingService
    {
        private readonly ConnectionFactory connectionFactory;
        private readonly ApplicationOptions applicationOptions;

        public BookingService(
            ConnectionFactory connectionFactory,
            IOptions<ApplicationOptions> applicationOptionsAccessor)
        {
            this.connectionFactory = connectionFactory;
            EnsureArg.IsNotNull(applicationOptionsAccessor, nameof(applicationOptionsAccessor));
            applicationOptions = EnsureArg.IsNotNull(applicationOptionsAccessor.Value, nameof(applicationOptionsAccessor.Value));
        }

        public async Task<int> CreateDepositTourBookingAsync(CreateDepositTourBooking createDepositTourBooking)
        {
            const string CREATE_DEPOSIT_BOOKING_SQL =
                 @"INSERT INTO tour_booking (
                    tour_id,
                    date,
                    time_of_day,
                    duration,
                    number_of_persons,
                    full_name,
                    phone,
                    email,
                    additional_info,
                    total_price,
                    external_id,
                    send_not_completed_notification,
                    created_at,
                    deposit_price,
                    to_be_charged,
                    application_id)
                VALUES (
                    @TourId,
                    @Date,
                    @TimeOfDay,
                    @Duration,
                    @NumberOfPersons,
                    @FullName,
                    @Phone,
                    @Email,
                    @AdditionalInfo,
                    @FullPrice,
                    @ExternalId,
                    @SendNotCompletedNotification,
                    @CreatedAt,
                    @DepositPrice,
                    @ToBeCharged,
                    @ApplicationId) RETURNING id;";

            using (var connection = await connectionFactory.CreateOpenAsync())
            {
                var sqlParams = new
                {
                    createDepositTourBooking.TourId,
                    createDepositTourBooking.Date,
                    createDepositTourBooking.TimeOfDay,
                    createDepositTourBooking.Duration,
                    createDepositTourBooking.NumberOfPersons,
                    createDepositTourBooking.FullName,
                    createDepositTourBooking.Phone,
                    createDepositTourBooking.Email,
                    createDepositTourBooking.AdditionalInfo,
                    createDepositTourBooking.FullPrice,
                    createDepositTourBooking.ExternalId,
                    createDepositTourBooking.SendNotCompletedNotification,
                    createDepositTourBooking.CreatedAt,
                    createDepositTourBooking.DepositPrice,
                    createDepositTourBooking.ToBeCharged,
                    createDepositTourBooking.ApplicationId
                };
                return (await connection.QueryAsync<int>(CREATE_DEPOSIT_BOOKING_SQL, sqlParams)).Single();
            }
        }

        public async Task<int> CreateFullTourBookingAsync(CreateFullTourBooking createFullTourBooking)
        {
            const string CREATE_FULL_BOOKING_SQL =
                 @"INSERT INTO tour_booking (
                    tour_id,
                    date,
                    time_of_day,
                    duration,
                    number_of_persons,
                    full_name,
                    phone,
                    email,
                    additional_info,
                    total_price,
                    external_id,
                    send_not_completed_notification,
                    created_at,
                    application_id)
                VALUES (
                    @TourId,
                    @Date,
                    @TimeOfDay,
                    @Duration,
                    @NumberOfPersons,
                    @FullName,
                    @Phone,
                    @Email,
                    @AdditionalInfo,
                    @TotalPrice,
                    @ExternalId,
                    @SendNotCompletedNotification,
                    @CreatedAt,
                    @ApplicationId) RETURNING id;";

            using (var connection = await connectionFactory.CreateOpenAsync())
            {
                var sqlParams = new
                {
                    createFullTourBooking.TourId,
                    createFullTourBooking.Date,
                    createFullTourBooking.TimeOfDay,
                    createFullTourBooking.Duration,
                    createFullTourBooking.NumberOfPersons,
                    createFullTourBooking.FullName,
                    createFullTourBooking.Phone,
                    createFullTourBooking.Email,
                    createFullTourBooking.AdditionalInfo,
                    createFullTourBooking.TotalPrice,
                    createFullTourBooking.ExternalId,
                    createFullTourBooking.SendNotCompletedNotification,
                    createFullTourBooking.CreatedAt,
                    createFullTourBooking.ApplicationId
                };
                return (await connection.QueryAsync<int>(CREATE_FULL_BOOKING_SQL, sqlParams)).Single();
            }
        }

        public async Task<UnpaidTourBooking> GetUnpaidTourBookingAsync(int bookingId)
        {
            using var connection = await connectionFactory.CreateOpenAsync();
            var unpaidBooking = (await connection.QueryAsync<UnpaidTourBooking>(
                  @"SELECT
                            t.title,
                            b.tour_id,
                            b.external_id,
                            b.date,
                            b.duration,
                            b.total_price,
                            b.time_of_day AS time,
                            b.number_of_persons,
                            b.full_name,
                            b.phone,
                            b.email,
                            b.additional_info,
                            b.application_id
                        FROM
                            tour_booking b
                            INNER JOIN tour t ON b.tour_id = t.id
                            LEFT JOIN payment p ON b.external_id = p.booking_external_id
                        WHERE
                            b.raw_payment_response IS NULL
                            AND p.id IS NULL
                            AND b.id = @BookingId
                            AND b.application_id = @Application;",
                      new
                      {
                          BookingId = bookingId,
                          Application = applicationOptions.ApplicationId
                      })).FirstOrDefault();

            if (unpaidBooking == null)
                return null;

            return unpaidBooking;
        }

        public async Task<int> CreateDepositTransferBookingAsync(CreateDepositTransferBooking createDepositTransferBooking)
        {
            const string CREATE_DEPOSIT_TRANSFER_BOOKING_SQL =
                 @"INSERT INTO transfer_booking (
                    transfer_id,
                    date,
                    time_of_day,
                    number_of_persons,
                    full_name,
                    phone,
                    email,
                    additional_info,
                    total_price,
                    external_id,
                    send_not_completed_notification,
                    created_at,
                    deposit_price,
                    to_be_charged,
                    from_location,
                    to_location,
                    transfer_distance,
                    transfer_duration,
                    application_id)
                VALUES (
                    @TransferId,
                    @Date,
                    @TimeOfDay,
                    @NumberOfPersons,
                    @FullName,
                    @Phone,
                    @Email,
                    @AdditionalInfo,
                    @FullPrice,
                    @ExternalId,
                    @SendNotCompletedNotification,
                    @CreatedAt,
                    @DepositPrice,
                    @ToBeCharged,
                    @FromLocation,
                    @ToLocation,
                    @TransferDistance,
                    @TransferDuration,
                    @ApplicationId) RETURNING id;";

            using var connection = await connectionFactory.CreateOpenAsync();
            var sqlParams = new
            {
                createDepositTransferBooking.TransferId,
                createDepositTransferBooking.Date,
                createDepositTransferBooking.TimeOfDay,
                createDepositTransferBooking.NumberOfPersons,
                createDepositTransferBooking.FullName,
                createDepositTransferBooking.Phone,
                createDepositTransferBooking.Email,
                createDepositTransferBooking.AdditionalInfo,
                createDepositTransferBooking.FullPrice,
                createDepositTransferBooking.ExternalId,
                createDepositTransferBooking.SendNotCompletedNotification,
                createDepositTransferBooking.CreatedAt,
                createDepositTransferBooking.DepositPrice,
                createDepositTransferBooking.ToBeCharged,
                createDepositTransferBooking.FromLocation,
                createDepositTransferBooking.ToLocation,
                createDepositTransferBooking.TransferDistance,
                createDepositTransferBooking.TransferDuration,
                createDepositTransferBooking.ApplicationId
            };
            return (await connection.QueryAsync<int>(CREATE_DEPOSIT_TRANSFER_BOOKING_SQL, sqlParams)).Single();
        }

        public async Task<int> CreateFullTransferBookingAsync(CreateFullTransferBooking createFullTransferBooking)
        {
            const string CREATE_FULL_TRANSFER_BOOKING_SQL =
                 @"INSERT INTO transfer_booking (
                    transfer_id,
                    date,
                    time_of_day,
                    number_of_persons,
                    full_name,
                    phone,
                    email,
                    additional_info,
                    total_price,
                    external_id,
                    send_not_completed_notification,
                    created_at,
                    from_location,
                    to_location,
                    transfer_distance,
                    transfer_duration,
                    application_id)
                VALUES (
                    @TransferId,
                    @Date,
                    @TimeOfDay,
                    @NumberOfPersons,
                    @FullName,
                    @Phone,
                    @Email,
                    @AdditionalInfo,
                    @TotalPrice,
                    @ExternalId,
                    @SendNotCompletedNotification,
                    @CreatedAt,
                    @FromLocation,
                    @ToLocation,
                    @TransferDistance,
                    @TransferDuration,
                    @ApplicationId) RETURNING id;";

            using var connection = await connectionFactory.CreateOpenAsync();
            var sqlParams = new
            {
                createFullTransferBooking.TransferId,
                createFullTransferBooking.Date,
                createFullTransferBooking.TimeOfDay,
                createFullTransferBooking.NumberOfPersons,
                createFullTransferBooking.FullName,
                createFullTransferBooking.Phone,
                createFullTransferBooking.Email,
                createFullTransferBooking.AdditionalInfo,
                createFullTransferBooking.TotalPrice,
                createFullTransferBooking.ExternalId,
                createFullTransferBooking.SendNotCompletedNotification,
                createFullTransferBooking.CreatedAt,
                createFullTransferBooking.FromLocation,
                createFullTransferBooking.ToLocation,
                createFullTransferBooking.TransferDistance,
                createFullTransferBooking.TransferDuration,
                createFullTransferBooking.ApplicationId
            };
            return (await connection.QueryAsync<int>(CREATE_FULL_TRANSFER_BOOKING_SQL, sqlParams)).Single();
        }

        public async Task<UnpaidTransferBooking> GetUnpaidTransferBookingAsync(int bookingId)
        {
            using var connection = await connectionFactory.CreateOpenAsync();
            var unpaidTransferBooking = (await connection.QueryAsync<UnpaidTransferBooking>(
                  @"SELECT
                            t.title,
                            b.transfer_id,
                            b.external_id,
                            b.date,
                            b.total_price,
                            b.time_of_day AS time,
                            b.number_of_persons,
                            b.full_name,
                            b.phone,
                            b.email,
                            b.additional_info,
                            b.from_location,
                            b.to_location,
                            b.transfer_distance,
                            b.transfer_duration,
                            b.application_id
                        FROM
                            transfer_booking b
                            INNER JOIN transfer t ON b.transfer_id = t.id
                            LEFT JOIN payment p ON b.external_id = p.booking_external_id
                        WHERE
                            b.raw_payment_response IS NULL
                            AND p.id IS NULL
                            AND b.id = @BookingId
                            AND b.application_id = @Application;",
                      new
                      {
                          BookingId = bookingId,
                          Application = applicationOptions.ApplicationId
                      })).FirstOrDefault();

            if (unpaidTransferBooking == null)
                return null;

            return unpaidTransferBooking;
        }
    }
}