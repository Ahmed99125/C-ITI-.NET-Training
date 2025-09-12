using System;

public class Day1
{
    public static int Main(string[] args)
    {
        //charToInt();

        //intToChar();

        //oddOrEven(1);

        //oddOrEven(2);

        //arithmeticOP(2, 2);

        //getDegree(98);

        multiplicationTable(5);



        return 0;
    }

    public static void charToInt()
    {
        char c = (char) Console.Read();

        Console.WriteLine((int) c);
    }

    public static void intToChar()
    {
        int c = (int)Console.Read();

        Console.WriteLine((char)c);
    }

    public static void oddOrEven(int num)
    {
        if (num % 2 == 0)
        {
            Console.WriteLine("Even");
        }
        else
        {
            Console.WriteLine("Odd");
        }
    }

    public static void arithmeticOP(int num1, int num2)
    {
        Console.Write("sum: ");
        Console.WriteLine(num1 + num2);

        Console.Write("subtraction: ");
        Console.WriteLine(num1 - num2);

        Console.Write("multiplication: ");
        Console.WriteLine(num1 * num2);

        Console.Write("division: ");
        Console.WriteLine(num1 / num2);
    }

    public static void getDegree(int grade)
    {
        if (grade >= 90)
        {
            Console.WriteLine("Excellent!");
        }
        else if (grade >= 70)
        {
            Console.WriteLine("Very good!");
        }
        else if (grade >= 50)
        {
            Console.WriteLine("Good!");
        }
        else
        {
            Console.WriteLine("Failed!");
        }
    }

    public static void multiplicationTable(int num)
    {
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine($"{i} * {num} = {i * num}");
        }
    }
}