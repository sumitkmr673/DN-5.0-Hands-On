EXEC AddEmployee 
    @EmployeeID = 99, @FirstName = 'Another', @LastName = 'Clone', 
    @Email = 'normal@company.com', @Salary = 6000, @DepartmentID = 1;

SELECT * FROM AuditLog;
GO