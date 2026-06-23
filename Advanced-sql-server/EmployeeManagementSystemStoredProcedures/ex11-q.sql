GO
CREATE PROCEDURE sp_UpdateSalaryWithErrorHandling
    @EmployeeID INT,
    @NewSalary DECIMAL(10,2)
AS
BEGIN
    BEGIN TRY
        
        IF @NewSalary < 0
            THROW 50000, 'Custom Error: Salary cannot be a negative number!', 1;

        UPDATE Employees
        SET Salary = @NewSalary
        WHERE EmployeeID = @EmployeeID;
        
        PRINT 'Salary updated successfully.';
    END TRY
    BEGIN CATCH
        
        SELECT 
            ERROR_NUMBER() AS ErrorCode,
            ERROR_MESSAGE() AS SystemMessage;
    END CATCH
END;
GO

EXEC sp_UpdateSalaryWithErrorHandling @EmployeeID = 1, @NewSalary = -500.00;
GO