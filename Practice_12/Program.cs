using System;
namespace Practice_12
{
    public class Program
    {
        public static void inputVar(ref int val, ref int val2)
        {
            Console.Write("первое число: ");
            val = Convert.ToInt32(Console.ReadLine());
            Console.Write("второе число: ");
            val2 = Convert.ToInt32(Console.ReadLine());
        }
        public static void summ(int X, int Y)
        { 
            int S = X + Y;
            output(S);
        }
        public static void output(int S)
        { 
            Console.WriteLine($"Сумма двух чисел равна {S}");
        }
        public static void Main(string[] args)
        {
            int X=0, Y = 0;
            inputVar(ref X, ref Y);
            summ(X, Y);
        }
    }
}