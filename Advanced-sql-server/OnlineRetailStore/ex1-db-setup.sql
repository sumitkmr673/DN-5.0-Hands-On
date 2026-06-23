CREATE TABLE Products (
    ProductID VARCHAR(10),
    ProductName VARCHAR(100),
    Category VARCHAR(50),
    Price DECIMAL(10,2)
);

INSERT INTO Products (ProductID, ProductName, Category, Price)
VALUES 
('PRD001', 'Sony Bravia 4K TV', 'Electronics', 85000.00),
('PRD002', 'OnePlus 12', 'Electronics', 65000.00),
('PRD003', 'Samsung Galaxy S24', 'Electronics', 65000.00),
('PRD004', 'boAt Airdopes 141', 'Electronics', 1500.00),
('PRD005', 'Godrej Interio Desk', 'Furniture', 12500.00),
('PRD006', 'Wakefit Orthopedic Mattress', 'Furniture', 12500.00),
('PRD007', 'Nilkamal Plastic Chair', 'Furniture', 850.00),
('PRD008', 'Pepperfry Bookshelf', 'Furniture', 4500.00);