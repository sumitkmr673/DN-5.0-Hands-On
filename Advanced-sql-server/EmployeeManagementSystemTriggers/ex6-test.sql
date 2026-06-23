UPDATE Employees 
SET Salary = 6500.00 
WHERE EmployeeID = 2;

SELECT EmployeeID, FirstName, Salary AS NewMonthly, AnnualSalary 
FROM Employees 
WHERE EmployeeID = 2;
GO