-- Using PIVOT
SELECT ProductName, [Jan], [Feb], [Mar]
INTO #PivotedSales
FROM (
    SELECT ProductName, OrderMonth, Quantity
    FROM ProductSales
) AS SourceTable
PIVOT (
    SUM(Quantity)
    FOR OrderMonth IN ([Jan], [Feb], [Mar])
) AS PivotTable;

SELECT * FROM #PivotedSales;

-- Using UNPIVOT
SELECT ProductName, OrderMonth, Quantity
FROM #PivotedSales
UNPIVOT (
    Quantity
    FOR OrderMonth IN ([Jan], [Feb], [Mar])
) AS UnpivotTable;