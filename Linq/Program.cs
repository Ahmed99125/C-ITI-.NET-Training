using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq
{

    public class Subject
    {
        public int Code { get; set; }
        public string Name { get; set; }
    }


    public class Student
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Subject[] subjects { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==== Part 1 ====");

            List<int> numbers = new List<int>() { 2, 4, 6, 7, 1, 4, 2, 9, 1 };


            var q1 = numbers.Distinct().OrderBy(n => n);
            Console.WriteLine("Query1 Result:");
            foreach (var n in q1)
                Console.Write(n + " ");
            Console.WriteLine("\n");


            var q2 = q1.Select(n => new { Number = n, Multiplied = n * n });
            Console.WriteLine("Query2 Result:");
            foreach (var item in q2)
                Console.WriteLine($"{item.Number} => {item.Multiplied}");


            Console.WriteLine("\n==== Part 2 ====");

            string[] names = { "Tom", "Dick", "Harry", "MARY", "Jay" };


            var queryExp1 = from n in names
                            where n.Length == 3
                            select n;

            var methodExp1 = names.Where(n => n.Length == 3);

            Console.WriteLine("Query1 (Length = 3):");
            Console.WriteLine("Query Expression: " + string.Join(", ", queryExp1));
            Console.WriteLine("Method Expression: " + string.Join(", ", methodExp1));


            var queryExp2 = from n in names
                            where n.ToLower().Contains("a")
                            orderby n.Length
                            select n;

            var methodExp2 = names
                             .Where(n => n.ToLower().Contains("a"))
                             .OrderBy(n => n.Length);

            Console.WriteLine("\nQuery2 (Contains 'a', sorted by length):");
            Console.WriteLine("Query Expression: " + string.Join(", ", queryExp2));
            Console.WriteLine("Method Expression: " + string.Join(", ", methodExp2));


            var queryExp3 = (from n in names select n).Take(2);
            var methodExp3 = names.Take(2);

            Console.WriteLine("\nQuery3 (First 2 names):");
            Console.WriteLine("Query Expression: " + string.Join(", ", queryExp3));
            Console.WriteLine("Method Expression: " + string.Join(", ", methodExp3));


            Console.WriteLine("\n==== Part 3 ====");

            List<Student> students = new List<Student>()
            {
                new Student(){
                    ID=1, FirstName="Ali", LastName="Mohammed",
                    subjects=new Subject[]{
                        new Subject(){ Code=22, Name="EF"},
                        new Subject(){ Code=33, Name="UML"}
                    }
                },
                new Student(){
                    ID=2, FirstName="Mona", LastName="Gala",
                    subjects=new Subject[]{
                        new Subject(){ Code=22, Name="EF"},
                        new Subject(){ Code=34, Name="XML"},
                        new Subject(){ Code=25, Name="JS"}
                    }
                },
                new Student(){
                    ID=3, FirstName="Yara", LastName="Yousf",
                    subjects=new Subject[]{
                        new Subject(){ Code=22, Name="EF"},
                        new Subject(){ Code=25, Name="JS"}
                    }
                },
                new Student(){
                    ID=1, FirstName="Ali", LastName="Ali",
                    subjects=new Subject[]{
                        new Subject(){ Code=33, Name="UML"}
                    }
                }
            };


            var q3_1 = students.Select(s => new
            {
                FullName = s.FirstName + " " + s.LastName,
                CountSubjects = s.subjects.Count()
            });

            Console.WriteLine("Query1 (FullName + #Subjects):");
            foreach (var s in q3_1)
                Console.WriteLine($"{s.FullName} => {s.CountSubjects}");


            var q3_2 = students
                        .OrderByDescending(s => s.FirstName)
                        .ThenBy(s => s.LastName)
                        .Select(s => new { s.FirstName, s.LastName });

            Console.WriteLine("\nQuery2 (Ordered):");
            foreach (var s in q3_2)
                Console.WriteLine($"{s.FirstName} {s.LastName}");

            var q3_3 = students.SelectMany(s => s.subjects,
                           (st, sub) => new
                           {
                               StudentName = st.FirstName + " " + st.LastName,
                               SubjectName = sub.Name
                           });

            Console.WriteLine("\nQuery3 (SelectMany):");
            foreach (var item in q3_3)
                Console.WriteLine($"{item.StudentName} => {item.SubjectName}");

            // BONUS: GroupBy (group students by subject name)
            var q3_bonus = students
                .SelectMany(s => s.subjects, (st, sub) => new { st, sub })
                .GroupBy(x => x.sub.Name);

            Console.WriteLine("\nBONUS (GroupBy Subject):");
            foreach (var g in q3_bonus)
            {
                Console.WriteLine($"Subject: {g.Key}");
                foreach (var item in g)
                    Console.WriteLine($"   {item.st.FirstName} {item.st.LastName}");
            }

            Console.ReadKey();
        }
    }
}
