using System;

namespace EmployeeManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Employee Management System ---\n");

            EmployeeManager manager = new EmployeeManager(5);

            manager.AddEmployee(new Employee("EMP101", "Aarav Sharma", "Software Engineer", 850000));
            manager.AddEmployee(new Employee("EMP102", "Priya Patel", "Data Analyst", 750000));
            manager.AddEmployee(new Employee("EMP103", "Rohan Verma", "Product Manager", 1200000));

            Console.WriteLine("\nExecuting Traversal:");
            manager.TraverseEmployees();

            Console.WriteLine("\nExecuting Search for Target ID: EMP102...");
            Employee? foundEmp = manager.SearchEmployee("EMP102");
            if (foundEmp != null)
            {
                Console.WriteLine($"[Search Match] Found {foundEmp.Name}, earning ₹{foundEmp.Salary}/year.");
            }

            Console.WriteLine("\nExecuting Deletion for Target ID: EMP102...");
            manager.DeleteEmployee("EMP102");

            Console.WriteLine("\nExecuting Traversal After Deletion:");
            manager.TraverseEmployees();
        }
    }
}