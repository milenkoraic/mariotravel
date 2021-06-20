using Dapper;
using EnsureThat;
using MarioTravel.Core.BLL.Models.Email.DepositPayment;
using MarioTravel.Core.BLL.Models.Email.FullPayment;
using MarioTravel.Core.BLL.Models.Notification.Tour;
using MarioTravel.Core.BLL.Services.Email.Service;
using MarioTravel.Core.BLL.Services.EmailTemplate.Service;
using MarioTravel.Core.BLL.Services.EmailTemplate.Service.TemplateRegister;
using MarioTravel.Core.BLL.Services.EmailTemplate.Service.TemplateResources;
using MarioTravel.Core.Configuration.Application;
using MarioTravel.Core.Configuration.Emails;
using MarioTravel.Core.Configuration.Notifications;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MarioTravel.Core.BLL.Services.Notification.Service
{
    public class TourBookingNotificationService
    {
        private readonly ConnectionFactory connectionFactory;
        private readonly ApplicationOptions applicationOptions;
        private readonly ComplitedBookingNotification complitedBookingNotification;
        private readonly EmailAddress emailAddress;
        private readonly EmailSender emailSender;
        private readonly TemplateEngine templateEngine;
        private readonly IStringLocalizer<EmailBodyResources> localizer;

        public TourBookingNotificationService(
            ConnectionFactory connectionFactory,
            IOptions<ApplicationOptions> applicationOptionsAccessor,
            IOptions<ComplitedBookingNotification> complitedBookingNotificationAccessor,
            IOptions<EmailAddress> emailAddressAccessor,
            EmailSender emailSender,
            TemplateEngine templateEngine,
            IStringLocalizer<EmailBodyResources> localizer)
        {
            this.connectionFactory = EnsureArg.IsNotNull(connectionFactory, nameof(connectionFactory));
            EnsureArg.IsNotNull(applicationOptionsAccessor, nameof(applicationOptionsAccessor));
            applicationOptions = EnsureArg.IsNotNull(applicationOptionsAccessor.Value, nameof(applicationOptionsAccessor.Value));
            EnsureArg.IsNotNull(complitedBookingNotificationAccessor, nameof(complitedBookingNotificationAccessor));
            complitedBookingNotification = EnsureArg.IsNotNull(complitedBookingNotificationAccessor.Value);
            this.emailSender = EnsureArg.IsNotNull(emailSender, nameof(emailSender));
            EnsureArg.IsNotNull(emailAddressAccessor, nameof(emailAddressAccessor));
            emailAddress = EnsureArg.IsNotNull(emailAddressAccessor.Value);
            this.templateEngine = EnsureArg.IsNotNull(templateEngine, nameof(templateEngine));
            this.localizer = EnsureArg.IsNotNull(localizer, nameof(localizer));
        }

        public async Task<FinishedTourBookingNotification> GetTourBookingNotificationAsync(Guid externalId)
        {
            const string GET_COMPLETED_TOUR_BOOKINGS = @"SELECT
                    t.title AS tour_name,
                    b.external_id,
                    b.time_of_day AS time,
                    b.date,
                    b.duration,
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
                    tour_booking b
                    INNER JOIN tour t ON b.tour_id = t.id
                    INNER JOIN payment p ON b.external_id = p.booking_external_id
                WHERE
                    b.external_id = @ExternalId
                AND b.application_id = @Application;";

            var sqlParams = new
            {
                ExternalId = externalId,
                Application = applicationOptions.ApplicationId
            };

            using var connection = await connectionFactory.CreateOpenAsync();

            var booking = (await connection.QueryAsync<FinishedTourBookingNotification>(GET_COMPLETED_TOUR_BOOKINGS, sqlParams)).FirstOrDefault();

            return booking;
        }

        public async Task<NotFinishedTourBookingNotification[]> GetNotFinishedTourBookingsAsync(DateTime latestDateCreated)
        {
            const string GET_NOT_COMPLETED_TOURS = @"SELECT
                    b.id,
                    t.title AS tour_name,
                    b.external_id,
                    b.time_of_day AS time,
                    b.date,
                    b.duration,
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
                    tour_booking b
                    INNER JOIN tour t ON b.tour_id = t.id
                WHERE
                    b.send_not_completed_notification = TRUE
                AND created_at <= @LatestDateCreated
                AND b.application_id = @Application;";

            var queryParams = new
            {
                LatestDateCreated = latestDateCreated,
                Application = applicationOptions.ApplicationId
            };

            using var connection = await connectionFactory.CreateOpenAsync();

            var bookings = await connection.QueryAsync<NotFinishedTourBookingNotification>(GET_NOT_COMPLETED_TOURS, queryParams);

            return bookings.ToArray();
        }

        public async Task SendTourBookingNotificationEmailAsync(Guid externalPaymentId)
        {
            var bookingNotification = await GetTourBookingNotificationAsync(externalPaymentId);

            if (bookingNotification == null)
            {
                throw new InvalidOperationException("Trying to send email for booking with no payment associated.");
            }

            string subject;

            if (!bookingNotification.IsApproved && bookingNotification.DepositPrice > 0)
            {
                bookingNotification.Status = "DEPOSIT PAYMENT DECLINED";
                subject = $"{localizer["DEPOSIT TOUR BOOKING FAILED"]} {bookingNotification.TourName}";
                var depositTourTemplateModel = new DepositTourTemplateModel
                {
                    Date = $"{localizer["DATE"]}",
                    Time = $"{localizer["TIME"]}",
                    Duration = $"{localizer["DURATION:"]}",
                    Price = $"{localizer["TOTAL PRICE"]}",
                    DepositPrice = $"{localizer["DEPOSIT"]}",
                    ToBeCharged = $"{localizer["REQUIRED ON SITE"]}",
                    NumberOfPersons = $"{localizer["NUMBER OF PERSONS"]}",
                    FullName = $"{localizer["NAME"]}",
                    Phone = $"{localizer["PHONE"]}",
                    Email = $"{localizer["EMAIL"]}",
                    AdditionalInfo = $"{localizer["ADDITIONAL INFO"]}",
                    MeetingPoint = $"{localizer["MEETING POINT"]}"
                };

                var depositTourNotificationTemplateModel = new DepositTourNotificationTemplateModel
                {
                    TourName = bookingNotification.TourName,
                    Status = bookingNotification.Status,
                    Date = bookingNotification.Date.ToString("dd-MM-yyyy"),
                    Time = bookingNotification.Time.ToString("hh\\:mm"),
                    Duration = Math.Round(bookingNotification.Duration, 1) + " hours".ToString(),
                    Price = bookingNotification.Price.ToString("N2"),
                    DepositPrice = bookingNotification.DepositPrice.ToString("N2"),
                    ToBeCharged = bookingNotification.ToBeCharged.ToString("N2"),
                    NumberOfPersons = bookingNotification.NumberOfPersons,
                    FullName = bookingNotification.FullName,
                    Phone = bookingNotification.Phone,
                    Email = bookingNotification.Email,
                    AdditionalInfo = bookingNotification.AdditionalInfo,
                    MeetingPoint = $"{localizer["Pile Square, our office is in front of the Tourist Information Center. Tiha 2, 20 000, Dubrovnik."]}",
                    MeetingPointPageUrl = complitedBookingNotification.MeetingPointPageUrl
                };

                var mailBody = templateEngine.Render(TourTemplates.Email.DepositTourPaymentDeclined.Name,
                    ("notification", depositTourNotificationTemplateModel),
                    ("fieldName", depositTourTemplateModel));

                await emailSender.SendEmailAsync(emailAddress.BookingFrom, emailAddress.BookingTo, subject, mailBody);
                await emailSender.SendEmailAsync(emailAddress.BookingFrom, bookingNotification.Email, subject, mailBody);
            }

            if (!bookingNotification.IsApproved && bookingNotification.DepositPrice == 0)
            {
                bookingNotification.Status = "FULL PAYMENT DECLINED";
                subject = $"{localizer["FULL TOUR BOOKING FAILED"]} {bookingNotification.TourName}";
                var fullTourTemplateModel = new FullTourTemplateModel
                {
                    Date = $"{localizer["DATE"]}",
                    Time = $"{localizer["TIME"]}",
                    Duration = $"{localizer["DURATION:"]}",
                    Price = $"{localizer["TOTAL PRICE"]}",
                    NumberOfPersons = $"{localizer["NUMBER OF PERSONS"]}",
                    FullName = $"{localizer["NAME"]}",
                    Phone = $"{localizer["PHONE"]}",
                    Email = $"{localizer["EMAIL"]}",
                    AdditionalInfo = $"{localizer["ADDITIONAL INFO"]}",
                    MeetingPoint = $"{localizer["MEETING POINT"]}"
                };

                var fullTourBookingNotificationTemplateModel = new FullTourNotificationTemplateModel
                {
                    TourName = bookingNotification.TourName,
                    Status = bookingNotification.Status,
                    Date = bookingNotification.Date.ToString("dd-MM-yyyy"),
                    Time = bookingNotification.Time.ToString("hh\\:mm"),
                    Duration = Math.Round(bookingNotification.Duration, 1) + " hours".ToString(),
                    Price = bookingNotification.Price.ToString("N2"),
                    NumberOfPersons = bookingNotification.NumberOfPersons,
                    FullName = bookingNotification.FullName,
                    Phone = bookingNotification.Phone,
                    Email = bookingNotification.Email,
                    AdditionalInfo = bookingNotification.AdditionalInfo,
                    MeetingPoint = $"{localizer["Pile Square, our office is in front of the Tourist Information Center. Tiha 2, 20 000, Dubrovnik."]}",
                    MeetingPointPageUrl = complitedBookingNotification.MeetingPointPageUrl
                };

                var mailBody = templateEngine.Render(TourTemplates.Email.FullTourPaymentDeclined.Name,
                    ("notification", fullTourBookingNotificationTemplateModel),
                    ("fieldName", fullTourTemplateModel));

                await emailSender.SendEmailAsync(emailAddress.BookingFrom, emailAddress.BookingTo, subject, mailBody);
                await emailSender.SendEmailAsync(emailAddress.BookingFrom, bookingNotification.Email, subject, mailBody);
            }

            if (bookingNotification.DepositPrice > 0 && bookingNotification.IsApproved)
            {
                bookingNotification.Status = "DEPOSIT PAID";
                subject = $"{localizer["DEPOSIT TOUR BOOKING APPROVED"]} {bookingNotification.TourName}";
                var depositTourTemplateModel = new DepositTourTemplateModel
                {
                    Date = $"{localizer["DATE"]}",
                    Time = $"{localizer["TIME"]}",
                    Duration = $"{localizer["DURATION:"]}",
                    Price = $"{localizer["TOTAL PRICE"]}",
                    DepositPrice = $"{localizer["DEPOSIT"]}",
                    ToBeCharged = $"{localizer["REQUIRED ON SITE"]}",
                    NumberOfPersons = $"{localizer["NUMBER OF PERSONS"]}",
                    FullName = $"{localizer["NAME"]}",
                    Phone = $"{localizer["PHONE"]}",
                    Email = $"{localizer["EMAIL"]}",
                    AdditionalInfo = $"{localizer["ADDITIONAL INFO"]}",
                    MeetingPoint = $"{localizer["MEETING POINT"]}"
                };

                var depositTourNotificationTemplateModel = new DepositTourNotificationTemplateModel
                {
                    TourName = bookingNotification.TourName,
                    Status = bookingNotification.Status,
                    Date = bookingNotification.Date.ToString("dd-MM-yyyy"),
                    Time = bookingNotification.Time.ToString("hh\\:mm"),
                    Duration = Math.Round(bookingNotification.Duration, 1) + " hours".ToString(),
                    Price = bookingNotification.Price.ToString("N2"),
                    DepositPrice = bookingNotification.DepositPrice.ToString("N2"),
                    ToBeCharged = bookingNotification.ToBeCharged.ToString("N2"),
                    NumberOfPersons = bookingNotification.NumberOfPersons,
                    FullName = bookingNotification.FullName,
                    Phone = bookingNotification.Phone,
                    Email = bookingNotification.Email,
                    AdditionalInfo = bookingNotification.AdditionalInfo,
                    MeetingPoint = $"{localizer["Pile Square, our office is in front of the Tourist Information Center. Tiha 2, 20 000, Dubrovnik."]}",
                    MeetingPointPageUrl = complitedBookingNotification.MeetingPointPageUrl
                };

                var mailBody = templateEngine.Render(TourTemplates.Email.DepositTourPaymentApproved.Name,
                    ("notification", depositTourNotificationTemplateModel),
                    ("fieldName", depositTourTemplateModel));

                await emailSender.SendEmailAsync(emailAddress.BookingFrom, emailAddress.BookingTo, subject, mailBody);
                await emailSender.SendEmailAsync(emailAddress.BookingFrom, bookingNotification.Email, subject, mailBody);
            }

            if (bookingNotification.DepositPrice == 0 && bookingNotification.IsApproved)
            {
                bookingNotification.Status = "FULL PAYMENT APPROVED";
                subject = $"{localizer["FULL TOUR BOOKING APPROVED"]} {bookingNotification.TourName}";
                var fullTourTemplateModel = new FullTourTemplateModel
                {
                    Date = $"{localizer["DATE"]}",
                    Time = $"{localizer["TIME"]}",
                    Duration = $"{localizer["DURATION:"]}",
                    Price = $"{localizer["TOTAL PRICE"]}",
                    NumberOfPersons = $"{localizer["NUMBER OF PERSONS"]}",
                    FullName = $"{localizer["NAME"]}",
                    Phone = $"{localizer["PHONE"]}",
                    Email = $"{localizer["EMAIL"]}",
                    AdditionalInfo = $"{localizer["ADDITIONAL INFO"]}",
                    MeetingPoint = $"{localizer["MEETING POINT"]}"
                };

                var fullTourBookingNotificationTemplateModel = new FullTourNotificationTemplateModel
                {
                    TourName = bookingNotification.TourName,
                    Status = bookingNotification.Status,
                    Date = bookingNotification.Date.ToString("dd-MM-yyyy"),
                    Time = bookingNotification.Time.ToString("hh\\:mm"),
                    Duration = Math.Round(bookingNotification.Duration, 1) + " hours".ToString(),
                    Price = bookingNotification.Price.ToString("N2"),
                    NumberOfPersons = bookingNotification.NumberOfPersons,
                    FullName = bookingNotification.FullName,
                    Phone = bookingNotification.Phone,
                    Email = bookingNotification.Email,
                    AdditionalInfo = bookingNotification.AdditionalInfo,
                    MeetingPoint = $"{localizer["Pile Square, our office is in front of the Tourist Information Center. Tiha 2, 20 000, Dubrovnik."]}",
                    MeetingPointPageUrl = complitedBookingNotification.MeetingPointPageUrl
                };

                var mailBody = templateEngine.Render(TourTemplates.Email.FullTourPaymentApproved.Name,
                    ("notification", fullTourBookingNotificationTemplateModel),
                    ("fieldName", fullTourTemplateModel));

                await emailSender.SendEmailAsync(emailAddress.BookingFrom, emailAddress.BookingTo, subject, mailBody);
                await emailSender.SendEmailAsync(emailAddress.BookingFrom, bookingNotification.Email, subject, mailBody);
            }
        }

        public async Task SendNotCompletedTourBookingNotificationEmailAsync(TimeSpan notCompletedAge)
        {
            var latestDateCreated = DateTime.UtcNow - notCompletedAge;

            var notCompletedBookingNotifications = await GetNotFinishedTourBookingsAsync(latestDateCreated);

            if (!notCompletedBookingNotifications.Any())
            {
                return;
            }

            string subject;
            foreach (var notification in notCompletedBookingNotifications)
            {
                if (notification.DepositPrice > 0)
                {
                    subject = $"{localizer["NOT COMPLITED DEPOSIT BOOKING"]} {notification.TourName}";
                    var depositTourTemplateModel = new DepositTourTemplateModel
                    {
                        Date = $"{localizer["DATE"]}",
                        Time = $"{localizer["TIME"]}",
                        Duration = $"{localizer["DURATION:"]}",
                        Price = $"{localizer["TOTAL PRICE"]}",
                        DepositPrice = $"{localizer["DEPOSIT"]}",
                        ToBeCharged = $"{localizer["REQUIRED ON SITE"]}",
                        NumberOfPersons = $"{localizer["NUMBER OF PERSONS"]}",
                        FullName = $"{localizer["NAME"]}",
                        Phone = $"{localizer["PHONE"]}",
                        Email = $"{localizer["EMAIL"]}",
                        AdditionalInfo = $"{localizer["ADDITIONAL INFO"]}",
                        MeetingPoint = $"{localizer["MEETING POINT"]}"
                    };

                    var tourBookingNotificationTemplateModel = new DepositTourNotificationTemplateModel
                    {
                        TourName = notification.TourName,
                        Date = notification.Date.ToString("dd-MM-yyyy"),
                        Time = notification.Time.ToString("hh\\:mm"),
                        Duration = Math.Round(notification.Duration, 1) + " hours".ToString(),
                        Price = notification.Price.ToString("N2"),
                        DepositPrice = notification.DepositPrice.ToString("N2"),
                        ToBeCharged = notification.ToBeCharged.ToString("N2"),
                        NumberOfPersons = notification.NumberOfPersons,
                        FullName = notification.FullName,
                        Phone = notification.Phone,
                        Email = notification.Email,
                        AdditionalInfo = notification.AdditionalInfo,
                        MeetingPoint = $"{localizer["Pile Square, our office is in front of the Tourist Information Center. Tiha 2, 20 000, Dubrovnik."]}",
                        MeetingPointPageUrl = complitedBookingNotification.MeetingPointPageUrl
                    };

                    var mailBody = templateEngine.Render(TourTemplates.Email.DepositTourPaymentNotCompleted.Name,
                        ("notification", tourBookingNotificationTemplateModel),
                        ("fieldName", depositTourTemplateModel));

                    await emailSender.SendEmailAsync(emailAddress.BookingFrom, emailAddress.BookingTo, subject, mailBody);
                    await MarkTourBookingsAsNotifiedAsync(notCompletedBookingNotifications.Select(b => b.Id).ToArray());
                }
                if (notification.DepositPrice == 0)
                {
                    subject = $"{localizer["NOT COMPLITED FULL BOOKING"]} {notification.TourName}";
                    var fullTourTemplateModel = new FullTourTemplateModel
                    {
                        Date = $"{localizer["DATE"]}",
                        Time = $"{localizer["TIME"]}",
                        Duration = $"{localizer["DURATION:"]}",
                        Price = $"{localizer["TOTAL PRICE"]}",
                        NumberOfPersons = $"{localizer["NUMBER OF PERSONS"]}",
                        FullName = $"{localizer["NAME"]}",
                        Phone = $"{localizer["PHONE"]}",
                        Email = $"{localizer["EMAIL"]}",
                        AdditionalInfo = $"{localizer["ADDITIONAL INFO"]}",
                        MeetingPoint = $"{localizer["MEETING POINT"]}"
                    };

                    var fullTourBookingNotificationTemplateModel = new FullTourNotificationTemplateModel
                    {
                        TourName = notification.TourName,
                        Date = notification.Date.ToString("dd-MM-yyyy"),
                        Time = notification.Time.ToString("hh\\:mm"),
                        Duration = Math.Round(notification.Duration, 1) + " hours".ToString(),
                        Price = notification.Price.ToString("N2"),
                        NumberOfPersons = notification.NumberOfPersons,
                        FullName = notification.FullName,
                        Phone = notification.Phone,
                        Email = notification.Email,
                        AdditionalInfo = notification.AdditionalInfo,
                        MeetingPoint = $"{localizer["Pile Square, our office is in front of the Tourist Information Center. Tiha 2, 20 000, Dubrovnik."]}",
                        MeetingPointPageUrl = complitedBookingNotification.MeetingPointPageUrl
                    };

                    var mailBody = templateEngine.Render(TourTemplates.Email.FullTourPaymentNotCompleted.Name,
                        ("notification", fullTourBookingNotificationTemplateModel),
                        ("fieldName", fullTourTemplateModel));

                    await emailSender.SendEmailAsync(emailAddress.BookingFrom, emailAddress.BookingTo, subject, mailBody);
                    await MarkTourBookingsAsNotifiedAsync(notCompletedBookingNotifications.Select(b => b.Id).ToArray());
                }
            }
        }

        private async Task MarkTourBookingsAsNotifiedAsync(int[] bookingIds)
        {
            const string MARK_TOUR_BOOKINGS_NOTIFIED_COMMAND =
            @"UPDATE
                tour_booking
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
            await connection.ExecuteAsync(MARK_TOUR_BOOKINGS_NOTIFIED_COMMAND, markBookingsNotifiedArgs);
        }
    }
}