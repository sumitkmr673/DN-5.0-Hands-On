GO
CREATE PROCEDURE TransferEmployee
    @EmployeeID INT,
    @NewDepartmentID INT
AS
BEGIN
    BEGIN TRY
        BEGIN TRY
            IF NOT EXISTS (SELECT 1 FROM Departments WHERE DepartmentID = @NewDepartmentID)
            BEGIN
                RAISERROR('Custom Error: Department does not exist.', 16, 1);
            END
            
            UPDATE Employees 
            SET DepartmentID = @NewDepartmentID 
            WHERE EmployeeID = @EmployeeID;
        END TRY
        BEGIN CATCH
            INSERT INTO AuditLog (Action, ErrorMessage)
            VALUES ('Transfer Validation', ERROR_MESSAGE());
            
            ;THROW; 
        END CATCH
    END TRY
    BEGIN CATCH
        PRINT 'Outer block caught an error! Propagating to application...';
        ;THROW;
    END CATCH
END;
GO