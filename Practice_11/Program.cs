using System;
namespace Practice_11
{
    public class Program
    {
        public static string checkonright(String word)
        {
            byte r = 0;
            char[] vs = new char[word.Length];
            for (int i = 0; i < word.Length; i++) vs[i] = (char)word[i];
            string[] parts = new string[3];
            int g = 0;
            for (int i = 0; i < vs.Length; i++)
            {
                if (vs[i] != '@') parts[g] += vs[i].ToString();
                else { parts[g + 1] = vs[i].ToString(); g += 2; }
            }
            for (int j = 0; j < parts[0].Length; j++)
            {
                if (Char.IsDigit(parts[0][j]) || parts[0][j]>='a' && parts[0][j]<='z' || parts[0][j]>='A' && parts[0][j] <= 'Z'|| parts[0][j] == '!' || parts[0][j] == '-' || parts[0][j] == '_' || parts[0][j] == '.')
                {
                r++;
                }
                else word = "Error: Incorrect mail!";
            }
            if (parts[1] == "@") r++;
            else word = "Error: Incorrect mail!";
            for (int i = 0; i < parts[2].Length; i++)
            {
                if (parts[2][i] >= 'a' && parts[2][i] <= 'z' || parts[2][i] >= 'A' && parts[2][i] <= 'Z')
                {
                    r++;
                }
                else if (parts[2][i] == '.')
                {
                    r++;
                }
                else word = "Error: Incorrect mail!";
            }
            if (r == word.Length) word = "Correct mail";
            else word = "Error: Incorrect mail!";
            return word;
        }
        public static void Main(String[] args)
        {
            String mail = Console.ReadLine();
            Console.WriteLine(checkonright(mail));

        }
    }
}