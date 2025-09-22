using System;
using System.Runtime.CompilerServices;

namespace Day7
{
    class Program
    {
        static void Main(string[] args)
        {
            //string s = "Hello, World!";

            //Console.WriteLine(s.WordCount());

            //int x = 7;

            //Console.WriteLine(x.IsEven());

        }

        public static Product CreateProduct()
        {
            return new Product { Name = "Laptop", Price = 999.99 };
        }
    }

    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }

    public static class ExtensionMethods
    {
        public static int WordCount(this string s)
        {
            if (s.Length == 0) return 0;
            int cnt = 1;
            for (int i = 0; i < s.Length; i++)
            {
                if ((char)s[i] == ' ' || (char)s[i] == '\n') cnt++;
            }
            return cnt;
        }

        public static bool IsEven(this int number)
        {
            return number % 2 == 0;
        }

        public static int CalculateAge(this DateTime birthDate)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthDate.Year;
            if (birthDate.Date > today.AddYears(-age)) age--;
            return age;
        }

        public static string ReverseString(this string str)
        {
            if (str == null || str.Length == 0) return str;
            char[] chars = str.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }
    }
}