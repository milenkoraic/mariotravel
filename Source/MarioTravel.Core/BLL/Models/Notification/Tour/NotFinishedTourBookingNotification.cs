using System;

namespace MarioTravel.Core.BLL.Models.Notification.Tour
{
    public class NotFinishedTourBookingNotification
    {
        public int Id { get; set; }
        public DateTimeOffset Date { get; set; }
        public string TourName { get; set; }
        public TimeSpan Time { get; set; }
        public decimal Duration { get; set; }
        public int NumberOfPersons { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string AdditionalInfo { get; set; }
        public decimal Price { get; set; }
        public decimal DepositPrice { get; set; }
        public decimal ToBeCharged { get; set; }
        public string FullName { get; set; }
    }
}