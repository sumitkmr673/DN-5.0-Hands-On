GO
CREATE TRIGGER trg_PreventEmployeeDeletion
ON Employees
INSTEAD OF DELETE
AS
BEGIN
    ;THROW 50000, 'Security Alert: Deletion of employee records is strictly prohibited!', 1;
END;
GO