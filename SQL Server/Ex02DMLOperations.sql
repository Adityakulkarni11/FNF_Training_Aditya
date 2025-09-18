use FNFTraining

insert into Employee(EmpName,EmpAddress,EmpSalary,DeptId) values('Shadul','Shivmogga',52230,5)

insert into Employee(EmpName,EmpSalary,DeptId) values('Shadul',52230,5)--Cannot insert the value NULL into column 'EmpAddress', table 'FNFTraining.dbo.Employee'; column does not allow nulls. INSERT fails.

delete from Employee where EmpId=7

update Employee set EmpAddress='Bidar',EmpSalary=52630 where EmpId=1


select * from DeptTable
select * from Employee