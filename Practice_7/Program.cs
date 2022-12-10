using System;

namespace Practice_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int[] mass = new int[10];
            Console.Write("Исходный массив: ");
            for (int i = 0; i < mass.Length; i++)
            {
                mass[i] = rnd.Next(-10, 11);
                Console.Write($"{mass[i]} ");
            }
            Console.Write("\nс циклическим сдвигом влево массив: ");
            for (int i = 0; i < mass.Length - 1; i++)
            {
                mass[i] = mass[i + 1];
                Console.Write($"{mass[i]} ");
            }
            mass[mass.Length - 1] = 0;
            Console.WriteLine($"{mass[mass.Length - 1]}");
        }
    }
}
