EXEC TransferEmployee @EmployeeID = 1, @NewDepartmentID = 999;

SELECT * FROM AuditLog;
GO