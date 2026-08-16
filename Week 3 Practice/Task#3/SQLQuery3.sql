USE master;
GO

IF DB_ID('EmployeeManagement') IS NOT NULL
BEGIN
    ALTER DATABASE EmployeeManagement
    SET SINGLE_USER
    WITH ROLLBACK IMMEDIATE;

    DROP DATABASE EmployeeManagement;
END;
GO

CREATE DATABASE EmployeeManagement;
GO

USE EmployeeManagement;
GO

CREATE TABLE departments
(
    department_id INT PRIMARY KEY,
    department_name VARCHAR(50) NOT NULL
);
GO

CREATE TABLE roles
(
    role_id INT PRIMARY KEY,
    role_name VARCHAR(50) NOT NULL
);
GO


CREATE TABLE employees
(
    employee_id INT PRIMARY KEY,
    employee_name VARCHAR(100) NOT NULL,
    department_id INT,
    role_id INT,

    FOREIGN KEY (department_id)
        REFERENCES departments(department_id),

    FOREIGN KEY (role_id)
        REFERENCES roles(role_id)
);
GO


CREATE TABLE attendance
(
    attendance_id INT PRIMARY KEY,
    employee_id INT,
    attendance_date DATE,
    status VARCHAR(20),

    FOREIGN KEY (employee_id)
        REFERENCES employees(employee_id)
);
GO


INSERT INTO departments
(
    department_id,
    department_name
)
VALUES
(1, 'IT'),
(2, 'HR'),
(3, 'Finance');
GO


INSERT INTO roles
(
    role_id,
    role_name
)
VALUES
(1, 'Developer'),
(2, 'Manager'),
(3, 'Accountant');
GO

INSERT INTO employees
(
    employee_id,
    employee_name,
    department_id,
    role_id
)
VALUES
(1, 'Ali', 1, 1),
(2, 'Ahmed', 1, 2),
(3, 'Sara', 2, 2),
(4, 'Ayesha', 2, 1),
(5, 'Usman', 3, 3);
GO

INSERT INTO attendance
(
    attendance_id,
    employee_id,
    attendance_date,
    status
)
VALUES
(1, 1, '2026-08-01', 'Present'),
(2, 1, '2026-08-02', 'Absent'),

(3, 2, '2026-08-01', 'Present'),
(4, 2, '2026-08-02', 'Late'),

(5, 3, '2026-08-01', 'Present'),
(6, 3, '2026-08-02', 'Present'),

(7, 4, '2026-08-01', 'Absent'),
(8, 4, '2026-08-02', 'Present'),

(9, 5, '2026-08-01', 'Present'),
(10, 5, '2026-08-02', 'Late');
GO

SELECT *
FROM departments;
GO

SELECT *
FROM roles;
GO

SELECT *
FROM employees;
GO

SELECT *
FROM attendance;
GO


SELECT
    e.employee_id,
    e.employee_name,
    d.department_name,
    r.role_name
FROM employees AS e

INNER JOIN departments AS d
    ON e.department_id = d.department_id

INNER JOIN roles AS r
    ON e.role_id = r.role_id

ORDER BY e.employee_id;
GO

SELECT
    e.employee_id,
    e.employee_name,
    d.department_name,
    r.role_name,
    a.attendance_date,
    a.status
FROM employees AS e

INNER JOIN departments AS d
    ON e.department_id = d.department_id

INNER JOIN roles AS r
    ON e.role_id = r.role_id

INNER JOIN attendance AS a
    ON e.employee_id = a.employee_id

ORDER BY e.employee_id, a.attendance_date;
GO
SELECT
    e.employee_name,
    d.department_name,
    r.role_name,
    a.attendance_date,
    a.status
FROM employees AS e

INNER JOIN departments AS d
    ON e.department_id = d.department_id

INNER JOIN roles AS r
    ON e.role_id = r.role_id

INNER JOIN attendance AS a
    ON e.employee_id = a.employee_id

WHERE a.status = 'Present'

ORDER BY e.employee_name;
GO


SELECT
    e.employee_name,
    d.department_name,
    r.role_name,
    a.attendance_date,
    a.status
FROM employees AS e

INNER JOIN departments AS d
    ON e.department_id = d.department_id

INNER JOIN roles AS r
    ON e.role_id = r.role_id

INNER JOIN attendance AS a
    ON e.employee_id = a.employee_id

WHERE a.status = 'Absent'

ORDER BY e.employee_name;
GO

SELECT
    e.employee_name,

    COUNT(CASE
        WHEN a.status = 'Present' THEN 1
    END) AS PresentDays,

    COUNT(CASE
        WHEN a.status = 'Absent' THEN 1
    END) AS AbsentDays,

    COUNT(CASE
        WHEN a.status = 'Late' THEN 1
    END) AS LateDays

FROM employees AS e

INNER JOIN attendance AS a
    ON e.employee_id = a.employee_id

GROUP BY
    e.employee_id,
    e.employee_name

ORDER BY e.employee_name;
GO

SELECT
    d.department_name,
    COUNT(e.employee_id) AS TotalEmployees

FROM departments AS d

LEFT JOIN employees AS e
    ON d.department_id = e.department_id

GROUP BY
    d.department_id,
    d.department_name

ORDER BY d.department_name;
GO

SELECT
    e.employee_id,
    e.employee_name,
    d.department_name,
    r.role_name,

    COUNT(a.attendance_id) AS TotalAttendance,

    COUNT(CASE
        WHEN a.status = 'Present' THEN 1
    END) AS PresentDays,

    COUNT(CASE
        WHEN a.status = 'Absent' THEN 1
    END) AS AbsentDays,

    COUNT(CASE
        WHEN a.status = 'Late' THEN 1
    END) AS LateDays

FROM employees AS e

INNER JOIN departments AS d
    ON e.department_id = d.department_id

INNER JOIN roles AS r
    ON e.role_id = r.role_id

LEFT JOIN attendance AS a
    ON e.employee_id = a.employee_id

GROUP BY
    e.employee_id,
    e.employee_name,
    d.department_name,
    r.role_name

ORDER BY e.employee_id;
GO