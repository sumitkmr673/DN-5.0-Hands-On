-- =================================================================
-- Steps 1 & 2: Retrieve employee details by DepartmentID
-- =================================================================
GO
CREATE PROCEDURE sp_GetEmployeesByDept
    @DepartmentID INT
AS
BEGIN
    SELECT * FROM Employees 
    WHERE DepartmentID = @DepartmentID;
END;
GO

-- =================================================================
-- Step 3: Create the sp_InsertEmployee procedure
-- =================================================================
GO
CREATE PROCEDURE sp_InsertEmployee
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @DepartmentID INT,
    @Salary DECIMAL(10,2),
    @JoinDate DATE
AS
BEGIN
    INSERT INTO Employees (FirstName, LastName, DepartmentID, Salary, JoinDate)
    VALUES (@FirstName, @LastName, @DepartmentID, @Salary, @JoinDate);
END;
GO