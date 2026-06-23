using System;

namespace StrategyPatternExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Testing Strategy Pattern ---\n");

            IPaymentStrategy upi = new UPIPayment("user@ybl");
            PaymentContext cart = new PaymentContext(upi);

            Console.WriteLine("Client: Checking out with UPI...");
            cart.ExecutePayment(850.75);

            Console.WriteLine("\n-----------------------------------\n");

            IPaymentStrategy rupay = new RuPayCardPayment("1234567890123456", "123");
            Console.WriteLine("Client: Changing payment method to RuPay Card...");

            cart.SetPaymentStrategy(rupay);
            cart.ExecutePayment(1200.00);
        }
    }
}