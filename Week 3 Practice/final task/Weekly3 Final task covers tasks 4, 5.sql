
use master;
go

if exists (select * from sys.databases
           where name = 'employee_management')
begin
    alter database employee_management
    set single_user
    with rollback immediate;

    drop database employee_management;
end;
go


-- create new database
create database employee_management;
go

use employee_management;
go


-- departments

create table departments (
    department_id int identity(1,1) primary key,
    department_name varchar(50)
);
go


-- roles

create table roles (
    role_id int identity(1,1) primary key,
    role_name varchar(50)
);
go


-- employees

create table employees (
    employee_id int identity(1,1) primary key,
    employee_name varchar(100),
    email varchar(100),
    department_id int,
    role_id int,

    foreign key (department_id)
        references departments(department_id),

    foreign key (role_id)
        references roles(role_id)
);
go


-- attendance

create table attendance (
    attendance_id int identity(1,1) primary key,
    employee_id int,
    attendance_date date,
    status varchar(20),

    foreign key (employee_id)
        references employees(employee_id)
);
go


-- salaries

create table salaries (
    salary_id int identity(1,1) primary key,
    employee_id int,
    salary decimal(10,2),
    salary_date date,

    foreign key (employee_id)
        references employees(employee_id)
);
go


-- departments data

insert into departments (department_name)
values
('hr'),
('it'),
('finance');
go


-- roles data

insert into roles (role_name)
values
('manager'),
('developer'),
('accountant');
go


-- employees data

insert into employees
(employee_name, email, department_id, role_id)
values
('ahad', 'ahad@gmail.com', 2, 2),
('ali', 'ali@gmail.com', 1, 1);
go


-- attendance data

insert into attendance
(employee_id, attendance_date, status)
values
(1, '2026-08-17', 'present'),
(2, '2026-08-17', 'absent');
go


insert into salaries
(employee_id, salary, salary_date)
values
(1, 80000, '2026-08-01'),
(2, 60000, '2026-08-01');
go

create procedure add_employee
    @name varchar(100),
    @email varchar(100),
    @department_id int,
    @role_id int
as
begin
    insert into employees
    (employee_name, email, department_id, role_id)
    values
    (@name, @email, @department_id, @role_id);
end;
go


create procedure get_employees
as
begin
    select * from employees;
end;
go


create procedure update_employee
    @id int,
    @name varchar(100),
    @email varchar(100)
as
begin
    update employees
    set employee_name = @name,
        email = @email
    where employee_id = @id;
end;
go


create procedure delete_employee
    @id int
as
begin
    delete from employees
    where employee_id = @id;
end;
go


create procedure add_attendance
    @employee_id int,
    @attendance_date date,
    @status varchar(20)
as
begin
    insert into attendance
    (employee_id, attendance_date, status)
    values
    (@employee_id, @attendance_date, @status);
end;
go


create procedure get_attendance
as
begin
    select * from attendance;
end;
go


create procedure update_attendance
    @id int,
    @status varchar(20)
as
begin
    update attendance
    set status = @status
    where attendance_id = @id;
end;
go


create procedure delete_attendance
    @id int
as
begin
    delete from attendance
    where attendance_id = @id;
end;
go

create procedure add_salary
    @employee_id int,
    @salary decimal(10,2),
    @salary_date date
as
begin
    insert into salaries
    (employee_id, salary, salary_date)
    values
    (@employee_id, @salary, @salary_date);
end;
go


create procedure get_salaries
as
begin
    select * from salaries;
end;
go


create procedure update_salary
    @id int,
    @salary decimal(10,2)
as
begin
    update salaries
    set salary = @salary
    where salary_id = @id;
end;
go


create procedure delete_salary
    @id int
as
begin
    delete from salaries
    where salary_id = @id;
end;
go
exec add_employee
    'usman',
    'usman@gmail.com',
    2,
    2;
go

exec get_employees;
go

exec get_attendance;
go

exec get_salaries;
go