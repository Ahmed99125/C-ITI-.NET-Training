USE Company_SD;
GO

SELECT p.Pname, SUM(w.Hours) AS TotalHours
FROM Project p
JOIN Works_for w ON p.Pnumber = w.Pno
GROUP BY p.Pname;

go

SELECT TOP 1 Dep.* FROM Departments AS Dep
JOIN Employee AS Emp ON Dnum = Dno
ORDER BY SSN ASC;

GO

SELECT Dep.Dname, min(Emp.Salary) AS 'min salary', max(emp.Salary) AS 'max salary', avg(emp.Salary) AS 'average salary' 
FROM Departments AS Dep
JOIN Employee AS Emp ON Dnum = Dno
GROUP BY dep.Dname;

GO

SELECT e.Fname + ' ' + e.Lname AS FullName
FROM Employee e
WHERE e.SSN IN (SELECT MGRSSN FROM Departments)
  AND NOT EXISTS (SELECT 1 FROM Dependent dep WHERE dep.ESSN = e.SSN);

GO

SELECT d.Dnum, d.Dname, COUNT(*) AS numOfEmployees 
FROM Departments AS d
JOIN Employee AS e ON e.Dno = d.Dnum
GROUP BY D.Dnum, D.Dname
HAVING AVG(e.Salary) < (SELECT AVG(Salary) FROM Employee);

GO

SELECT e.Fname + ' ' + e.Lname AS FullName, p.Pname FROM Employee e
join Works_for w on w.ESSn = e.SSN
join Project p on p.Dnum = e.Dno
order by e.Dno, Lname, Fname;

GO

INSERT INTO Departments(Dname, Dnum, MGRSSN, [MGRStart Date])
VALUES ('DEPT IT', 100, 112233, '1-11-2006');

GO

SELECT * FROM Departments WHERE Dnum = 100;

GO

UPDATE Departments
SET MGRSSN = 968574
WHERE MGRSSN = 112233;

GO

UPDATE Departments
SET MGRSSN = 102672
WHERE Dnum = 20;

GO

update Employee
set Superssn = 102672
where SSN = 102660;

go

SELECT d.Dnum, d.Dname, m.SSN AS ManagerSSN, m.Fname AS ManagerFname, m.Lname AS ManagerLname
FROM Departments d
LEFT JOIN Employee m ON m.SSN = d.MGRSSN;

go

select d.Dname, p.Pname from Departments d
left join Project p on p.Dnum = d.Dnum;

go

select e.Fname + ' ' + e.Lname AS FullName, d.* from Employee e
join Dependent d on e.SSN = d.ESSN;

go

select p.Pnumber, p.Pname, p.Plocation from Project p
where p.Plocation = 'Cairo' or p.Plocation = 'Alex';

go

select * from Project
where Pname like 'A%';

go

select e.* from Employee e
where e.Dno = 30 and e.Salary between 1000 and 2000;

go

select e.Fname from Employee e
join Project p on p.Dnum = e.Dno
join Works_for w on w.ESSn = e.SSN
where e.Dno = 10 and p.Pname = 'Al Rabwah' and w.Hours >= 10;


go

select e.Fname from Employee e
join Employee super on super.SSN = e.Superssn
where super.Fname = 'Kamel';

go

select e.Fname, p.Pname from Employee e
join Works_for w on w.ESSn = e.SSN
join Project p on p.Pnumber = w.Pno
order by p.pname, e.Fname;

go

select p.Pnumber, p.Pname, d.Dname, e.Lname, e.Address from project p
join Departments d on d.Dnum = p.Dnum
join Employee e on e.SSN = d.MGRSSN;