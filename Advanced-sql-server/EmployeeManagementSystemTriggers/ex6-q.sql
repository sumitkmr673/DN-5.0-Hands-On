GO
CREATE TRIGGER trg_UpdateAnnualSalary
ON Employees
AFTER UPDATE
AS
BEGIN
    IF UPDATE(Salary)
    BEGIN
        UPDATE e
        SET e.AnnualSalary = i.Salary * 12
        FROM Employees e
        INNER JOIN inserted i ON e.EmployeeID = i.EmployeeID;
    END
END;
GO