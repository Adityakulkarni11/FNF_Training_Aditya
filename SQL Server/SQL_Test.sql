create table Employee (Emp_Id int primary key,Name varchar(50),Salary int,Manager_Id int);


insert into Employee (Emp_Id, Name, Salary, Manager_Id) values
(1, 'Rohit', 20000, 3),
(2, 'Sangeeta', 12000, 5),
(3, 'Sanjay', 10000, 5),
(4, 'Arun', 25000, 3),
(5, 'Zaheer', 30000, NULL);


select E.Name as emp_Name, M.Name as mgr_name
from Employee E
left Join Employee M ON E.Manager_Id = M.Emp_Id
order by E.Name;


