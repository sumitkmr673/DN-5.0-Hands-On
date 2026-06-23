using System;

namespace BuilderPatternExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------Testing Builder Pattern------\n");

            Computer officeComputer = new Computer.Builder("Intel Core i5", "8GB", "512GB SSD")
                .Build();

            Console.WriteLine("Basic Office Computer:");
            officeComputer.DisplayConfiguration();

            Computer gamingComputer = new Computer.Builder("AMD Ryzen 9", "32GB", "2TB NVMe SSD")
                .SetGPU("NVIDIA RTX 5090")
                .SetBluetooth(true)
                .Build();

            Console.WriteLine("High-End Gaming Computer:");
            gamingComputer.DisplayConfiguration();
        }
    }
}