using MarioTravel.Core.BLL.Services.EmailTemplate.Service;

namespace MarioTravel.Core.BLL.Models.Email.FullPayment
{
    public class FullTourNotificationTemplateModel : ITemplateModel
    {
        public string TourName { get; set; }
        public string Status { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Duration { get; set; }
        public int NumberOfPersons { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string AdditionalInfo { get; set; }
        public string Price { get; set; }
        public string MeetingPoint { get; set; }
        public string MeetingPointPageUrl { get; set; }
    }
}