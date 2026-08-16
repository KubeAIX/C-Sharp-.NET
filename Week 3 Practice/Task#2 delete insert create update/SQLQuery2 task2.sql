USE EmployeeManagementDb;
GO

--insert one new employee
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
(
    'Abdul Ahad',
    'Male',
    23,
    62000,
    1,
    '2025-01-10',
    'Lahore'
);
GO

-- Display all employees
SELECT *
FROM Employees;
GO

-- Display selected columns
SELECT
    EmployeeId,
    EmployeeName,
    Salary,
    City
FROM Employees;
GO

-- Employees with salary greater than 70000
SELECT *
FROM Employees
WHERE Salary > 70000;
GO

-- Employees from Lahore
SELECT *
FROM Employees
WHERE City = 'Lahore';
GO

-- Employees younger than 30
SELECT *
FROM Employees
WHERE Age < 30;
GO
-- Names starting with A
SELECT *
FROM Employees
WHERE EmployeeName LIKE 'A%';
GO

-- Names ending with Khan
SELECT *
FROM Employees
WHERE EmployeeName LIKE '%Khan';
GO

-- Names containing Ahmed
SELECT *
FROM Employees
WHERE EmployeeName LIKE '%Ahmed%';
GO

-- Employees from Lahore, Islamabad or Karachi
SELECT *
FROM Employees
WHERE City IN ('Lahore', 'Islamabad', 'Karachi');
GO

-- Employees belonging to IT, HR or Finance
SELECT
    EmployeeName,
    DepartmentId,
    Salary
FROM Employees
WHERE DepartmentId IN (1, 2, 3);
GO
-- Employees between age 25 and 30
SELECT *
FROM Employees
WHERE Age BETWEEN 25 AND 30;
GO

-- Employees with salary between 60000 and 80000
SELECT *
FROM Employees
WHERE Salary BETWEEN 60000 AND 80000;
GO
-- Increase Ali Khan's salary
UPDATE Employees
SET Salary = 60000
WHERE EmployeeName = 'Ali Khan';
GO

-- Change Bilal Ahmed's city
UPDATE Employees
SET City = 'Islamabad'
WHERE EmployeeName = 'Bilal Ahmed';
GO

-- Verify updated data
SELECT *
FROM Employees
WHERE EmployeeName IN ('Ali Khan', 'Bilal Ahmed');
GO
-- Delete Bilal Ahmed
DELETE FROM Employees
WHERE EmployeeName = 'Bilal Ahmed';
GO

-- Verify deletion
SELECT *
FROM Employees;
GO
-- COUNT: Total employees
SELECT COUNT(*) AS TotalEmployees
FROM Employees;
GO

-- SUM: Total salary
SELECT SUM(Salary) AS TotalSalary
FROM Employees;
GO

-- AVG: Average salary
SELECT AVG(Salary) AS AverageSalary
FROM Employees;
GO

-- MAX: Highest salary
SELECT MAX(Salary) AS HighestSalary
FROM Employees;
GO

-- MIN: Lowest salary
SELECT MIN(Salary) AS LowestSalary
FROM Employees;
GO
SELECT
    DepartmentId,
    COUNT(*) AS TotalEmployees,
    SUM(Salary) AS TotalSalary,
    AVG(Salary) AS AverageSalary,
    MAX(Salary) AS HighestSalary,
    MIN(Salary) AS LowestSalary
FROM Employees
GROUP BY DepartmentId;
GO
-- Employees whose names start with A
-- and salary is between 60000 and 90000
SELECT
    EmployeeName,
    Salary,
    City
FROM Employees
WHERE EmployeeName LIKE 'A%'
AND Salary BETWEEN 60000 AND 90000;
GO
SELECT
    Departments.DepartmentName,
    COUNT(Employees.EmployeeId) AS TotalEmployees,
    AVG(Employees.Salary) AS AverageSalary,
    MAX(Employees.Salary) AS HighestSalary,
    MIN(Employees.Salary) AS LowestSalary
FROM Departments
LEFT JOIN Employees
    ON Departments.DepartmentId = Employees.DepartmentId
GROUP BY Departments.DepartmentName;
GO