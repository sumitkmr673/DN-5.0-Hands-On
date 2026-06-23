EXEC AddEmployee 
    @EmployeeID = 101, @FirstName = 'Low', @LastName = 'Earner', 
    @Email = 'low@company.com', @Salary = 500, @DepartmentID = 1;

SELECT * FROM Employees WHERE EmployeeID = 101;
GO