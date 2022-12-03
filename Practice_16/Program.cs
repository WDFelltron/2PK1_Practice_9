using System;
using System.IO;
using System.Text;
namespace Practice_9
{
    public class program
    {
        public static string Corrector(string s)
        {
            char[] mass = new char[s.Length];
            for(int c = 0; c < mass.Length; c++)
            {
                mass[c] = s[c];
            }
            mass[0] = Char.ToUpper(mass[0]);
            for (int i=1;i<mass.Length;i++)
            {
                mass[i] = Char.ToLower(mass[i]);
            }
            s = new string(mass);
            while (s.Contains("  ")!=false) {
                s = s.Replace("  ", " ");
            }
            return s;
        }
        public static void Main(string[] args)
        {
            string address = @"D:\myBook";
            FileStream file = new FileStream(address, FileMode.Append, FileAccess.Write);
            while (true)
            {
                using (StreamWriter w = new StreamWriter(file, Encoding.UTF8))
                {
                    w.WriteLine(Corrector(Console.ReadLine()));
                }
                Console.WriteLine("Хотите продолжить делать новые записи?");
                if (Console.ReadLine() == "N") { Console.WriteLine("Хорошего дня"); break; }
                else { Console.WriteLine("Возобновляем алгоритм"); }
            }
        }
    }
}
/*Дан файл с неким содержимым. Произвести дозапись строк из консоли с одновременной 
нормализацией строки: первая буква заглавная, остальные строчные, и удалены лишние 
пробелы.*/