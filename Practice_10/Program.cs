using System;

namespace Practice_10

{
    public class Program
    {
        static string checkout(string a)
        {
            char[] vs = new char[a.Length];
            for (int i = 0; i < vs.Length; i++) { vs[i] = a[i]; }
            char[] signs = { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', ',', '.', '<', '>', '?', '/', '|', '[', ']', '{', '}', '-', '+', '~', '`', '"', '№', ';', ':', '1', '2', '3', '4', '5', '6', '7', '8', '9', '_', '=', ' ' };
            for (int i = 0; i < signs.Length; i++)
            {
                for (int j = 0; j < vs.Length; j++)
                {
                    if (signs[i] == vs[j] || Convert.ToChar("'") == vs[j]) { vs[j] = '0'; }
                }
            }
            for (int i = 0; i < vs.Length; i++)
            {
                if (i < vs.Length - 1)
                {
                    if (vs[i] == vs[i + 1]) { vs[i] = '0'; }
                }
            }
            return String.Join("", vs).Replace("0", "");
        }
        public static void Main(String[] args)
        {
            string enterword = Console.ReadLine();
            Console.Write(checkout(enterword));
        }
    }
}
