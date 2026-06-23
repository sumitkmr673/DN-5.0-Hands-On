using System;

namespace DependencyInjectionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Testing Dependency Injection ---\n");

            ICustomerRepository repository = new CustomerRepositoryImpl();

            CustomerService service = new CustomerService(repository);

            Console.WriteLine("Client: Searching for a valid customer...");
            service.DisplayCustomerInfo("8472-9102-3847");

            Console.WriteLine("\n-----------------------------------\n");

            Console.WriteLine("Client: Searching for an invalid customer...");
            service.DisplayCustomerInfo("0000-0000-0000");
        }
    }
}