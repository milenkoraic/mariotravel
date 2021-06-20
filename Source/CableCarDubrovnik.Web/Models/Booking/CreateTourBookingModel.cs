using System;

namespace CableCarDubrovnik.Web.Models.Web.Models.Booking
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
        public string PickUpPoint { get; set; }
        public int NumberOfChildren { get; set; }
        public int NumberOfBabies { get; set; }
        public string AdditionalInfo { get; set; }
    }
}