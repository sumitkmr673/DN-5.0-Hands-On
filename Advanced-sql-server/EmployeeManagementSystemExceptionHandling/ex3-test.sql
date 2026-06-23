EXEC AddEmployee 
    @EmployeeID = 100, @FirstName = 'Negative', @LastName = 'Earner', 
    @Email = 'neg@company.com', @Salary = -500, @DepartmentID = 1;

SELECT * FROM AuditLog;
GO