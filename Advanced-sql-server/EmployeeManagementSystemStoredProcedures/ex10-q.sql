GO
CREATE PROCEDURE sp_DynamicEmployeeSearch
    @FilterColumn NVARCHAR(100),
    @FilterValue NVARCHAR(100)
AS
BEGIN
    DECLARE @SQLQuery NVARCHAR(MAX); 
    
    SET @SQLQuery = N'SELECT * FROM Employees WHERE ' + QUOTENAME(@FilterColumn) + N' = @Value';

    EXEC sp_executesql 
        @stmt = @SQLQuery, 
        @params = N'@Value NVARCHAR(100)', 
        @Value = @FilterValue;
END;
GO

EXEC sp_DynamicEmployeeSearch @FilterColumn = 'LastName', @FilterValue = 'Doe';
GO