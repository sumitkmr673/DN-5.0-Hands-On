GO
CREATE FUNCTION fn_GetEmployeesByDepartment (
    @DepartmentID INT
)
RETURNS TABLE
AS
RETURN (
    SELECT 
        EmployeeID, 
        FirstName, 
        LastName, 
        DepartmentID, 
        Salary, 
        JoinDate
    FROM Employees
    WHERE DepartmentID = @DepartmentID
);
GO

SELECT * FROM dbo.fn_GetEmployeesByDepartment(2);
GO