SELECT 
    EmployeeID,
    FirstName,
    LastName,
    Salary AS MonthlySalary,
    dbo.fn_CalculateAnnualSalary(Salary) AS CalculatedAnnualSalary
FROM Employees;
GO