use FNFTraining

select * from Employee

select * from Employee where EmpAddress='Denver'

select * from Employee where EmpAddress like 'San%'

select * from Employee where EmpAddress like 'Den%' and EmpSalary>80000

--------------------------------SQL Server Scalar Value functions-------------------------------
select Max(EmpSalary) as MaxSalary, Min(EmpSalary) as MinSalary, Avg(EmpSalary) as AvgSalary from Employee

select top(10)EmpName, EmpSalary from Employee order by EmpSalary desc

select top 50 percent * from Employee 

select top 50 percent * from Employee order by EmpId desc

select * from (select top 50 percent * from Employee order by EmpId desc) temp order by EmpId asc;

------------------------------Joins for combining data from multiple tables--------------------------------

select Employee.*, DeptTable.DeptName from Employee ,DeptTable where Employee.DeptId=DeptTable.DeptId
--or--
select EmpName,EmpSalary,DeptName from Employee
join DeptTable
on Employee.DeptId=DeptTable.DeptId


declare @numRows int=50;

with RandomRows as (select top(@numRows) * from Employee order by EmpId)
update RandomRows set DeptId=null

select count(*) as NullEmployees from Employee where DeptId is null

---- Left Join--> All left side data and matching right side data.
select EmpName,EmpSalary,DeptName from Employee
left join DeptTable
on Employee.DeptId=DeptTable.DeptId

--coalesce is like if Condition, where the value is not available, u can replace it with a certain value
select EmpName,EmpSalary,coalesce(DeptName,'Not Assigned') as DeptName from Employee
left join DeptTable
on Employee.DeptId=DeptTable.DeptId


--Add few depts that dont belong to any employee
Insert into DeptTable values('House Kepping')
insert into DeptTable values('IT Team')

------- Right Join-->Right side all data and matching left side data.
select EmpName,EmpSalary,DeptName from Employee
right join DeptTable
on Employee.DeptId=DeptTable.DeptId

------group by clause-----
--get the employee count by city
select EmpAddress,count(EmpName) as EmpCount from Employee 
group by EmpAddress
order by EmpAddress
--If u want to use group by, the selection should have either aggregate functions or all columns on which grouping is done.

--get the distribution of salaries in each city with city highest salary should come first
select EmpAddress,sum(EmpSalary) as TotalSalary from Employee 
group by EmpAddress
order by TotalSalary desc


--all employees who earn more than the average salary
SELECT *
FROM Employee
WHERE EmpSalary > (SELECT AVG(EmpSalary) FROM Employee) and DeptId is not null
ORDER BY EmpSalary;

--all employees who earn more than the average salary of that city
select e.EmpName,e.EmpAddress,e.EmpSalary,Avgsalaries.avgSalary as AvgSalary from Employee e
join 
(select Employee.EmpAddress, Avg(Employee.EmpSalary) as avgSalary 
from Employee group by EmpAddress) as Avgsalaries 
on e.EmpAddress=Avgsalaries.EmpAddress 
where e.EmpSalary>Avgsalaries.avgSalary

SELECT e.EmpName,e.EmpAddress,e.EmpSalary,a.avgSalary
FROM Employee e
JOIN 
    (SELECT EmpAddress, AVG(EmpSalary) AS avgSalary
     FROM Employee
     GROUP BY EmpAddress) a
ON e.EmpAddress = a.EmpAddress
WHERE e.EmpSalary > a.avgSalary;


