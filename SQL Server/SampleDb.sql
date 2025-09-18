--create database SampleDB

use SampleDb

Create table Employee(
	Id int primary key,
	EmpName nvarchar(50) not null,
	EmpAddress nvarchar(200) not null,
	EmpSalary money not null
)

--drop table Employee/SampleDb
--sp_databases--to know currently available databases
--GO command executes a batch of statements upto this point from the previous GO. 
select * from Employee


