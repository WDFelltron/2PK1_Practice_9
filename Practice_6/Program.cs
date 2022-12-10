using System;
namespace Practice_6 
{
    public class programm
    {
        public static void Main(string[] args)
        {
            int K = 0;
            int n = Convert.ToInt32(Console.ReadLine());
            while (n > Math.Pow(K, 2)) K++;
            Console.WriteLine(Math.Pow(K, 2));
        }
    }
}
