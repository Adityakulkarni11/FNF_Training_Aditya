--It is a scalar value function(returns only one value)--
create function getEmpCount()
returns integer
as
begin
	declare @count int
	set @count=(select count(*) from Employee)
	return @count
end

select dbo.getEmpCount() as EmpCount

-----------Functions with parameters-----------
create function getDeptName(@id int)
returns varchar(50)
as 
begin
	declare @name varchar(50)
	set @name=(select deptName from DeptTable where DeptId=@id)
	return @name
end

select e.EmpName, dbo.getDeptName(e.DeptId) as Dept from Employee e 

-----Using Date and Time------
print getDate()

create function CreateDate(@date Date)
returns varchar(50)
as
begin
	declare @retVal varchar(50)
	set @retVal=''+cast(day(@date) as varchar(5))+'/'+cast(month(@date) as varchar(14))+'/'+cast(year(@date) as varchar(5))
	return @retVal
end

print dbo.CreateDate(getDate())


----Age Function----
create function getAge(@dob Date)
returns int
as
begin
	declare @age int
	set @age=datediff(year,@dob,getdate())
	return @age
end

print dbo.getAge('11/02/2004')

-------------Table Value Functions------------
create function getEmployeeByCity(@city varchar(50))
returns table
as
return (select * from Employee where EmpAddress=@city)

select EmpName,EmpAddress from dbo.getEmployeeByCity('San Jose')

