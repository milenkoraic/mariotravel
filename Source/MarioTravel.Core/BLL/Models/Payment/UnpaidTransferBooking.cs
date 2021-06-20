using System;

namespace MarioTravel.Core.BLL.Models.Payment
{
    public class UnpaidTransferBooking
    {
        public string Title { get; set; }
        public int TransferId { get; set; }
        public Guid ExternalId { get; set; }
        public DateTimeOffset Date { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal DepositPrice { get; set; }
        public decimal ToBeCharged { get; set; }
        public TimeSpan Time { get; set; }
        public int NumberOfPersons { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string AdditionalInfo { get; set; }
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public string TransferDistance { get; set; }
        public string TransferDuration { get; set; }
    }
}