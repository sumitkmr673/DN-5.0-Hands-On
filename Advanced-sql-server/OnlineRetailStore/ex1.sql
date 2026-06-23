WITH RankedProducts AS (
    SELECT 
        ProductID,
        ProductName,
        Category,
        Price,
        ROW_NUMBER() OVER(PARTITION BY Category ORDER BY Price DESC) AS RowNum,
        RANK() OVER(PARTITION BY Category ORDER BY Price DESC) AS RankNum,
        DENSE_RANK() OVER(PARTITION BY Category ORDER BY Price DESC) AS DenseRankNum
    FROM Products
)
SELECT 
    ProductID,
    ProductName,
    Category,
    Price,
    RowNum,
    RankNum,
    DenseRankNum
FROM RankedProducts
WHERE RowNum <= 3;