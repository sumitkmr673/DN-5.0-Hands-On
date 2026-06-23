using System;

namespace StrategyPatternExample
{
    public interface IPaymentStrategy
    {
        void Pay(double amount);
    }

    public class UPIPayment : IPaymentStrategy
    {
        private readonly string _upiId;

        public UPIPayment(string upiId)
        {
            _upiId = upiId;
        }

        public void Pay(double amount)
        {
            Console.WriteLine($"Paid ₹{amount} using UPI ID: {_upiId}");
        }
    }

    public class RuPayCardPayment : IPaymentStrategy
    {
        private readonly string _cardNumber;
        private readonly string _cvv;

        public RuPayCardPayment(string cardNumber, string cvv)
        {
            _cardNumber = cardNumber;
            _cvv = cvv;
        }

        public void Pay(double amount)
        {
            Console.WriteLine($"Paid ₹{amount} using RuPay Card ending in {_cardNumber.Substring(_cardNumber.Length - 4)}");
        }
    }

    public class PaymentContext
    {
        private IPaymentStrategy _paymentStrategy;

        public PaymentContext(IPaymentStrategy paymentStrategy)
        {
            _paymentStrategy = paymentStrategy;
        }

        public void SetPaymentStrategy(IPaymentStrategy paymentStrategy)
        {
            _paymentStrategy = paymentStrategy;
        }

        public void ExecutePayment(double amount)
        {
            _paymentStrategy.Pay(amount);
        }
    }
}