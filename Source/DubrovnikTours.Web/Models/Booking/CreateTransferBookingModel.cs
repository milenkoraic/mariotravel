using System;

namespace DubrovnikTours.Web.Models.Booking
{
    public class CreateTransferBookingModel
    {
        public int TransferId { get; set; }
        public string Date { get; set; }
        public TimeSpan Time { get; set; }
        public int NumberOfPeople { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string AdditionalInfo { get; set; }
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public decimal TransferDistance { get; set; }
        public string TransferDuration { get; set; }
        public string TransferType { get; set; }
        public int ApplicationId { get; set; }
    }
}
