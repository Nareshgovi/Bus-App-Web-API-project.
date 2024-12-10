using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using tb3.models;
using System.Net.Mail;
using MailKit.Net.Smtp;


namespace tb3.services.emailservice
{
    public class Emailservice : IEmailService
    {
        private IConfiguration _config;

        public Emailservice(IConfiguration config)
        {
            _config = config;

        }
        public void SendEmail(Emaildetails request)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_config.GetSection("EmailUsername").Value));
            email.To.Add(MailboxAddress.Parse(request.To));
            email.Subject = request.subject;
            email.Body = new TextPart(TextFormat.Html) { Text = request.body };

            using var smtp = new MailKit.Net.Smtp.SmtpClient();
            smtp.Connect(_config.GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(_config.GetSection("EmailUsername").Value, _config.GetSection("EmailPassword").Value);
            smtp.Send(email);
            smtp.Disconnect(true);
        }

        public void SendEmail(object request)
        {
            throw new NotImplementedException();
        }
    }
}
