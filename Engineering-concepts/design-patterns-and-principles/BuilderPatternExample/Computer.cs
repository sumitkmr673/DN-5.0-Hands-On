using System;

namespace BuilderPatternExample
{
    public class Computer
    {
        public string CPU { get; private set; }
        public string RAM { get; private set; }
        public string Storage { get; private set; }

        public string? GPU { get; private set; }
        public bool HasBluetooth { get; private set; }

        private Computer(Builder builder)
        {
            CPU = builder.CPU;
            RAM = builder.RAM;
            Storage = builder.Storage;
            GPU = builder.GPU;
            HasBluetooth = builder.HasBluetooth;
        }

        public void DisplayConfiguration()
        {
            Console.WriteLine($"- CPU: {CPU}");
            Console.WriteLine($"- RAM: {RAM}");
            Console.WriteLine($"- Storage: {Storage}");
            Console.WriteLine($"- GPU: {(string.IsNullOrEmpty(GPU) ? "Integrated Graphics" : GPU)}");
            Console.WriteLine($"- Bluetooth: {(HasBluetooth ? "Yes" : "No")}\n");
        }

        public class Builder
        {
            public string CPU { get; private set; }
            public string RAM { get; private set; }
            public string Storage { get; private set; }

            public string? GPU { get; private set; }
            public bool HasBluetooth { get; private set; }

            public Builder(string cpu, string ram, string storage)
            {
                CPU = cpu;
                RAM = ram;
                Storage = storage;
            }

            public Builder SetGPU(string gpu)
            {
                GPU = gpu;
                return this;
            }

            public Builder SetBluetooth(bool hasBluetooth)
            {
                HasBluetooth = hasBluetooth;
                return this;
            }

            public Computer Build()
            {
                return new Computer(this);
            }
        }
    }
}