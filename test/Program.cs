/*using System;
namespace test
{*/
using System;

public class Program
    {
        /*public static double GetArea(double l, double r)
        {
            double volume = (Math.PI*Math.Pow(r, 2)*Math.Sqrt(Math.Abs(Math.Pow(l, 2)-Math.Pow(r ,2))))/3;
            return Math.Round(volume, 2);
        }
        public static void ArrayGeneration(int n)
        {
            Random rnd = new Random();
            int[][] array = new int[n][];
            for (int i = 0; i < n; i++)
            {
                array[i] = new int[n];
                for (int j = 0; j < n; j++)
                {
                    array[i][j] = rnd.Next(0, 100);
                    Console.Write($"{array[i][j]} ");
                }
                Console.Write($"\n");
            }
        }
        public static void Main(String[] args)
        {
            double l =Convert.ToDouble(Console.ReadLine());
            double r = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"Площадь конуса будет равна {GetArea(l, r)} кубическим единицам \n");
            ArrayGeneration(Convert.ToInt32(Console.ReadLine()));
        }*/
        public static void Main()
        {
            string  txt = Console.ReadLine();
            NormalizeString(ref txt);
            Console.WriteLine("Нормализованная строка: "+txt);
        }
        public static void NormalizeString(ref string text)
        {
            text = text.Trim();
            char[] chars = text.ToCharArray();
            Char.ToUpper(chars[0]);

            for( int i = 1; i< chars.Length; i++ )
            {
                Char.ToLower(chars[i]);
            }
            text = string.Join("", chars);
        }
    }
//}