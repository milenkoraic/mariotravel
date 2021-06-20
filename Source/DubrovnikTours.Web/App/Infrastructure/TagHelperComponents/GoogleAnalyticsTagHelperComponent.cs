using MarioTravel.Core.Configuration.Api.Keys;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Options;
using System;

namespace DubrovnikTours.Web.App.Infrastructure.TagHelperComponents
{
    public class GoogleAnalyticsTagHelperComponent : TagHelperComponent
    {
        private readonly GoogleAnalytics googleAnalytics;

        private HttpContext HttpContext => ViewContext.HttpContext;

        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public GoogleAnalyticsTagHelperComponent(IOptions<GoogleAnalytics> googleAnalytics)
        {
            this.googleAnalytics = googleAnalytics.Value;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var consentFeature = HttpContext.Features.Get<ITrackingConsentFeature>();
            var cookieCanTrack = (HttpContext.Request.Cookies[".CanTrack"]);

            // Inject the code only in the head element
            if (string.Equals(output.TagName, "head", StringComparison.OrdinalIgnoreCase) && cookieCanTrack != null)
            {
                // Get the tracking code from the configuration
                var trackingCode = googleAnalytics.TrackingCode;

                if (!string.IsNullOrEmpty(trackingCode) && consentFeature.CanTrack)
                {
                    // PostContent correspond to the text just before closing tag
                    output.PostContent

                        // Inject Google Analytics
                        .AppendHtml("<script async src='https://www.googletagmanager.com/gtag/js?id=" + trackingCode + "'></script><script>window.dataLayer = window.dataLayer || [];function gtag(){ dataLayer.push(arguments); }gtag('js', new Date());gtag('config'," + "'" + trackingCode + "');</script>");
                }
            }
        }
    }
}