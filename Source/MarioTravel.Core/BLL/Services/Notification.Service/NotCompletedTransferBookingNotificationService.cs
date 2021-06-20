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
    public class NotCompletedTransferBookingNotificationService : BackgroundService
    {
        private readonly TransferBookingNotificationService transferBookingNotificationService;
        private readonly NotCompletedBookingNotification notCompletedBookingNotification;

        private readonly ILogger<NotCompletedTransferBookingNotificationService> logger;

        public NotCompletedTransferBookingNotificationService(
            IOptions<NotCompletedBookingNotification> notCompletedBookingNotificationAccessor,
            TransferBookingNotificationService transferBookingNotificationServiceAccessor,

            ILogger<NotCompletedTransferBookingNotificationService> logger)
        {
            EnsureArg.IsNotNull(transferBookingNotificationServiceAccessor, nameof(logger));
            EnsureArg.IsNotNull(notCompletedBookingNotificationAccessor, nameof(notCompletedBookingNotificationAccessor));
            EnsureArg.IsNotNull(notCompletedBookingNotificationAccessor.Value, nameof(notCompletedBookingNotificationAccessor.Value));
            EnsureArg.IsNotNull(logger, nameof(logger));

            this.transferBookingNotificationService = transferBookingNotificationServiceAccessor;

            notCompletedBookingNotification = notCompletedBookingNotificationAccessor.Value;

            this.logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            logger.LogDebug($"Starting {nameof(NotCompletedTransferBookingNotificationService)}...");

            while (!stoppingToken.IsCancellationRequested)
            {
                logger.LogDebug("Not completed bookings notification start.");
                try
                {
                    await transferBookingNotificationService.SendNotCompletedTranferBookingNotificationEmailAsync(notCompletedBookingNotification.NotCompletedAge);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An error has occurred while checking for not completed bookings.");
                }

                await Task.Delay(notCompletedBookingNotification.RunEvery, stoppingToken);
            }

            logger.LogDebug($"Stopping {nameof(NotCompletedTransferBookingNotificationService)}...");
        }
    }
}