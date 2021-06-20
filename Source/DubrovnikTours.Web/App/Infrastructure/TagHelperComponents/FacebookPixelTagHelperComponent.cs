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
    public class FacebookPixelTagHelperComponent : TagHelperComponent
    {
        private readonly FacebookPixel facebookPixel;

        private HttpContext HttpContext => ViewContext.HttpContext;

        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public FacebookPixelTagHelperComponent(IOptions<FacebookPixel> facebookPixel)
        {
            this.facebookPixel = facebookPixel.Value;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var consentFeature = HttpContext.Features.Get<ITrackingConsentFeature>();
            var cookieCanTrack = (HttpContext.Request.Cookies[".CanTrack"]);

            // Inject the code only in the head element
            if (string.Equals(output.TagName, "head", StringComparison.OrdinalIgnoreCase) && cookieCanTrack != null)
            {
                // Get the tracking code from the configuration
                var trackingCode = facebookPixel.TrackingCode;
                if (!string.IsNullOrEmpty(trackingCode) && consentFeature.CanTrack)
                {
                    // PostContent correspond to the text just before closing tag
                    output.PostContent
                    .AppendHtml("<script> !function(f,b,e,v,n,t,s) { if (f.fbq) return; n=f.fbq=function() {n.callMethod?n.callMethod.apply(n,arguments):n.queue.push(arguments)}; if (!f._fbq) f._fbq = n; n.push = n; n.loaded =!0; n.version='2.0';n.queue=[];t= b.createElement(e); t.async = !0;t.src = v; s = b.getElementsByTagName(e)[0];s.parentNode.insertBefore(t,s)}(window,document,'script','https://connect.facebook.net/en_US/fbevents.js'); fbq('init','" + trackingCode + "'); fbq('track','PageView'); </script>" + "<noscript><img height='1' width='1' style='display: none' src = https://www.facebook.com/tr?id=900878203579800&ev=PageView&noscript=1" + "/></noscript>");
                }
            }
        }
    }
}