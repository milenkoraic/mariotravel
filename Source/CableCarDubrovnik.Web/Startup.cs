using CableCarDubrovnik.Web.App.Infrastructure.HtmlMetadata;
using CableCarDubrovnik.Web.Views.Mappers;
using EnsureThat;
using MarioTravel.Core.BLL;
using MarioTravel.Core.BLL.Models.Payment;
using MarioTravel.Core.BLL.Services.Booking.Service;
using MarioTravel.Core.BLL.Services.Email.Service;
using MarioTravel.Core.BLL.Services.EmailTemplate.Service;
using MarioTravel.Core.BLL.Services.EmailTemplate.Service.TemplateRegister;
using MarioTravel.Core.BLL.Services.Language.Service;
using MarioTravel.Core.BLL.Services.Notification.Service;
using MarioTravel.Core.BLL.Services.Payment.Service;
using MarioTravel.Core.BLL.Services.Time.Service;
using MarioTravel.Core.BLL.Services.Tour.Service;
using MarioTravel.Core.Configuration.Application;
using MarioTravel.Core.Configuration.Emails;
using MarioTravel.Core.Configuration.Images;
using MarioTravel.Core.Configuration.Notifications;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using IWebHostEnvironment = Microsoft.AspNetCore.Hosting.IWebHostEnvironment;

namespace CableCarDubrovnik.Web
{
    public class Startup
    {
        private IConfiguration Configuration { get; }
        private IWebHostEnvironment HostingEnvironment { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment hostingEnvironment)
        {
            Configuration = configuration;
            HostingEnvironment = hostingEnvironment;
        }

        public class LanguageRouteConstraint : IRouteConstraint
        {
            public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
            {
                if (!values.ContainsKey("culture"))
                    return false;

                var culture = values["culture"].ToString();
                return culture == "en" || culture == "es";
            }
        }

        public class RouteDataRequestCultureProvider : RequestCultureProvider
        {
            public int IndexOfCulture;
            public int IndexofUICulture;

            public override Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
            {
                if (httpContext == null)
                    throw new ArgumentNullException(nameof(httpContext));

                string culture = null;
                string uiCulture = null;

                var twoLetterCultureName = httpContext.Request.Path.Value.Split('/')[IndexOfCulture]?.ToString();

                if (twoLetterCultureName == "es")
                    culture = "es-ES";

                if (twoLetterCultureName == "en")
                    culture = uiCulture = "en-US";

                if (culture == null && uiCulture == null)
                    return NullProviderCultureResult;

                if (culture != null && uiCulture == null)
                    uiCulture = culture;

                if (culture == null && uiCulture != null)
                    culture = uiCulture;

                var providerResultCulture = new ProviderCultureResult(culture, uiCulture);

                return Task.FromResult(providerResultCulture);
            }
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureLocalization(services);
            RegisterDomainServices(services);
            RegisterHostedServices(services);
            RegisterTemplates(services);

            services.AddLocalization(options => options.ResourcesPath = "Views.Resources");

            services.AddMvc(option => option.EnableEndpointRouting = false)
               .AddNewtonsoftJson()
               .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
               .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
               .AddRazorRuntimeCompilation()
               .AddDataAnnotationsLocalization();

            services.AddDataProtection();

            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]
                {
                    new CultureInfo("en-US"),
                    new CultureInfo("es"),
                };

