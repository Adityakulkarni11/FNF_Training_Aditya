--1.Write a query to display the lastname, department number, and department name for all employees.
SELECT e.LASTNAME,e.DEPARTMENT_ID,d.DEPARTMENT_NAME
FROM EMPLOYEES e
JOIN DEPARTMENTS d ON e.DEPARTMENT_ID = d.DEPARTMENT_ID;


--2.Create a unique listing of all jobs that are in department 30. Include the location id in the output.
SELECT DISTINCT e.JOB_ID,d.LOCATION_ID
FROM EMPLOYEES e
JOIN DEPARTMENTS d ON e.DEPARTMENT_ID = d.DEPARTMENT_ID
WHERE e.DEPARTMENT_ID = 30;

--3.Write a query to display the employee lastname, department name, location id, and city of all employees who earn a commission.
select e.lastname, d.department_name, d.location_id
from employees e
join departments d on e.department_id = d.department_id
where e.commission_pct is not null;


--4.Display the employee lastname, and department name for all employees who have an "a" in their lastname.
select e.lastname, d.department_name
from employees e
join departments d on e.department_id = d.department_id
where e.lastname like '%a%';

--5.Write a query to display the lastname, job, department number, and department name for all employees who work in Toronto.
select e.lastname, e.job_id, e.department_id, d.department_name
from employees e
join departments d on e.department_id = d.department_id
where d.location_id in (select location_id from locations where city = 'Toronto');


--6.Display the employee lastname and employee number along with their manager's lastname and manager number. Label the columns "Employee", "Emp#", "Manager" and "Manager#" respectively.
select e.lastname as "Employee", e.employee_id as "Emp#", m.lastname as "Manager", m.employee_id as "Manager#"
from employees e
join employees m on e.manager_id = m.employee_id;


--7.Modify the above to display the same columns for all employees (including "King", who has no manager). Order the result by the employee number.
select e.lastname as "Employee", e.employee_id as "Emp#", m.lastname as "Manager", m.employee_id as "Manager#"
from employees e
left join employees m on e.manager_id = m.employee_id
order by e.employee_id;


--8.Create query that displays employee lastnames, department numbers, and all the employees who work in the same department as a given employee. Give each column an appropriate label.
select e.lastname as "Employee", e.department_id as "Dept#", c.lastname as "Colleague"
from employees e
join employees c on e.department_id = c.department_id
order by e.employee_id;


--9.Create a query that displays the name, job, department name, salary and grade for all employees.
select 
    e.lastname as "Name", 
    e.job_id as "Job", 
    d.department_name as "Department", 
    e.salary as "Salary",
    case 
        when e.salary >= 15000 then 'A'
        when e.salary >= 10000 then 'B'
        when e.salary >= 5000 then 'C'
        else 'D'
    end as "Grade"
from employees e
join departments d on e.department_id = d.department_id;


--10.Create a query to display the name and hiredate of any employee hired after employee "Davies"
select firstname as "Name", hire_date as "HireDate"
from employees
where hire_date > (select hire_date from employees where lastname = 'Davies');


--11.Display the names and hire dates for all employees who were hired before their managers, along with their manager's names and hiredates. Label the columns "Employee", "Emp hired", "Manager", and "Manager hired" respectively.
select 
    e.lastname as "Employee", 
    e.hire_date as "Emp hired", 
    m.lastname as "Manager", 
    m.hire_date as "Manager hired"
from employees e
join employees m on e.manager_id = m.employee_id
where e.hire_date < m.hire_date;

--12Display the highest, lowest, sum and average salary of all employees. Label the columns "Maximum", "Minimum", "Sum", and "Average" respectively.
select max(salary) as "maximum",min(salary) as "minimum",sum(salary) as "sum",avg(salary) as "average" from employees;


--13.Modify the above query to display the same data for each job type.
select job_id,
       max(salary) as "maximum",
       min(salary) as "minimum",
       sum(salary) as "sum",
       avg(salary) as "average"
from employees
group by job_id;


--14.Write a query to display the number of people with the same job.
select job_id,count(*) as "number_of_employees"
from employees
group by job_id;


--15.Determine the number of managers without listing them. Label the column "Number of Managers". [Hint: use the MANAGER_ID column to determine the number of managers
select count(distinct manager_id) as "number of managers"
from employees;


--16.Write a query that displays the difference between the highest and the lowes salaries. Label the column as "Difference".
select max(salary) - min(salary) as "difference"
from employees;


--17.Display the manager number and the salary of the lowest paid employee for that manager. Exclude anyone whose manager is not known. Exclude any group where the minimum salary is less than $6000. Sort the output in descending order of salary.
select manager_id,min(salary) as "lowest_salary"
from employees
where manager_id is not null
group by manager_id
having min(salary) >= 6000
order by "lowest_salary" desc;


--18.Write a query to display each department's name, location, number of employees, and the average salary for all employees in that department. Label the columns "Name", "Location", "No.of people", and "SAlary" respectively. Round the average salary to two decimal places.
select d.department_name as "Name",
       (select city from locations where location_id = d.location_id) as "Location",
       count(e.employee_id) as "No.of people",
       avg(e.salary) as "Salary"
from employees e
join departments d on e.department_id = d.department_id
group by d.department_name, d.location_id;


--19.Write a query to display the lastname, and hiredate of any employee in the department as the employee "Zlotkey". Exclude "Zlotkey".
select lastname,hire_date
from employees
where department_id = (select department_id from employees where lastname = 'Zlotkey') and lastname <> 'Zlotkey'; <>-->Exclude or filter out the values


--20.Create a query to display the employee numbers and lastnames of all employees who earn more than the average salary. Sort the result in ascending order of salary.
select employee_id,lastname,salary
from employees
where salary > (select avg(salary) from employees)
order by salary asc;


--21.Write a query that displays the employee number and lastname of all employees who work in a department with any employee whose lastname contains a "u".
select e.employee_id,e.lastname
from employees e
where e.department_id in (select department_id from employees where lastname like '%u%');


--22.Display the lastname, department number, and job id of all employees whose department location id is 1700.
select e.lastname,e.department_id,e.job_id
from employees e
join departments d on e.department_id = d.department_id
where d.location_id = 1700;


--23.Display the lastname and salary of every employee who reports to "King".
select e.lastname,e.salary
from employees e
join employees m on e.manager_id = m.employee_id
where m.lastname = 'King';


--24.Display the department number, lastname, and job id for every employee in the "Executive" department.
select e.department_id,e.lastname,e.job_id
from employees e
join departments d on e.department_id = d.department_id
where d.department_name = 'Executive';


--25.Display the employee number, lastname, and salary of all employees who earn more than the average salary and who work in a department with any employee with a "u" in their lastname.
select e.employee_id,e.lastname,e.salary
from employees e
where e.salary > (select avg(salary) from employees) and e.department_id in (select department_id from employees where lastname like '%u%');




















