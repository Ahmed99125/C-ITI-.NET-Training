using System;
using System.Diagnostics.Metrics;

namespace Day4
{
    public abstract class Person
    {
        public int Id { get; set; }
        public string name {  get; set; }
        public int age { get; set; }

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
            this.Id = IDGenerator.GenerateID();
        }

        public virtual void Introduce()
        {
            Console.WriteLine($"Hi!, I'm {name}");
        }
    }

    public class Instructor : Person
    {
        List<Course> TeachingCourses = new List<Course>();
        public Instructor(string name, int age) : base(name, age)
        {
        }

        public void TeachCourse(Course course)
        {
            course.instructor = this;
            TeachingCourses.Add(course);
            Console.WriteLine($"instructor {name} is now teaching {course.name}");
        }

        public override void Introduce()
        {
            Console.WriteLine($"Hi, I'm instructor {name}");
        }
    }

    public class Student : Person
    {
        List<Course> enrolledCourses = new List<Course>();
        public Student(string name, int age) : base(name, age)
        {
        }

        public void RegisterCourse(Course course)
        {
            enrolledCourses.Add(course);
            Console.WriteLine($"Student {name} has enrolled in {course.name}");
        }

        public override void Introduce()
        {
            Console.WriteLine($"Hi, i'm student {name}");
        }
    }

    public class Employee : Person
    {
        List<Course> enrolledCourses = new List<Course>();
        public Department dept { get; set; }

        public Employee(string name, int age, Department dept) : base(name, age)
        {
            this.dept = dept;
        }

        public void RegisterCourse(Course course)
        {
            enrolledCourses.Add(course);
            Console.WriteLine($"Student {name} has enrolled in {course.name}");
        }

        public override void Introduce()
        {
            Console.WriteLine($"Hi I'm employee {name}");
        }
    }

    public class Course
    {
        public string name { get; set; }
        public Instructor instructor { get; set; }

        public CourseLevel level { get; set; }

        public Course(string name, Instructor instructor, CourseLevel level)
        {
            this.instructor = instructor;
            this.name = name;
            this.level = level;

            switch (level)
            {
                case CourseLevel.Beginner:
                    Console.WriteLine("good luch starting out!");
                    break;
                case CourseLevel.Intermediate:
                    Console.WriteLine("you're in the middle of the way!");
                    break;
                case CourseLevel.Advanced:
                    Console.WriteLine("you're almost there!");
                    break;
                default:
                    Console.WriteLine("not recognized");
                    break;
            }
        }
    }

    public class Department
    {
        public int deptID { get; set; }
        public string deptName { get; set; }

        public Department(int id,  string deptName)
        {
            deptID = id;
            this.deptName = deptName;
        }
    }

    public class Company
    {
        List<Department> depts = new List<Department>();

        public void addDepartment(Department dept)
        {
            depts.Add(dept);
            Console.WriteLine($"department {dept.deptName} has been added");
        }
    }

    //--------------------------------------------

    public abstract class Shape
    {
        public abstract double Area();
    }

    public interface IDrawable
    {
        void draw();
    }

    public class Circle : Shape, IDrawable
    {
        public double radius {  get; set; }

        public Circle(double radius) {  this.radius = radius; }
        public override double Area()
        {
            return radius * radius * Math.PI;
        }

        public void draw()
        {
            Console.WriteLine($"the area is: {this.Area()}");
        }
    }

    public class Rectangle : Shape, IDrawable
    {
        public double width { get; set; }
        public double height { get; set; }

        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        public override double Area()
        {
            return width * height;
        }

        public void draw()
        {
            Console.WriteLine($"the area is: {this.Area()}");
        }
    }


// -------------------------------------------------

    public static class IDGenerator
    {
        public static int counter = 0;
        public static int GenerateID()
        {
            return counter++;
        }
    }

    public class Grade
    {
        public int Value { get; }
        public Grade(int value) => Value = value;

        public static Grade operator +(Grade left, Grade right)
        {
            return new Grade(left.Value + right.Value);
        }

        public static bool operator ==(Grade left, Grade right)
        {
            return left.Value == right.Value;
        }

        public static bool operator !=(Grade left, Grade right)
        {
            return left.Value == right.Value;
        }
    }

    public enum CourseLevel
    {
        Beginner,
        Intermediate,
        Advanced
    }



    internal class Program
    {
        public static int Main(string[] args)
        {
            // Create a company
            Company company = new Company();

            // Create departments
            Department devDept = new Department(1, "Development");
            Department hrDept = new Department(2, "HR");
            company.addDepartment(devDept);
            company.addDepartment(hrDept);

            // Create employees
            Employee emp1 = new Employee("Ayman", 29, devDept);
            Employee emp2 = new Employee("Sara", 26, devDept);

            // Create instructors
            Instructor instr1 = new Instructor("Mona", 40);
            Instructor instr2 = new Instructor("Khaled", 35);

            // Create students
            Student st1 = new Student("Hana", 20);
            Student st2 = new Student("Omar", 22);

            // Create courses
            Course csharp = new Course("C# Fundamentals", null, CourseLevel.Beginner);
            Course advAlgo = new Course("Advanced Algorithms", null, CourseLevel.Advanced);
            Course hrMgmt = new Course("HR Management", null, CourseLevel.Intermediate);

            // Assign instructors to courses
            instr1.TeachCourse(csharp);
            instr1.TeachCourse(advAlgo);
            instr2.TeachCourse(hrMgmt);

            // Students register for courses
            st1.RegisterCourse(csharp);
            st1.RegisterCourse(advAlgo);
            st2.RegisterCourse(hrMgmt);

            // Employees register for courses
            emp1.RegisterCourse(csharp);
            emp2.RegisterCourse(hrMgmt);

            // Add grades
            Grade g1 = new Grade(80);
            Grade g2 = new Grade(90);
            Grade g3 = new Grade(75);

            Grade total = g1 + g2;
            Console.WriteLine($"Total grade: {total.Value}");

            Console.WriteLine($"Grades equal? {g1 == g3}");

            // Shapes polymorphism demo
            List<Shape> shapes = new List<Shape>
            {
                new Circle(3),
                new Rectangle(4,5)
            };

            foreach (var shape in shapes)
            {
                Console.WriteLine($"Area: {shape.Area()}");
                (shape as IDrawable).draw();
            }

            return 0;
        }
    }
}