using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(MarioTravel.Admin.Areas.Identity.IdentityHostingStartup))]

namespace MarioTravel.Admin.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}