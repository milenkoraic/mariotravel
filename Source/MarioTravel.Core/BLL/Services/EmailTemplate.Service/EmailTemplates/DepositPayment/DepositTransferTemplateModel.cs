using MarioTravel.Core.BLL.Services.EmailTemplate.Service;

namespace MarioTravel.Core.BLL.Models.Email.DepositPayment
{
    public class DepositTransferTemplateModel : ITemplateModel
    {
        public string Date { get; set; }
        public string Time { get; set; }
        public string NumberOfPersons { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string AdditionalInfo { get; set; }
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public string TransferDistance { get; set; }
        public string TransferDuration { get; set; }
        public string Price { get; set; }
        public string DepositPrice { get; set; }
        public string ToBeCharged { get; set; }
    }
}