using System;

namespace AdapterPatternExample
{
    public interface IPaymentProcessor
    {
        void ProcessPayment(double amount);
    }

    public class RazorpayGateway
    {
        public void PayViaRazorpay(double amount)
        {
            Console.WriteLine($"[Razorpay] Successfully processed payment of ₹{amount} via card/netbanking.");
        }
    }

    public class PhonePeAPI
    {
        public void TransferViaUPI(double amount)
        {
            Console.WriteLine($"[PhonePe] UPI transfer of ₹{amount} successful.");
        }
    }

    public class RazorpayAdapter : IPaymentProcessor
    {
        private readonly RazorpayGateway _razorpayGateway;

        public RazorpayAdapter(RazorpayGateway razorpayGateway)
        {
            _razorpayGateway = razorpayGateway;
        }

        public void ProcessPayment(double amount)
        {
            _razorpayGateway.PayViaRazorpay(amount);
        }
    }

    public class PhonePeAdapter : IPaymentProcessor
    {
        private readonly PhonePeAPI _phonePeAPI;

        public PhonePeAdapter(PhonePeAPI phonePeAPI)
        {
            _phonePeAPI = phonePeAPI;
        }

        public void ProcessPayment(double amount)
        {
            _phonePeAPI.TransferViaUPI(amount);
        }
    }
}