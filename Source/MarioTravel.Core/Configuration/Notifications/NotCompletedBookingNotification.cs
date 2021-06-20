using System;

namespace MarioTravel.Core.Configuration.Notifications
{
    public class NotCompletedBookingNotification
    {
        /// <summary>
        /// How often the service should run.
        /// </summary>
        public TimeSpan RunEvery { get; set; }

        /// <summary>
        /// Which booking entries are considered not completed (i.e. how long do they have to get paid)
        /// </summary>
        public TimeSpan NotCompletedAge { get; set; }
    }
}