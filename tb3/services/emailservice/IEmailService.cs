using tb3.models;

namespace tb3.services.emailservice
{
    public interface IEmailService
    {
        void SendEmail(Emaildetails request);
        void SendEmail(object request);
    }
}
