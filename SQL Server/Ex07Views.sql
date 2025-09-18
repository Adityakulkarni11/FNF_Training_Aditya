create view vw_EmpWithDept
as
select EmpId,EmpName+' form '+ dbo.GetDeptName(DeptId) as DeptName from Employee

select * from vw_EmpWithDept