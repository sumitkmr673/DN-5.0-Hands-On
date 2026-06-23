using System;

namespace ProxyPatternExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Testing Proxy Pattern ---\n");

            IImage image = new ProxyImage("high_resolution_landscape.png");

            Console.WriteLine("Client: Requesting image display for the first time...");
            image.Display();

            Console.WriteLine("\n-----------------------------------\n");

            Console.WriteLine("Client: Requesting image display for the second time...");
            image.Display();
        }
    }
}