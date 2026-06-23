using System;
using System.Collections.Generic;

namespace ObserverPatternExample
{
    public interface IObserver
    {
        void Update(string stockName, double price);
    }

    public interface IStock
    {
        void Register(IObserver observer);
        void Deregister(IObserver observer);
        void NotifyObservers();
    }

    public class StockMarket : IStock
    {
        private readonly List<IObserver> _observers = new List<IObserver>();
        private readonly string _stockName;
        private double _price;

        public StockMarket(string stockName, double price)
        {
            _stockName = stockName;
            _price = price;
        }

        public void UpdatePrice(double newPrice)
        {
            _price = newPrice;
            NotifyObservers();
        }

        public void Register(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Deregister(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            foreach (var observer in _observers)
            {
                observer.Update(_stockName, _price);
            }
        }
    }

    public class MobileApp : IObserver
    {
        public void Update(string stockName, double price)
        {
            Console.WriteLine($"[Mobile App] {stockName} price changed to ₹{price}");
        }
    }

    public class WebApp : IObserver
    {
        public void Update(string stockName, double price)
        {
            Console.WriteLine($"[Web App] {stockName} price changed to ₹{price}");
        }
    }
}