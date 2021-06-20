using System.Collections.Generic;

namespace CableCarDubrovnik.Web.App.Infrastructure.HtmlMetadata
{
    public class MetadataContent
    {
        public MetadataContent()
        {
            Keywords.Add("cable car dubrovnik");
            Keywords.Add("mario travel");
            Keywords.Add("dubrovnik cable car");
            Keywords.Add("book online and save big");
            Keywords.Add("tours for cruise ships crew");
            Keywords.Add("five star tripadvisor tour reviews");
            Keywords.Add("panoramic view of dubrovnik");
            Keywords.Add("dubrovnik panorama tour");
        }

        public string ApplicationName { get; set; } = "Cable Car Dubrovnik";

        public string Author { get; set; } = "Mario Travel d.o.o.";

        public string Copyright { get; set; } = "Mario Travel d.o.o.";

        public string Description { get; set; } = "Buy cable car tickets to see Dubrovnik from the sky or book our Panorama Tour to meet our great city with a beautiful view from above.";
        public List<string> Keywords { get; } = new List<string>();
        public OpenGraphMetadata OpenGraphMetadata { get; } = new OpenGraphMetadata();
    }
}