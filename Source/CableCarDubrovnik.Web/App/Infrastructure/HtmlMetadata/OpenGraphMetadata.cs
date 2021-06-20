namespace CableCarDubrovnik.Web.App.Infrastructure.HtmlMetadata
{
    public class OpenGraphMetadata
    {
        public string Title { get; set; } = "Cable Car Dubrovnik";
        public string Type { get; set; } = "website";
        public string Url { get; set; } = "https://www.cablecardubrovnik.com";
        public string Image { get; set; } = "http://www.cablecardubrovnik.com/assets/app-defaults/application-cable-car-open-graph-image.png";
        public int ImageWidth { get; set; } = 1200;
        public int ImageHeight { get; set; } = 630;
        public string ImageType { get; set; } = "image/webp";
        public string Description { get; set; }
        public string SiteName { get; set; } = "Cable Car Dubrovnik";
    }
}