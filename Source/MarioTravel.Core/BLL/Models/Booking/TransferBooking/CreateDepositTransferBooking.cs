using System;

namespace MarioTravel.Core.BLL.Models.Booking.TransferBooking
{
    public class CreateDepositTransferBooking
    {
        public int TransferId { get; set; }
        public DateTimeOffset Date { get; set; }
        public TimeSpan TimeOfDay { get; set; }
        public int NumberOfPersons { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string AdditionalInfo { get; set; }
        public decimal FullPrice { get; set; }
        public decimal DepositPrice { get; set; }
        public decimal ToBeCharged { get; set; }
        public Guid ExternalId { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool SendNotCompletedNotification { get; set; }
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public string TransferDistance { get; set; }
        public string TransferDuration { get; set; }

        public int ApplicationId { get; set; }
    }
}