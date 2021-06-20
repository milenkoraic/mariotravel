using MarioTravel.Core.Configuration.Emails;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MarioTravel.Core.BLL.Services.Email.Service
{
    public class EmailSender
    {
        private readonly EmailAccess emailAccess;

        public EmailSender(IOptions<EmailAccess> emailAccessAccessor)
        {
            if (emailAccessAccessor == null)
            {
                throw new System.ArgumentNullException(nameof(emailAccessAccessor));
            }

            emailAccess = emailAccessAccessor.Value;
        }

        public async Task SendEmailAsync(string from, string to, string subject, string body)
        {
            using (var client = new SmtpClient(emailAccess.Host, emailAccess.Port))
            {
                client.UseDefaultCredentials = false;
                client.EnableSsl = emailAccess.EnableSsl;

                if (!string.IsNullOrEmpty(emailAccess.Username) && !string.IsNullOrEmpty(emailAccess.Password))
                {
                    client.Credentials = new NetworkCredential(emailAccess.Username, emailAccess.Password);
                }

                var message = new MailMessage(from, to, subject, body)
                {
                    BodyEncoding = Encoding.UTF8,
                    IsBodyHtml = true
                };

                await client.SendMailAsync(message);
            }
        }
    }
}