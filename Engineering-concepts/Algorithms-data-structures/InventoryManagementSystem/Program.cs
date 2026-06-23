using System;

namespace InventoryManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Inventory Management System ---\n");

            Inventory inventory = new Inventory();

            inventory.AddProduct(new Product("P101", "Amul Taaza Milk 1L", 50, 68.00));
            inventory.AddProduct(new Product("P102", "Tata Salt 1kg", 200, 28.00));
            inventory.AddProduct(new Product("P103", "Maggi 2-Minute Noodles", 500, 14.00));

            Console.WriteLine("\n-----------------------------------\n");

            inventory.UpdateProduct("P102", 150, 30.00);
            inventory.DeleteProduct("P101");
            inventory.DeleteProduct("P999");
        }
    }
}