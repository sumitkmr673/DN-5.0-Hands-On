using System;

namespace OrderSortingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- E-Commerce Order Sorting System ---\n");

            Order[] ordersForBubble = new Order[]
            {
                new Order("ORD001", "Ravi Kumar", 1500.50),
                new Order("ORD002", "Priya Sharma", 8500.00),
                new Order("ORD003", "Amit Patel", 450.00),
                new Order("ORD004", "Neha Gupta", 12400.75),
                new Order("ORD005", "Vikram Singh", 3200.00)
            };

            Order[] ordersForQuick = new Order[ordersForBubble.Length];
            Array.Copy(ordersForBubble, ordersForQuick, ordersForBubble.Length);

            Sorter sorter = new Sorter();

            Console.WriteLine("Executing Bubble Sort (O(N^2))...");
            sorter.BubbleSort(ordersForBubble);
            foreach (var order in ordersForBubble)
            {
                Console.WriteLine($"[Bubble Sorted] ID: {order.OrderId} | Customer: {order.CustomerName} | Total: ₹{order.TotalPrice}");
            }

            Console.WriteLine("\n-----------------------------------\n");

            Console.WriteLine("Executing Quick Sort (O(N log N))...");
            sorter.QuickSort(ordersForQuick, 0, ordersForQuick.Length - 1);
            foreach (var order in ordersForQuick)
            {
                Console.WriteLine($"[Quick Sorted] ID: {order.OrderId} | Customer: {order.CustomerName} | Total: ₹{order.TotalPrice}");
            }
        }
    }
}