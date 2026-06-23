GO
CREATE PROCEDURE BatchInsertEmployees
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO Employees (EmployeeID, FirstName, LastName, Email, Salary, DepartmentID)
        VALUES (98, 'Alice', 'Wonder', 'alice@company.com', 5000, 1);
        
        INSERT INTO Employees (EmployeeID, FirstName, LastName, Email, Salary, DepartmentID)
        VALUES (99, 'Bob', 'Builder', 'bob@company.com', 6000, 1);

        COMMIT TRANSACTION;
        PRINT 'All batch inserts successful!';
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        
        INSERT INTO AuditLog (Action, ErrorMessage)
        VALUES ('BatchInsertEmployees', ERROR_MESSAGE());
        
        PRINT 'Batch failed and rolled back. Error logged.';
    END CATCH
END;
GO