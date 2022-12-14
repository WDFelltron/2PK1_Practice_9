using System;

namespace Practice_14
{
    public class Program
    {
        public static void zadanie1(double a, int n)
        {
            double d = 0.1;
            if (n == 1)
            {
                Console.WriteLine(Math.Round(a,1));
            }
            else
            {
                Console.WriteLine(Math.Round(a,1));
                zadanie1(a += d, --n);
            }
        }
        public static void zadanie2(double b, int n)
        {
            double q = 0.15;
            if (n == 1)
            {
                Console.WriteLine(b);
            }
            else
            {
                Console.WriteLine(b);
                zadanie2(b *= q, --n);
            }
        }
        public static void zadanie3(int a, int b)
        {
            if (a < b) for (int i = a; i <= b; i++) Console.Write($"{i} ");
            else if (b < a) for (int i = a; i >= b; i--) Console.Write($"{i} ");
            else Console.WriteLine(a);
        }
        public static void specialzadanie4(int n) 
        {
            string first = "";
            char[] reverse = new char[(Convert.ToString(n)).Length];
            if (Math.Abs(n) >= 10)
            {
                Console.Write(n%10);
                specialzadanie4(n/=10);
            }
            else Console.Write(n);
        }
        public static void Main(string[] args)
        {
            byte con = 0;
            while (con !=4)
            {
                Console.Write($"Выберите номер от 1 до 4, чтобы выбрать соответствующее задание для проверки\nВыбор: ");
                switch (Console.ReadLine())
                {
                     
                    default: 
                        {
                    Console.WriteLine("В следующий раз, попробуйте выбрать существующий вариант задания");
                            break; 
                        };
                    case "1": { 
                            Console.WriteLine("Задание №1");
                            double a = 10;
                            Console.Write($"Введите количество шагов: ");
                            int n = Convert.ToInt32(Console.ReadLine());
                            Console.Write($"итог:") ; zadanie1(a, n); 
                            break; 
                        }
                    case "2": 
                        { 
                            Console.WriteLine("Задание №2");
                            double b = 14;
                            Console.Write($"Введите количество шагов: ");
                            int n = Convert.ToInt32(Console.ReadLine());
                            Console.Write($"итог:"); zadanie2(b, n);
                            break; 
                        }
                    case "3":
                        {
                            Console.WriteLine("Задание №3");
                            int a = 87, b = -87;
                            Console.WriteLine($"числа между {a} и {b} включительно:");
                            zadanie3(a, b);
                            break;
                        }
                    case "4": 
                        {
                            Console.WriteLine("Спецзадание №4");
                            Console.Write("Введите число:");
                            int n = Convert.ToInt32(Console.ReadLine());
                            specialzadanie4(n);
                            break; 
                        }
                }
                Console.Write($"\nПосмотреть другие?\nда-Y | нет-N\nВвод: ");
                string answer = Console.ReadLine();
                if (answer == "Y") con++;
                else if (answer == "N") break;
                else { Console.WriteLine("Засчитаю как ответ 'да'"); con++; }
            }
        }
    }
}