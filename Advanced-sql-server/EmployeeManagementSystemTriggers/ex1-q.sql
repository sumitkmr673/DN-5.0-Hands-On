CREATE TABLE EmployeeChanges (
    LogID INT IDENTITY(1,1) PRIMARY KEY,
    EmployeeID INT,
    OldSalary DECIMAL(10,2),
    NewSalary DECIMAL(10,2),
    ChangeDate DATETIME DEFAULT GETDATE()
);
GO

CREATE TRIGGER trg_AfterSalaryUpdate
ON Employees
AFTER UPDATE
AS
BEGIN
    IF UPDATE(Salary)
    BEGIN
        INSERT INTO EmployeeChanges (EmployeeID, OldSalary, NewSalary)
        SELECT 
            i.EmployeeID, 
            d.Salary AS OldSalary, 
            i.Salary AS NewSalary
        FROM inserted i
        JOIN deleted d ON i.EmployeeID = d.EmployeeID;
    END
END;
GO