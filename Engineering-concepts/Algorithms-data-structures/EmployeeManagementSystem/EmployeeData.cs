using System;

namespace EmployeeManagementSystem
{
    public class Employee
    {
        public string EmployeeId { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public double Salary { get; set; }

        public Employee(string id, string name, string position, double salary)
        {
            EmployeeId = id;
            Name = name;
            Position = position;
            Salary = salary;
        }
    }

    public class EmployeeManager
    {
        private Employee[] _employees;
        private int _count;

        public EmployeeManager(int capacity)
        {
            _employees = new Employee[capacity];
            _count = 0;
        }

        public void AddEmployee(Employee emp)
        {
            if (_count < _employees.Length)
            {
                _employees[_count] = emp;
                _count++;
                Console.WriteLine($"[Added] ID: {emp.EmployeeId} | Name: {emp.Name}");
            }
            else
            {
                Console.WriteLine($"[Error] Array is full. Cannot add {emp.Name}.");
            }
        }

        public Employee? SearchEmployee(string id)
        {
            for (int i = 0; i < _count; i++)
            {
                if (_employees[i].EmployeeId == id)
                {
                    return _employees[i];
                }
            }
            return null;
        }

        public void TraverseEmployees()
        {
            if (_count == 0)
            {
                Console.WriteLine("[Warning] No employee records found.");
                return;
            }

            for (int i = 0; i < _count; i++)
            {
                Console.WriteLine($"[Record] ID: {_employees[i].EmployeeId} | Name: {_employees[i].Name} | Position: {_employees[i].Position}");
            }
        }

        public void DeleteEmployee(string id)
        {
            int indexToDelete = -1;

            for (int i = 0; i < _count; i++)
            {
                if (_employees[i].EmployeeId == id)
                {
                    indexToDelete = i;
                    break;
                }
            }

            if (indexToDelete != -1)
            {
                string deletedName = _employees[indexToDelete].Name;

                for (int i = indexToDelete; i < _count - 1; i++)
                {
                    _employees[i] = _employees[i + 1];
                }

                _employees[_count - 1] = null!;
                _count--;

                Console.WriteLine($"[Deleted] Successfully removed {deletedName} (ID: {id}).");
            }
            else
            {
                Console.WriteLine($"[Error] Employee ID {id} not found.");
            }
        }
    }
}