using System;
using System.Collections;
using System.Numerics;

namespace Day5
{
    internal class Program
    {
        public static int Main(string[] args)
        {
            //int[] arr = { 6, 2, 7, 5, 1 };
            //BubbleSort.Sort(arr);
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    Console.WriteLine(arr[i]);
            //}



            //var intRange = new Range<int>(10, 20);
            //Console.WriteLine(intRange.IsInRange(15)); 
            //Console.WriteLine(intRange.IsInRange(25)); 
            //Console.WriteLine(intRange.Length()); 


            //var doubleRange = new Range<double>(5.5, 10.2);
            //Console.WriteLine(doubleRange.IsInRange(7.5)); 
            //Console.WriteLine(doubleRange.Length()); 


            //ArrayList arr = new ArrayList() { 1, 2, 3, 4, 5 };

            //ReverseArrayList(arr);

            //Console.WriteLine("Reversed ArrayList:");
            //foreach (var item in arr)
            //    Console.Write(item + " ");



            //List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };

            //List<int> evenNumbers = GetEvenNumbers(numbers);

            //Console.WriteLine("Even Numbers:");
            //foreach (int num in evenNumbers)
            //{
            //    Console.Write(num + " ");
            //}


            //string str1 = "leetcode";
            //string str2 = "aabbcc";
            //string str3 = "swiss";

            //Console.WriteLine(FirstUniqueChar(str1));
            //Console.WriteLine(FirstUniqueChar(str2));
            //Console.WriteLine(FirstUniqueChar(str3));


            return 0;
        }

        static void ReverseArrayList(ArrayList list)
        {
            int left = 0;
            int right = list.Count - 1;

            while (left < right)
            {
                // Swap elements
                object temp = list[left];
                list[left] = list[right];
                list[right] = temp;

                left++;
                right--;
            }
        }

        static List<int> GetEvenNumbers(List<int> numbers)
        {
            List<int> evens = new List<int>();

            foreach (int num in numbers)
            {
                if (num % 2 == 0)
                    evens.Add(num);
            }

            return evens;
        }

        static int FirstUniqueChar(string s)
        {
            Dictionary<char, int> freq = new Dictionary<char, int>();

            foreach (char c in s)
            {
                if (freq.ContainsKey(c))
                    freq[c]++;
                else
                    freq[c] = 1;
            }

            for (int i = 0; i < s.Length; i++)
            {
                if (freq[s[i]] == 1)
                    return i;
            }

            return -1;
        }
    }

    public class Range<T> where T : IComparable<T>, INumber<T>
    {
        public T min {  get; set; }
        public T max { get; set; }
        public Range(T min, T max)
        {
            this.min = min;
            this.max = max;
        }

        public bool IsInRange(T val)
        {
            if (val.CompareTo(min) >= 0 &&  val.CompareTo(max) <= 0)
            {
                return true;
            }
            return false;
        }

        public T Length()
        {
            return max - min;
        } 
    }

    public static class BubbleSort
    {
        public static void Sort(int[] arr)
        {
            int size = arr.Length;
            for (int i = 0; i <  size; i++)
            {
                bool flag = false;
                for (int j = 0; j < size - 1; j++)
                {
                    if (arr[j] > arr[j+1])
                    {
                        flag = true;
                        int tmp = arr[j];
                        arr[j] = arr[j+1];
                        arr[j+1] = tmp;
                    }
                }
                if (!flag)
                {
                    break;
                }
            }
        }
    }

    public class FixedSizeList<T>
    {
        private T[] items;
        private int count;
        private int capacity;

        public FixedSizeList(int capacity)
        {
            if (capacity <= 0)
                throw new ArgumentException("Capacity must be greater than zero.");

            this.capacity = capacity;
            this.items = new T[capacity];
            this.count = 0;
        }

        public void Add(T item)
        {
            if (count >= capacity)
                throw new InvalidOperationException("List is full.");

            items[count] = item;
            count++;
        }

        public T Get(int index)
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException("Invalid index.");

            return items[index];
        }

        public int Count => count;
        public int Capacity => capacity;
    }
}