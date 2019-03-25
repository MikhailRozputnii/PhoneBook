namespace PhoneBook.BusinessLogic.Contracts
{
    public interface IEmailSender
    {
        void SendEmail(string email, string subject, string message);
    }
}
