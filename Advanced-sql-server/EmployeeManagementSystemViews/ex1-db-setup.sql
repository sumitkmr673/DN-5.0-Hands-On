CREATE TABLE Departments (
    DepartmentID INT PRIMARY KEY,
    DepartmentName VARCHAR(100)
);

CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    DepartmentID INT FOREIGN KEY REFERENCES Departments (DepartmentID),
    Salary DECIMAL(10, 2),
    JoinDate DATE
);

INSERT INTO Departments (DepartmentID, DepartmentName) VALUES
(1, 'Human Resources'),
(2, 'Engineering'),
(3, 'Sales');

INSERT INTO Employees (EmployeeID, FirstName, LastName, DepartmentID, Salary, JoinDate) VALUES
(101, 'Aarav', 'Sharma', 2, 85000.00, '2021-03-15'),
(102, 'Priya', 'Patel', 1, 65000.00, '2022-06-01'),
(103, 'Vikram', 'Singh', 2, 90000.00, '2020-11-20'),
(104, 'Neha', 'Gupta', 3, 55000.00, '2023-01-10');
GO