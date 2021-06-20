using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;

namespace CableCarDubrovnik.Web.App.Infrastructure.HtmlMetadata
{
    public static class MetadataHtmlHelper
    {
        public static HtmlString GenerateMetadataTags(this IHtmlHelper helper, MetadataContent data)
        {
            var sw = new StringWriter();

            if (!string.IsNullOrEmpty(data.ApplicationName))
            {
                WriteMetaTag("application-name", data.ApplicationName, sw);
            }
            if (!string.IsNullOrEmpty(data.Author))
            {
                WriteMetaTag("author", data.Author, sw);
            }

            if (!string.IsNullOrEmpty(data.Copyright))
            {
                WriteMetaTag("copyright", data.Copyright, sw);
            }

            if (!string.IsNullOrEmpty(data.Description))
            {
                WriteMetaTag("description", data.Description, sw);
            }

            if (data.Keywords.Any())
            {
                var keywords = string.Join(", ", data.Keywords);
                WriteMetaTag("keywords", keywords, sw);
            }

            var ogData = data.OpenGraphMetadata;

            if (!string.IsNullOrEmpty(ogData.Title))
            {
                WriteMetaTag("og:title", ogData.Title, sw);
            }

            if (!string.IsNullOrEmpty(ogData.Type))
            {
                WriteMetaTag("og:type", ogData.Type, sw);
            }

            if (!string.IsNullOrEmpty(ogData.Url))
            {
                WriteMetaTag("og:url", ogData.Url, sw);
            }

            if (!string.IsNullOrEmpty(ogData.Image))
            {
                WriteMetaTag("og:image", ogData.Image, sw);
                WriteMetaTag("og:image:width", ogData.ImageWidth.ToString(), sw);
                WriteMetaTag("og:image:height", ogData.ImageHeight.ToString(), sw);
                WriteMetaTag("og:image:type", ogData.ImageType.ToString(), sw);
            }

            if (!string.IsNullOrEmpty(ogData.Description))
            {
                WriteMetaTag("og:description", ogData.Description, sw);
            }

            if (!string.IsNullOrEmpty(ogData.SiteName))
            {
                WriteMetaTag("og:site_name", ogData.SiteName, sw);
            }

            return new HtmlString(sw.ToString());
        }

        private static void WriteMetaTag(string name, string content, StringWriter sw)
        {
            var authorTagBuilder = new TagBuilder("meta");
            authorTagBuilder.Attributes.Add("name", name);
            authorTagBuilder.Attributes.Add("content", content);
            authorTagBuilder.TagRenderMode = TagRenderMode.StartTag;
            authorTagBuilder.WriteTo(sw, HtmlEncoder.Default);
            sw.WriteLine();
        }
    }
}