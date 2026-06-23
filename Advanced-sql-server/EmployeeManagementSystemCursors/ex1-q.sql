DECLARE @EmpID INT, @FirstName VARCHAR(50), @LastName VARCHAR(50), @Salary DECIMAL(10,2);

DECLARE emp_cursor CURSOR FOR
SELECT EmployeeID, FirstName, LastName, Salary FROM Employees;

OPEN emp_cursor;

FETCH NEXT FROM emp_cursor INTO @EmpID, @FirstName, @LastName, @Salary;

WHILE @@FETCH_STATUS = 0
BEGIN
    PRINT 'Employee ID: ' + CAST(@EmpID AS VARCHAR) + 
          ' | Name: ' + @FirstName + ' ' + @LastName + 
          ' | Salary: $' + CAST(@Salary AS VARCHAR);

    FETCH NEXT FROM emp_cursor INTO @EmpID, @FirstName, @LastName, @Salary;
END;

-- Close and deallocate the cursor
CLOSE emp_cursor;
DEALLOCATE emp_cursor;
GO