                options.DefaultRequestCulture = new RequestCulture(culture: "en-US", uiCulture: "en-US");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
                options.RequestCultureProviders = new[]{ new RouteDataRequestCultureProvider{
                    IndexOfCulture=1,
                    IndexofUICulture=1
                }};
            });

            services.Configure<RouteOptions>(options =>
            {
                options.ConstraintMap.Add("culture", typeof(LanguageRouteConstraint));
            });

            services.AddDataProtection();

            services.Configure<HostOptions>(Configuration.GetSection("Host"));

            var tempServiceProvider = services.BuildServiceProvider();
            var hostOptions = tempServiceProvider.GetService<IOptions<HostOptions>>().Value;

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.Configure<ApplicationOptions>(Configuration.GetSection("ApplicationOptions"));

            services.Configure<ConnectionOptions>(Configuration.GetSection("Database"));

            services.Configure<ImageDirectory>(Configuration.GetSection("Image"));

            services.Configure<EmailAccess>(Configuration.GetSection("Email"));
            services.Configure<EmailAddress>(Configuration.GetSection("Email:Addresses"));

            services.Configure<PaymentOptions>(Configuration.GetSection("Payment"));

            services.Configure<ComplitedBookingNotification>(options => options.MeetingPointPageUrl = Path.Combine(hostOptions.BasePublicUrl, "meeting-point"));
            services.Configure<NotCompletedBookingNotification>(Configuration.GetSection("HostedServices:BookingNotCompletedNotification"));
        }

        private void RegisterTemplates(IServiceCollection services)
        {
            var templateEngine = new TemplateEngine();

            //REGISTER TOUR TEMPLATES
            templateEngine.RegisterTemplate(TourTemplates.Email.DepositTourPaymentApproved.Name, TourTemplates.Email.DepositTourPaymentApproved.Path.Replace("~", HostingEnvironment.ContentRootPath));
            templateEngine.RegisterTemplate(TourTemplates.Email.DepositTourPaymentDeclined.Name, TourTemplates.Email.DepositTourPaymentDeclined.Path.Replace("~", HostingEnvironment.ContentRootPath));
            templateEngine.RegisterTemplate(TourTemplates.Email.DepositTourPaymentNotCompleted.Name, TourTemplates.Email.DepositTourPaymentNotCompleted.Path.Replace("~", HostingEnvironment.ContentRootPath));
            templateEngine.RegisterTemplate(TourTemplates.Email.FullTourPaymentApproved.Name, TourTemplates.Email.FullTourPaymentApproved.Path.Replace("~", HostingEnvironment.ContentRootPath));
            templateEngine.RegisterTemplate(TourTemplates.Email.FullTourPaymentDeclined.Name, TourTemplates.Email.FullTourPaymentDeclined.Path.Replace("~", HostingEnvironment.ContentRootPath));
            templateEngine.RegisterTemplate(TourTemplates.Email.FullTourPaymentNotCompleted.Name, TourTemplates.Email.FullTourPaymentNotCompleted.Path.Replace("~", HostingEnvironment.ContentRootPath));

            services.AddSingleton(templateEngine);
        }

        private static void ConfigureLocalization(IServiceCollection services)
        {
            services.AddLocalization(o => o.ResourcesPath = "Views.Resources");
            var supportedUiCultures = new[]
            {
                new CultureInfo("en-US"),
                new CultureInfo("es")
            };

            var requestCultureProviders = new List<IRequestCultureProvider>
            {
                new CookieRequestCultureProvider()
            };

            services.Configure<RequestLocalizationOptions>(o =>
            {
                o.DefaultRequestCulture = new RequestCulture("en-US");
                o.SupportedUICultures = supportedUiCultures;
                o.SupportedCultures = supportedUiCultures;
                o.RequestCultureProviders = requestCultureProviders;
            });
        }

        private static void RegisterHostedServices(IServiceCollection services)
        {
            services.AddSingleton<IHostedService, NotCompletedTourBookingNotificationService>();
        }

        private static void RegisterDomainServices(IServiceCollection services)
        {
            services.AddSingleton<ConnectionFactory>();
            services.AddScoped<MetadataContent>();
            services.AddSingleton<TourService>();
            services.AddSingleton<LanguageService>();
            services.AddSingleton<TimeService>();
            services.AddSingleton<TourMapper>();
            services.AddSingleton<BookingService>();
            services.AddSingleton<PaymentService>();
            services.AddSingleton<TourBookingNotificationService>();
            services.AddSingleton<TransferBookingNotificationService>();
            services.AddSingleton<EmailSender>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseCookiePolicy();
            var locOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(locOptions.Value);

            app.UseStaticFiles();

            Directory.SetCurrentDirectory(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));
            loggerFactory.AddFile("Logs/cablecar-{Date}.txt");

            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            app.UseStaticFiles();
            app.UseMvc(routes =>
            {

                routes.MapRoute(
                    name: "contact_us",
                    template: "{culture:culture}/contact-us",
                    defaults: new { controller = "ContactUs", action = "Contact" }
                );

                routes.MapRoute(
                    name: "contact_us_submit",
                    template: "contact-us/submit",
                    defaults: new { controller = "ContactUs", action = "Submit" }
                );

                routes.MapRoute(
                    name: "cookies",
                    template: "{culture:culture}/cookies",
                    defaults: new { controller = "Cookies", action = "CookiesList" }
                );


                routes.MapRoute(
                    name: "policy",
                    template: "{culture:culture}/policy",
                    defaults: new { controller = "Policy", action = "Privacy" }
                );

                routes.MapRoute(
                    name: "tour",
                    template: "{culture:culture}/tour/{id}/{slug?}",
                    defaults: new { controller = "Tour", action = "TourBooking" }
                );

                routes.MapRoute(
                    name: "set_language",
                    template: "lang",
                    defaults: new { controller = "Home", action = "SetLanguage" }
                );

                routes.MapRoute(
                    name: "LocalizedDefault",
                    template: "{culture:culture}/{controller=Home}/{action=Index}"
                );

                routes.MapRoute(
                    name: "home",
                    template: "",
                    defaults: new { controller = "Home", action = "RedirectToDefaultCulture" }
                );
            });
        }
    }
}