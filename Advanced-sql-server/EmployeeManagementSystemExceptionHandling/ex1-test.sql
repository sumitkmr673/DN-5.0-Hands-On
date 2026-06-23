EXEC AddEmployee 
    @EmployeeID = 1, @FirstName = 'Normal', @LastName = 'Guy', 
    @Email = 'normal@company.com', @Salary = 5000, @DepartmentID = 1;

EXEC AddEmployee 
    @EmployeeID = 2, @FirstName = 'Duplicate', @LastName = 'Emailer', 
    @Email = 'normal@company.com', @Salary = 6000, @DepartmentID = 1;

SELECT * FROM AuditLog;