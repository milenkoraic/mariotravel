namespace DubrovnikTours.Web.Models
{
    public class MeetingPointViewModel
    {
        public string GooleMapsApiKey { get; }

        public MeetingPointViewModel(string gooleMapsApiKey)
        {
            GooleMapsApiKey = gooleMapsApiKey;
        }
    }
}