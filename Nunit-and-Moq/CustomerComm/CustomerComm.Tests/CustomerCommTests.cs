using CustomerCommLib;
using Moq;
using NUnit.Framework;

namespace CustomerComm.Tests
{
    [TestFixture]
    public class CustomerCommTests
    {
        private Mock<IMailSender> _mockMailSender;
        private CustomerCommLib.CustomerComm _customerComm;

        [OneTimeSetUp]
        public void Init()
        {
            // Initialize the mock object
            _mockMailSender = new Mock<IMailSender>();

            // Inject the mocked dependency into our class
            _customerComm = new CustomerCommLib.CustomerComm(_mockMailSender.Object);
        }

        [TestCase("test@domain.com", "Test Message")]
        public void SendMailToCustomer_ShouldReturnTrue_WhenMailIsSent(string testAddress, string testMessage)
        {
            // Arrange: Configure the mock to accept ANY two strings and always return true
            _mockMailSender.Setup(m => m.SendMail(It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            // Act: Call the method we are testing
            bool result = _customerComm.SendMailToCustomer();

            // Assert: Verify the return value is true
            Assert.That(result, Is.True);

            // Verify the mock was actually called exactly once
            _mockMailSender.Verify(m => m.SendMail("cust123@abc.com", "Some Message"), Times.Once);
        }
    }
}