using System;

namespace DubrovnikTours.Web.Models.Booking
{
    public class CreateTourBookingModel
    {
        public int TourId { get; set; }
        public string Date { get; set; }
        public TimeSpan Time { get; set; }
        public int NumberOfPeople { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string AdditionalInfo { get; set; }
        public int ApplicationId { get; set; }
    }
}