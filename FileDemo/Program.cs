using System.Text;

namespace FileDemo
{
    internal class Program
    {
        /// <summary>
        /// демонстрация чтения записи построчно с помощью потоков
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            

            string filename = @"D:\test.txt";
            //открытие файлового потока
            
                //открытие потока на запись
                using (StreamWriter writer = new StreamWriter(filename))
                {
                    string  line = "";
                    while (line != "stop")
                    {
                        line = Console.ReadLine();
                        writer.WriteLine(line);
                    }
                }//автоматическое закрытие потока writer

                //открытие потока на чтение из файла
                using (StreamReader reader = new StreamReader(filename))
                {
                    string text = reader.ReadToEnd();
                    Console.WriteLine("Содержимое файла:");
                    Console.WriteLine(text);
                }//автоматическое закрытие потока reader


        }
    }
}