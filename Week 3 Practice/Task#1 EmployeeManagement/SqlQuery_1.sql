
USE master;
GO


IF DB_ID('EmployeeManagementDb') IS NOT NULL
BEGIN
    ALTER DATABASE EmployeeManagementDb
    SET SINGLE_USER
    WITH ROLLBACK IMMEDIATE;

    DROP DATABASE EmployeeManagementDb;
END
GO
--createdb
CREATE DATABASE EmployeeManagementDb;
GO

USE EmployeeManagementDb;
GO

CREATE TABLE Departments
(
    DepartmentId INT PRIMARY KEY IDENTITY(1,1),
    DepartmentName VARCHAR(50) NOT NULL
);
GO


CREATE TABLE Employees
(
    EmployeeId INT PRIMARY KEY IDENTITY(1,1),
    EmployeeName VARCHAR(100) NOT NULL,
    Gender VARCHAR(10),
    Age INT,
    Salary DECIMAL(10,2),
    DepartmentId INT,
    HireDate DATE,
    City VARCHAR(50),

    FOREIGN KEY (DepartmentId)
        REFERENCES Departments(DepartmentId)
);
GO

INSERT INTO Departments (DepartmentName)
VALUES
('IT'),
('HR'),
('Finance'),
('Marketing'),
('Sales');
GO

INSERT INTO Employees
(
    EmployeeName,
    Gender,
    Age,
    Salary,
    DepartmentId,
    HireDate,
    City
)
VALUES
('Ali Khan', 'Male', 25, 55000, 1, '2023-01-15', 'Lahore'),
('Ahmed Raza', 'Male', 30, 75000, 1, '2022-05-20', 'Islamabad'),
('Sara Ahmed', 'Female', 28, 65000, 2, '2023-03-10', 'Lahore'),
('Ayesha Malik', 'Female', 32, 85000, 2, '2021-08-12', 'Karachi'),
('Usman Ali', 'Male', 27, 60000, 3, '2024-01-05', 'Lahore'),
('Hassan Shah', 'Male', 35, 95000, 3, '2020-06-18', 'Islamabad'),
('Fatima Noor', 'Female', 26, 58000, 4, '2024-02-14', 'Karachi'),
('Zain Ahmed', 'Male', 29, 70000, 4, '2022-11-25', 'Lahore'),
('Hamza Iqbal', 'Male', 24, 50000, 5, '2024-04-01', 'Rawalpindi'),
('Maham Khan', 'Female', 31, 80000, 5, '2021-09-30', 'Islamabad');
GO


SELECT *
FROM Employees;
GO

SELECT *
FROM Employees
WHERE Salary > 70000;
GO


SELECT *
FROM Employees
WHERE City = 'Lahore';
GO



SELECT *
FROM Employees
WHERE Gender = 'Female';
GO


SELECT *
FROM Employees
WHERE Age BETWEEN 25 AND 30;
GO



SELECT
    Employees.EmployeeId,
    Employees.EmployeeName,
    Employees.Salary,
    Departments.DepartmentName
FROM Employees
INNER JOIN Departments
    ON Employees.DepartmentId = Departments.DepartmentId;
GO

SELECT
    Employees.EmployeeName,
    Employees.Salary,
    Departments.DepartmentName
FROM Employees
INNER JOIN Departments
    ON Employees.DepartmentId = Departments.DepartmentId
WHERE Departments.DepartmentName = 'IT';
GO

SELECT
    EmployeeName,
    Salary
FROM Employees
WHERE Salary >= 60000
ORDER BY Salary DESC;
GO


SELECT
    EmployeeName,
    HireDate
FROM Employees
WHERE HireDate > '2022-12-31'
ORDER BY HireDate;
GO


SELECT
    Departments.DepartmentName,
    AVG(Employees.Salary) AS AverageSalary
FROM Employees
INNER JOIN Departments
    ON Employees.DepartmentId = Departments.DepartmentId
GROUP BY Departments.DepartmentName;
GO

SELECT
    'Departments' AS TableName,
    COUNT(*) AS TotalRecords
FROM Departments

UNION ALL

SELECT
    'Employees' AS TableName,
    COUNT(*) AS TotalRecords
FROM Employees;
GO