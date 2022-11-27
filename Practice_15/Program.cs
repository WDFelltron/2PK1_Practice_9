using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading.Channels;

namespace Practice_15
{
    public class programm

    {
        public static int absoluteIndex(string[] mass, int i) {
            int z = 0;
            if (i < 0 && mass.Length <= Math.Abs(i))
            {
                z = mass.Length - i;
            }
            else if (i > 0 && mass.Length < i)
            {
                z = i;
            }
            else throw new ArgumentException("Absolute Index was out of the acceptable range");
            return z; 
        }
        public static string generateText()
        {
            Random rnd = new Random();
            int n = rnd.Next(0, 100);
            string word = null;
            for(int i = 0; i < n; i++)
            {
                word += (char)rnd.Next('\u0000', '\uFFFF');
            }
            return word;
        }
        public static void Main(string[] args)
        {
            string[] address = { @"D:\f1.txt", @"D:\f2.txt", @"D:\cage2.txt" };
            string[] texts = new string[address.Length];
            FileStream[] file = new FileStream[address.Length];
            for(int i=0; i < file.Length; i++) { file[i] = new FileStream(address[i], FileMode.OpenOrCreate, FileAccess.ReadWrite); }
            for (int i = 0; i < address.Length-1;i+=0) {
                if (File.Exists(address[i])) {
                    using (StreamWriter writer = new StreamWriter(file[i], Encoding.UTF8))
                    {
                        writer.WriteLine(generateText());
                    }
                    i++;
                }
                else {
                    File.Create(address[i]); 
                }
            }
            for (int j = 0; j < address.Length; j++) 
            {
                StreamReader reader = new StreamReader(file[j], Encoding.UTF8);
                StreamWriter writer = new StreamWriter(file[absoluteIndex(address, j - 1)], Encoding.UTF8);
                writer.Write(reader.ReadToEnd());
                reader.Close();
                writer.Close();
                /*using(StreamReader reader = new StreamReader(file[j], Encoding.UTF8))
                {
                    using(StreamWriter writer = new StreamWriter(file[absoluteIndex(address, j-1)], Encoding.UTF8)) 
                    {
                         writer.Write(reader.ReadToEnd());               
                    }
                }*/
            }
        }
    }
}
/* Даны текстовые файлы f1 и f2. Переписать содержимое файла f1 в файл f2, а содержимое
файла f2 в файл f1. Использовать вспомогательный файл.*/
// 2>3 3>1 1>2