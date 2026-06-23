GO
ALTER PROCEDURE AddEmployee
    @EmployeeID INT,
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @Email VARCHAR(100),
    @Salary DECIMAL(10, 2),
    @DepartmentID INT
AS
BEGIN
    BEGIN TRY
        IF @Salary < 0
        BEGIN
            RAISERROR('Error: Salary cannot be negative.', 16, 1);
        END
        
        IF @Salary < 1000 AND @Salary >= 0
        BEGIN
            RAISERROR('Warning: Salary is suspiciously low (Under 1000).', 10, 1);
        END

        INSERT INTO Employees (EmployeeID, FirstName, LastName, Email, Salary, DepartmentID)
        VALUES (@EmployeeID, @FirstName, @LastName, @Email, @Salary, @DepartmentID);
    END TRY
    BEGIN CATCH
        INSERT INTO AuditLog (Action, ErrorMessage)
        VALUES ('AddEmployee Dynamic Logic', ERROR_MESSAGE());
        
        ;THROW;
    END CATCH
END;
GO