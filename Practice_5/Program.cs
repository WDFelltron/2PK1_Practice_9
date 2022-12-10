using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_5
{
    internal class Program
    {
        static void Main(string[] args)
        { 
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Введите цифру от 1 до 5 на NumPad, чтобы проверить задание");
                switch (Console.ReadKey(true).Key)
                { 
                    default:
                        {
                            Console.WriteLine("Введите снова");
                            break;
                        }
                    case ConsoleKey.NumPad1:
                        {
                            Console.WriteLine("Задание №1");
                            for (int i = -25; i <= 25; i += 25) Console.WriteLine(i);
                            break;
                        }
                    case ConsoleKey.NumPad2:
                        {
                            Console.WriteLine("Задание №2");
                            char n = 'P';
                            for (int i=0; i<5; i++) Console.Write($"{n++} ");
                            Console.Write('\n');
                            break;
                        }
                    case ConsoleKey.NumPad3:
                        {
                            Console.WriteLine("Задание №3");
                            for(int m = 0; m < 7; m++)
                            {
                                for(int n = 0; n<4;n++) Console.Write('#');
                                Console.Write('\n');
                            }
                            break;
                        }
                    case ConsoleKey.NumPad4:
                        {
                            Console.WriteLine("Задание №4");
                            for (int i = 0; i < 100; i++) if (i%2==0)Console.Write($"{i} ");
                            Console.Write('\n');
                            break;
                        }
                    case ConsoleKey.NumPad5:
                        {
                            Console.WriteLine("Задание №5");
                            int i = 3;
                            int j = 50;
                            while((j-i) != 17)
                            {
                                Console.WriteLine($"{i} {j}");
                                i++;
                                j--;
                            }
                            break;
                        }
                }
                Console.WriteLine("чтобы завершить просмотр заданий, нажмите Esc\nдля продолжения нажмите любую другую кнопку");
                if (Console.ReadKey(true).Key == ConsoleKey.Escape) break;
            }
        }
    }
}