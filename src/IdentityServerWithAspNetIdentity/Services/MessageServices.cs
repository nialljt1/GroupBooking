using System.Threading.Tasks;

namespace IdentityServerWithAspNetIdentity.Services
{
    // This class is used by the application to send Email and SMS
    // when you turn on two-factor authentication in ASP.NET Identity.
    // For more details see this link http://go.microsoft.com/fwlink/?LinkID=532713
    public class AuthMessageSender : IEmailSender, ISmsSender
    {
        public MailService _mailService { get; set; }

        public AuthMessageSender()
        {
            _mailService = new MailService();
        }

        public async Task<bool> SendEmailAsync(string email, string subject, string message)
        {
            string from = "info@talksharp.com";
            string to = "test@example.com";
            subject = "hello world";
            string body = "hello world from mailgun";

            bool result = await _mailService.SendAsync(from, to, subject, body);

            return result;
        }

        public Task SendSmsAsync(string number, string message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }
}
