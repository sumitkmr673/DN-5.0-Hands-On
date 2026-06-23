using System;

namespace DependencyInjectionExample
{
    public class Customer
    {
        public string AadhaarNumber { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
    }

    public interface ICustomerRepository
    {
        Customer? FindCustomerById(string id);
    }

    public class CustomerRepositoryImpl : ICustomerRepository
    {
        public Customer? FindCustomerById(string id)
        {
            if (id == "8472-9102-3847")
            {
                return new Customer
                {
                    AadhaarNumber = "8472-9102-3847",
                    Name = "Priya Patel",
                    City = "Ahmedabad"
                };
            }
            return null;
        }
    }

    public class CustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public void DisplayCustomerInfo(string id)
        {
            Customer? customer = _repository.FindCustomerById(id);

            if (customer != null)
            {
                Console.WriteLine($"Customer Found: {customer.Name} from {customer.City} (Aadhaar: {customer.AadhaarNumber})");
            }
            else
            {
                Console.WriteLine($"Customer with ID {id} not found in the system.");
            }
        }
    }
}