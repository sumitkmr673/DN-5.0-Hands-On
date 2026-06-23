MERGE Products AS Target
USING StagingProducts AS Source
ON Source.ProductID = Target.ProductID

WHEN MATCHED THEN
    UPDATE SET 
        Target.Price = Source.Price, 
        Target.ProductName = Source.ProductName

WHEN NOT MATCHED BY TARGET THEN
    INSERT (ProductID, ProductName, Category, Price) 
    VALUES (Source.ProductID, Source.ProductName, 'Electronics', Source.Price);

SELECT * FROM Products;