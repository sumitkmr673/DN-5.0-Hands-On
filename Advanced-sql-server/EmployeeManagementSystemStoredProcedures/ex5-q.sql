GO
CREATE PROCEDURE sp_CountEmployeesByDept
    @DepartmentID INT
AS
BEGIN
    SELECT COUNT(*) AS TotalEmployees
    FROM Employees
    WHERE DepartmentID = @DepartmentID;
END;
GO

EXEC sp_CountEmployeesByDept @DepartmentID = 2;