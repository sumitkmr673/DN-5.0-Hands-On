using System;
using System.Collections.Generic;

namespace InventoryManagementSystem
{
    public class Product
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public Product(string id, string name, int qty, double price)
        {
            ProductId = id;
            ProductName = name;
            Quantity = qty;
            Price = price;
        }
    }

    public class Inventory
    {
        private Dictionary<string, Product> _products = new Dictionary<string, Product>();

        public void AddProduct(Product product)
        {
            if (!_products.ContainsKey(product.ProductId))
            {
                _products.Add(product.ProductId, product);
                Console.WriteLine($"[ADD] Added {product.ProductName} to inventory.");
            }
            else
            {
                Console.WriteLine($"[ERROR] Product ID {product.ProductId} already exists.");
            }
        }

        public void UpdateProduct(string productId, int newQuantity, double newPrice)
        {
            if (_products.ContainsKey(productId))
            {
                _products[productId].Quantity = newQuantity;
                _products[productId].Price = newPrice;
                Console.WriteLine($"[UPDATE] Updated Product ID {productId}. New Qty: {newQuantity}, New Price: ₹{newPrice}");
            }
            else
            {
                Console.WriteLine($"[ERROR] Product ID {productId} not found.");
            }
        }

        public void DeleteProduct(string productId)
        {
            if (_products.Remove(productId))
            {
                Console.WriteLine($"[DELETE] Removed Product ID {productId} from inventory.");
            }
            else
            {
                Console.WriteLine($"[ERROR] Product ID {productId} not found.");
            }
        }
    }
}