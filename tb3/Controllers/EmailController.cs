using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;
using tb3.models;
using tb3.services.emailservice;


namespace tb3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;
        public EmailController( IEmailService emailService)
        {
            _emailService = emailService;
        }

        public IEmailService EmailService { get; }

        [HttpPost]
        public IActionResult SendEmail(Emaildetails request)
        {
            _emailService.SendEmail(request);
            return Ok();  

        }
    }
}