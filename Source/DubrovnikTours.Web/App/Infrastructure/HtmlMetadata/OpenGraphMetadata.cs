namespace DubrovnikTours.Web.App.Infrastructure.HtmlMetadata
{
    public class OpenGraphMetadata
    {
        public string Title { get; set; } = "Dubrovnik Tours";
        public string Type { get; set; } = "website";
        public string Url { get; set; } = "https://www.dubrovniktours.tours";
        public string Image { get; set; } = "http://www.dubrovniktours.tours/brand/application-dubrovnik-tours-open-graph-image.png";
        public int ImageWidth { get; set; } = 600;
        public int ImageHeight { get; set; } = 314;
        public string ImageType { get; set; } = "image/webp";
        public string Description { get; set; }
        public string SiteName { get; set; } = "Dubrovnik Tours";
    }
}