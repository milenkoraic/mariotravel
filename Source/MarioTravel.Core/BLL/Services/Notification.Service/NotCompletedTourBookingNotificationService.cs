using EnsureThat;
using MarioTravel.Core.Configuration.Notifications;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MarioTravel.Core.BLL.Services.Notification.Service
{
    public class NotCompletedTourBookingNotificationService : BackgroundService
    {
        private readonly TourBookingNotificationService tourBookingNotificationService;
        private readonly NotCompletedBookingNotification notCompletedBookingNotification;

        private readonly ILogger<NotCompletedTourBookingNotificationService> logger;

        public NotCompletedTourBookingNotificationService(
            TourBookingNotificationService tourBookingNotificationServiceAccessor,
            IOptions<NotCompletedBookingNotification> notCompletedBookingNotificationAccessor,

            ILogger<NotCompletedTourBookingNotificationService> logger)
        {
            EnsureArg.IsNotNull(tourBookingNotificationServiceAccessor, nameof(logger));
            EnsureArg.IsNotNull(notCompletedBookingNotificationAccessor, nameof(notCompletedBookingNotificationAccessor));
            EnsureArg.IsNotNull(notCompletedBookingNotificationAccessor.Value, nameof(notCompletedBookingNotificationAccessor.Value));
            EnsureArg.IsNotNull(logger, nameof(logger));

            this.tourBookingNotificationService = tourBookingNotificationServiceAccessor;

            notCompletedBookingNotification = notCompletedBookingNotificationAccessor.Value;

            this.logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            logger.LogDebug($"Starting {nameof(NotCompletedTourBookingNotificationService)}...");

            while (!stoppingToken.IsCancellationRequested)
            {
                logger.LogDebug("Not completed bookings notification start.");
                try
                {
                    await tourBookingNotificationService.SendNotCompletedTourBookingNotificationEmailAsync(notCompletedBookingNotification.NotCompletedAge);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An error has occurred while checking for not completed bookings.");
                }

                await Task.Delay(notCompletedBookingNotification.RunEvery, stoppingToken);
            }

            logger.LogDebug($"Stopping {nameof(NotCompletedTourBookingNotificationService)}...");
        }
    }
}