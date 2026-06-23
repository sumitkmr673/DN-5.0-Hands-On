WITH CustomerOrderCounts AS (
    SELECT 
        CustomerID, 
        COUNT(OrderID) AS TotalOrders
    FROM Orders
    GROUP BY CustomerID
)

SELECT 
    c.CustomerName, 
    coc.TotalOrders
FROM Customers c
JOIN CustomerOrderCounts coc ON c.CustomerID = coc.CustomerID
WHERE coc.TotalOrders > 3;