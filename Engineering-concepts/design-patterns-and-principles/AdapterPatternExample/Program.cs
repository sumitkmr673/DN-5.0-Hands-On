using System;

namespace AdapterPatternExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------Testing Adapter Pattern------\n");

            Console.WriteLine("Client: Attempting to process payment via Razorpay...");
            RazorpayGateway razorpay = new RazorpayGateway();
            IPaymentProcessor razorpayProcessor = new RazorpayAdapter(razorpay);
            razorpayProcessor.ProcessPayment(1500.50);

            Console.WriteLine("\n-----------------------------------\n");

            Console.WriteLine("Client: Attempting to process payment via PhonePe UPI...");
            PhonePeAPI phonePe = new PhonePeAPI();
            IPaymentProcessor phonePeProcessor = new PhonePeAdapter(phonePe);
            phonePeProcessor.ProcessPayment(450.00);
        }
    }
}