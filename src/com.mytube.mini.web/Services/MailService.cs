using System.Diagnostics;

namespace com.mytube.mini.web.Services
{
    public class MailService : IMailService
    {
        public void SendMail(string to, string from, string subject, string body)
        {
            Debug.WriteLine($"Sending Mail: To: {to} From: {from} Subject {subject}");
        }
    }
}
