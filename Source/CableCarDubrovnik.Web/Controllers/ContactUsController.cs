using CableCarDubrovnik.Web.Models.ContactUs;
using MarioTravel.Core.BLL.Services.Email.Service;
using MarioTravel.Core.Configuration.Emails;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Text;
using System.Threading.Tasks;

namespace CableCarDubrovnik.Web.Controllers
{
    public class ContactUsController : Controller
    {
        private readonly EmailSender emailSender;
        private readonly ILogger<ContactUsController> logger;
        private readonly EmailAddress emailAddress;

        public ContactUsController(
            EmailSender emailSender,
            IOptions<EmailAddress> emailAddressAccessor,
            ILogger<ContactUsController> logger)
        {
            if (emailAddressAccessor == null)
            {
                throw new ArgumentNullException(nameof(emailAddressAccessor));
            }

            this.emailSender = emailSender ?? throw new ArgumentNullException(nameof(emailSender));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));

            emailAddress = emailAddressAccessor.Value;
        }

        public ViewResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Submit([FromBody] ContactUsFormViewModel model)
        {
            try
            {
                var subject = $"New contact from {model.Name} subject: {model.Subject}";
                var messageBuilder = new StringBuilder();
                messageBuilder.AppendLine($"<p><b>Name:</b> {model.Name}</p>");
                messageBuilder.AppendLine($"<p><b>Email:</b> {model.Email}</p>");
                messageBuilder.AppendLine($"<p><b>Subject:</b> {model.Subject}</p>");
                messageBuilder.Append($"<p>{model.Message}</p>");

                await emailSender.SendEmailAsync(emailAddress.ContactUsFrom, emailAddress.ContactUsTo, subject, messageBuilder.ToString());
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An exception occurred while sending the email.");
                return StatusCode(500);
            }
        }
    }
}