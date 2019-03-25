using MailKit.Net.Smtp;
using MimeKit;
using PhoneBook.BusinessLogic.Contracts;

namespace PhoneBook.BusinessLogic.Services
{
    public class EmailSender : IEmailSender
    {
        public void SendEmail(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Site administration", "app.test.phone.book@gmail.com"));
            emailMessage.To.Add(new MailboxAddress("Phone boook", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart("plain")
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("app.test.phone.book@gmail.com", "test1234u");
                client.Send(emailMessage);
                client.Disconnect(true);
            }
        }
    }
}
