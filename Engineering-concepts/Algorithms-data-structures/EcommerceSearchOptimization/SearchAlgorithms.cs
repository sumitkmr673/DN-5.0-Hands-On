using System;

namespace EcommerceSearchOptimization
{
    public class Product
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }

        public Product(string id, string name, string category)
        {
            ProductId = id;
            ProductName = name;
            Category = category;
        }
    }

    public class SearchEngine
    {
        public Product? LinearSearch(Product[] products, string targetId)
        {
            foreach (var product in products)
            {
                if (product.ProductId == targetId)
                {
                    return product;
                }
            }
            return null;
        }

        public Product? BinarySearch(Product[] products, string targetId)
        {
            int left = 0;
            int right = products.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                int comparison = string.Compare(products[mid].ProductId, targetId, StringComparison.Ordinal);

                if (comparison == 0)
                {
                    return products[mid];
                }
                if (comparison < 0)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return null;
        }
    }
}