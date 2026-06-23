CREATE TABLE Customers (
    CustomerID INT,
    CustomerName VARCHAR(50),
    Region VARCHAR(50)
);

CREATE TABLE Orders (
    OrderID INT,
    CustomerID INT
);

-- Notice ProductID is VARCHAR(10) to perfectly link with our Exercise 1 Products
CREATE TABLE OrderDetails (
    OrderID INT,
    ProductID VARCHAR(10),
    Quantity INT
);

INSERT INTO Customers VALUES 
(1, 'Aarav Sharma', 'North'),
(2, 'Priya Patel', 'South'),
(3, 'Vikram Singh', 'West');

INSERT INTO Orders VALUES 
(1001, 1), (1002, 2), (1003, 3), (1004, 1);

INSERT INTO OrderDetails VALUES 
(1001, 'PRD002', 2), -- OnePlus 12
(1001, 'PRD006', 1), -- Wakefit Mattress
(1002, 'PRD001', 1), -- Sony Bravia
(1003, 'PRD005', 4), -- Godrej Desk
(1004, 'PRD002', 3); -- OnePlus 12