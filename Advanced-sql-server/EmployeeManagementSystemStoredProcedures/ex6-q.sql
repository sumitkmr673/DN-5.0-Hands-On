GO
CREATE PROCEDURE sp_GetTotalSalaryByDept
    @DepartmentID INT,
    @TotalSalary DECIMAL(10,2) OUTPUT
AS
BEGIN
    SELECT @TotalSalary = SUM(Salary)
    FROM Employees
    WHERE DepartmentID = @DepartmentID;
END;
GO

DECLARE @Result DECIMAL(10,2);
EXEC sp_GetTotalSalaryByDept @DepartmentID = 2, @TotalSalary = @Result OUTPUT;
SELECT @Result AS TotalFinanceSalary;
GO