CREATE TABLE StagingProducts (
    ProductID VARCHAR(10) PRIMARY KEY,
    ProductName VARCHAR(100),
    Price DECIMAL(10,2)
);

INSERT INTO StagingProducts (ProductID, ProductName, Price)
VALUES 
('PRD002', 'OnePlus 12', 62000.00),
('PRD009', 'Apple iPad Air', 55000.00);