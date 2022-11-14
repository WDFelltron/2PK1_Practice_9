using System;
namespace Practice_13
{
    public class Program
    {
        public static bool IsPalindrom(string sent)
        {
            sent.Replace(" ", "");
            bool right = false;
            if(sent.Length%2==0)
            {
                for(int i = 0; i < sent.Length / 2; i++)
                {
                    if (sent[i] == sent[sent.Length - 1])
                    {
                        right = true;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < (sent.Length - 1) / 2; i++)
                {
                    if (sent[i] == sent[sent.Length - 1])
                    {
                        right = true;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return right;
        }
        public static void Main(string[] args)
        {
            Console.WriteLine(IsPalindrom(Console.ReadLine()));
        }
    }
}