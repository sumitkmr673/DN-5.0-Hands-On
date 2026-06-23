namespace CustomerCommLib
{
    public class CustomerComm
    {
        IMailSender _mailSender;

        // Constructor Injection
        public CustomerComm(IMailSender mailSender)
        {
            _mailSender = mailSender;
        }

        public bool SendMailToCustomer()
        {
            // Actual logic goes here
            _mailSender.SendMail("cust123@abc.com", "Some Message");
            return true;
        }
    }
}