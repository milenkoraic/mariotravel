using MarioTravel.Core.BLL.Models.Tour;
using System;

namespace MarioTravel.Core.BLL.Models.Payment
{
    public class UnpaidTourBooking
    {
        public string Title { get; set; }
        public int TourId { get; set; }
        public TourImage MainImage { get; set; }
        public Guid ExternalId { get; set; }
        public DateTimeOffset Date { get; set; }
        public decimal Duration { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal DepositPrice { get; set; }
        public decimal ToBeCharged { get; set; }
        public TimeSpan Time { get; set; }
        public int NumberOfPersons { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string AdditionalInfo { get; set; }
    }
}