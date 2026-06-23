GO
CREATE PROCEDURE AddEmployee
    @EmployeeID INT,
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @Email VARCHAR(100),
    @Salary DECIMAL(10, 2),
    @DepartmentID INT
AS
BEGIN
    BEGIN TRY
        INSERT INTO Employees (EmployeeID, FirstName, LastName, Email, Salary, DepartmentID)
        VALUES (@EmployeeID, @FirstName, @LastName, @Email, @Salary, @DepartmentID);
        
        PRINT 'Employee added successfully!';
    END TRY
    BEGIN CATCH
        INSERT INTO AuditLog (Action, ErrorMessage)
        VALUES ('AddEmployee Insert', ERROR_MESSAGE());
    END CATCH
END;
GO