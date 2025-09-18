--------------------STORED PROCEDURES-------------------

create procedure InsertEmp(
	@name nvarchar(50),
	@address nvarchar(50),
	@salary money,
	@deptId int
)
As
insert into Employee values(@name,@address,@salary,@deptId)

EXEC	[dbo].[InsertEmp]
		@name = N'Rohan',
		@address = N'Pune',
		@salary = 46000,
		@deptId = 4

EXEC	[dbo].[InsertEmp]
		@name = N'Harsha',
		@address = N'Yadgir',
		@salary = 6000,
		@deptId = 4

---------------------------------------Update Proc----------------------
create procedure updateEmp(
	@empId int,
	@name nvarchar(50),
	@address nvarchar(50),
	@salary money,
	@deptId int
)
AS
update Employee set EmpName=@name, EmpAddress=@address, EmpSalary=@salary, DeptId=@deptId where EmpId=@empId

EXEC	[dbo].[updateEmp]
		@empId = 1008,
		@name = N'Harsha',
		@address = N'Gurmitkal',
		@salary = 20000,
		@deptId = 2

----------------------ALTER PROCEDURE----------------------------
alter procedure InsertEmp(
	@name nvarchar(40),
	@address nvarchar(200),
	@salary money,
	@deptId int,
	@generatedEmpId int output
)
as 
insert into Employee values(@name,@address,@salary,@deptId)
set @generatedEmpId =@@IDENTITY
print @@IDENTITY

select * from Employee
drop table Employee