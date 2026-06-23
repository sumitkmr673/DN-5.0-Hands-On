using System;

namespace OrderSortingSystem
{
    public class Order
    {
        public string OrderId { get; set; }
        public string CustomerName { get; set; }
        public double TotalPrice { get; set; }

        public Order(string id, string name, double price)
        {
            OrderId = id;
            CustomerName = name;
            TotalPrice = price;
        }
    }

    public class Sorter
    {
        public void BubbleSort(Order[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j].TotalPrice < arr[j + 1].TotalPrice)
                    {
                        Order temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }

        public void QuickSort(Order[] arr, int low, int high)
        {
            if (low < high)
            {
                int partitionIndex = Partition(arr, low, high);

                QuickSort(arr, low, partitionIndex - 1);
                QuickSort(arr, partitionIndex + 1, high);
            }
        }

        private int Partition(Order[] arr, int low, int high)
        {
            double pivot = arr[high].TotalPrice;
            int i = (low - 1);

            for (int j = low; j <= high - 1; j++)
            {
                if (arr[j].TotalPrice >= pivot)
                {
                    i++;
                    Order temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            Order swapTemp = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = swapTemp;

            return i + 1;
        }
    }
}