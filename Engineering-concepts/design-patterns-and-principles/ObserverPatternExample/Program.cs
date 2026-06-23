using System;

namespace ObserverPatternExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Testing Observer Pattern ---\n");

            StockMarket techStock = new StockMarket("TECH_CORP", 150.00);

            MobileApp mobileClient = new MobileApp();
            WebApp webClient = new WebApp();

            techStock.Register(mobileClient);
            techStock.Register(webClient);

            Console.WriteLine("Market: Updating price to ₹155.00...");
            techStock.UpdatePrice(155.00);

            Console.WriteLine("\nMarket: Deregistering Web App...");
            techStock.Deregister(webClient);

            Console.WriteLine("\nMarket: Updating price to ₹160.00...");
            techStock.UpdatePrice(160.00);
        }
    }
}