using System.Collections.Generic;

namespace DubrovnikTours.Web.App.Infrastructure.HtmlMetadata
{
    public class MetadataContent
    {
        public MetadataContent()
        {
            Keywords.Add("dubrovnik tours");
            Keywords.Add("mario travel");
            Keywords.Add("private tours");
            Keywords.Add("scheduled tours");
            Keywords.Add("history tours");
            Keywords.Add("game of thrones");
            Keywords.Add("visit croatian islands");
            Keywords.Add("boat tours advanture");
            Keywords.Add("visit montenegro");
            Keywords.Add("visit bosnia");
            Keywords.Add("book online and save big");
            Keywords.Add("tours for cruise ships crew");
            Keywords.Add("transfers to anywhere");
            Keywords.Add("dubrovnik city walls tour");
            Keywords.Add("excursions from dubrovnik");
            Keywords.Add("dubrovnik tours en español");
            Keywords.Add("where to go from dubrovnik");
            Keywords.Add("cheap and best tours in dubrovnik");
            Keywords.Add("five star tripadvisor tour reviews");
            Keywords.Add("learn about the city");
        }

        public string ApplicationName { get; set; } = "Dubrovnik Tours";

        public string Authors { get; set; } = "Milenko Raic & Vedran Zakanj";

        public string Copyright { get; set; } = "Mario Travel d.o.o.";

        public string Description { get; set; } = "Visit or travel anywhere arround Dubrovnik! Game of Thrones, Old Town, Private and Scheduled tours, Transfers, Excursions, Bosnia, Montenegro. English and Spanish support.";
        public List<string> Keywords { get; } = new List<string>();
        public OpenGraphMetadata OpenGraphMetadata { get; } = new OpenGraphMetadata();
    }
}