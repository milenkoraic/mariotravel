namespace MarioTravel.Core.BLL.Models.Tour
{
    public class TourImage
    {
        public int Id { get; set; }
        public int TourId { get; set; }
        public string Url { get; set; }
        public string AltDescription { get; set; }
        public int ApplicationId { get; set; }
    }
}