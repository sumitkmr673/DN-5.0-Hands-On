using System;

namespace EcommerceSearchOptimization
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- E-commerce Search Engine Optimization ---\n");

            Product[] catalog = new Product[]
            {
                new Product("PRD001", "Aashirvaad Atta 5kg", "Groceries"),
                new Product("PRD002", "boAt Airdopes 141", "Electronics"),
                new Product("PRD003", "Kissan Fresh Tomato Ketchup", "Groceries"),
                new Product("PRD004", "Milton Thermosteel Bottle", "Home & Kitchen"),
                new Product("PRD005", "Pigeon by Stovekraft Gas Stove", "Home & Kitchen")
            };

            SearchEngine searchEngine = new SearchEngine();

            Console.WriteLine("Executing Linear Search for Target ID: PRD003...");
            Product? linearResult = searchEngine.LinearSearch(catalog, "PRD003");
            if (linearResult != null)
            {
                Console.WriteLine($"[Linear Search Match] ID: {linearResult.ProductId} | Name: {linearResult.ProductName} | Category: {linearResult.Category}");
            }

            Console.WriteLine("\n-----------------------------------\n");

            Console.WriteLine("Executing Binary Search for Target ID: PRD005...");
            Product? binaryResult = searchEngine.BinarySearch(catalog, "PRD005");
            if (binaryResult != null)
            {
                Console.WriteLine($"[Binary Search Match] ID: {binaryResult.ProductId} | Name: {binaryResult.ProductName} | Category: {binaryResult.Category}");
            }
        }
    }
}