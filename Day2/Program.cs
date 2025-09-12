using System;

public class Day2
{
    public static int Main(string[] args)
    {
        Task3();
        return 0;
    }

    public static void Task1()
    {
        Console.Write("Enter number of studnets: ");
        int numOfStudents = int.Parse(Console.ReadLine());

        List<String> list = new List<String>();

        for (int i = 0; i < numOfStudents; i++)
        {
            Console.Write($"Enter Name of studnet {i + 1}: ");
            list.Add(Console.ReadLine());
        }

        Console.WriteLine("Student names: ");

        foreach (String name in list)
        {
            Console.WriteLine(name);
        }
    }

    public static void Task2() {
        Console.Write("Enter number of tracks: ");
        int numOftracks = int.Parse(Console.ReadLine());

        List <List <int>> list = new List<List <int>>();

        for (int t = 0; t < numOftracks; t++)
        {
            list.Add(new List<int>());

            Console.Write("Enter number of students: ");
            int numOfStudents = int.Parse(Console.ReadLine());

            for (int s = 0; s  < numOfStudents; s++)
            {
                Console.Write($"Enter student {s + 1}'s age for track {t + 1}: ");
                list[t].Add(int.Parse(Console.ReadLine()));
            }
        }

        Console.WriteLine("Ages by track: ");

        for (int t = 0; t < numOftracks; t++)
        {
            Console.WriteLine($"Track {t + 1}");
            int sum = 0;

            foreach (int age in list[t])
            {
                Console.WriteLine(age);
                sum += age;
            }

            double avg = (list[t].Count == 0) ? 0 : (double) sum / list[t].Count;

            Console.WriteLine($"Avg age: {avg}");
        }
    }

    public struct CustomTime
    {
        public int hours;
        public int minuts;
        public int seconds;

        public void print()
        {
            Console.WriteLine($"{hours}H:{minuts}M:{seconds}S");
        }

        public CustomTime(int h, int m, int sec)
        {
            hours = h ; minuts = m; seconds = sec;
        }
    }

    public static void Task3()
    {
        CustomTime t = new CustomTime(1, 12, 30);

        t.print();
    }
}