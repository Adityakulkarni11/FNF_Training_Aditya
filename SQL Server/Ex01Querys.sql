create database FNFTraining
Go
use FNFTraining
Go
CREATE TABLE DeptTable (
    DeptId INT IDENTITY(1,1) PRIMARY KEY,
    DeptName VARCHAR(100) NOT NULL
)

Create table Employee(
	EmpId int primary key identity(1,1),
	EmpName nvarchar(50) not null,
	EmpAddress nvarchar(200) not null,
	EmpSalary money not null
)

insert into DeptTable values('R&D')
insert into DeptTable values('ADM')
insert into DeptTable values('Development')
insert into DeptTable values('Testing')
insert into DeptTable values('HR')

--drop table Employee
--drop table DeptTable

truncate table DeptTable--clear the rows of the table without altering the schema

select * from DeptTable
select * from Employee

insert into Employee values('Aditya','Bangalore',5230,1)
insert into Employee values('Rakesh','Hassan',53300,1)
insert into Employee values('Shashank','MG Road',65230,2)
insert into Employee values('Vishnu','Electronic City',22300,3)
insert into Employee values('Venky','KR Puram',32230,4)
insert into Employee values('Abhi','Gadag',12230,5)
--delete from Employee where EmpId=1 

--Add a new column into the Employee table
alter table Employee add DeptId int not null references DeptTable(DeptId)

--alter table Employee
--drop constraint FK__Employee__DeptId__2D27B809
--Go
--alter table Employee
--drop column DeptId
