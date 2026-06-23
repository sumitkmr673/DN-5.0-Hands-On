-- Steps 1, 2 & 3: Open, modify, and save the stored procedure
GO
ALTER PROCEDURE sp_GetEmployeesByDept
    @DepartmentID INT
AS
BEGIN
    SELECT 
        EmployeeID,
        FirstName,
        LastName,
        DepartmentID,
        Salary          -- Added Salary column
    FROM Employees 
    WHERE DepartmentID = @DepartmentID;
END;
GO