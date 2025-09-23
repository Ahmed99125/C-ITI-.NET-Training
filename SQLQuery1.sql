USE Company_SD

GO

SELECT e.Dno, COUNT(*) FROM Employee e
GROUP BY e.Dno

go

select min(e.Salary) from Employee e
group by e.Dno

go

select avg(e.Salary) from Employee e
group by e.Dno

go

select e.Dno from Employee e
group by e.Dno
having count(*) > 3

go 

select w.Pno from Works_for w
group by w.Pno
having count(ESSn) > 2

go

select e.SSN, e.Fname, e.Lname from Employee e
where e.Salary = (select max(Salary) from Employee)

go

select e.SSN, e.Fname, e.Lname from Employee e
where e.Salary > (select avg(Salary) from Employee)

go

select e.Fname, e.Lname from Employee e
join Works_for w on w.ESSn = e.SSN
where w.Pno in (select Pno from Works_for
				join Employee on ESSn = SSN
				where Fname = 'John' and Lname = 'Smith')
	and (e.Fname <> 'John' or e.Lname <> 'Smith')

go

select d.Dname from Departments d
join Project p on p.Dnum = d.Dnum
join Works_for w on w.Pno = p.Pnumber
join Employee e on e.SSN = w.ESSn
where e.Fname = 'Alice'

go

create view EmpInfo as 
select e.SSN, e.Fname, e.Lname, d.Dname, e.Salary from Employee e
join Departments d on d.Dnum = e.Dno

go

select * from EmpInfo

go

create view projectDepartment as
select p.Pnumber, p.Pname, d.Dname from Project p
join Departments d on d.Dnum = p.Dnum

go

select * from Employee e
order by e.Salary desc

go

select * from Project p
order by p.Pname asc

go

select top 3 * from Employee
order by Salary desc

go

select top 2 d.Dnum, d.Dname from Departments d
join Employee e on e.Dno = d.Dnum
group by d.Dnum, d.Dname
order by count(*)

go

select p.Pnumber, p.Pname, count(*) as 'num of emp' from Project p
join Works_for w on w.Pno = p.Pnumber
group by p.Pnumber, p.Pname

go

create view simpleCourses as 
select * from Project

go

delete from simpleCourses where Pname = 'project_name'

go

create view editedEmp as
select * from Employee

go

update editedEmp set Salary = Salary * 1.10
where Fname = 'John' and Lname = 'Smith'

go

select e.* from Employee e
where e.Salary > (select avg(Salary) from Employee
					where dno = e.Dno)