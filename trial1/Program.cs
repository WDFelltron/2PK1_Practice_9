using System;
namespace trial1
{
    internal class Program
    {
        /*static void Main(string[] args)
        {
            double average;
            int[] array = { 1, 8, 6, 74, 9, 56, 468, 6546, 9, 556, 8, 6 };
            GetAverageOfArray(array, out average);
            Console.WriteLine(average);
        }
        static void GetAverageOfArray(int[] arr, out double result)
        {
            result = 0;
            foreach (int i in arr) result += 1;
            result /= arr.Length;
        }*/
        static void Main(string[] args)
        {
            int[] nums = { 4, 5996, 3, 78, 6, 4 };
            Console.WriteLine(IsEvens(nums));
            Console.WriteLine(IsEvens( 8, 800, 54, 54 ));
        }
        static bool IsEvens (params int[] array)
        {
            bool result = true;
            foreach(int num in array)
            {
                if (num % 2 != 0) 
                { 
                    result = false;
                    break;
                }
            }
            return result;
        }
        static bool IsEvensAndCount(out int count, params int[] array)
        {
            count = 0;
            bool result = true;
            foreach(int num in array)
            {
                if (num % 2 != 0)
                {
                    result = false;
                    count++;
                }
                
            }
            return result;
        }
    }
}
