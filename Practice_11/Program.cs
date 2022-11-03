using System;
namespace Practice_11
{
    public class Program
    {
        public static string checkonright(String word)
        {
            /*
             первая версия кода
            byte R = 0;
            string[] domen = new string[] {".com", ".ru", ".ua",".hiz"};
            foreach(char c in word)
            {
                if(c == '@')
                {
                    R++;
                }
                else if(Char.IsPunctuation(c))
                {
                    if (c == '!'|| c =='-'||c =='_' || c == '.')
                    {
                        R++;
                    }
                    else { break;}
                }
                else if (Char.IsLetter(c)) { R++; }
            }
            for (int i = 0; i < domen.Length; i++) { if (word.EndsWith(domen[i])) { R++; } }
            if (R == word.Length+1  ) word = "Correct Mail";
            else word = "Error: Incorrect mail!";
            */
            byte R = 0; 
            string[] parts = new string[3];
            for(int i = 0; i < parts.Length; i++)
            {
                foreach(char j in word)
                {
                    if (j != '@') parts[i] += j;
                    else { parts[i] += j; break; }
                }
            }
                for (int j = 0; j < parts[0].Length; j++)
                {
                    if (Char.IsDigit(parts[0][j]) || parts[0][j]>='a' && parts[0][j]<='z' || parts[0][j]>='A' && parts[0][j] >= 'Z'|| parts[0][j] == '!' || parts[0][j] == '-' || parts[0][j] == '_' || parts[0][j] == '.')
                    {
                    R++;
                    }
                }
            return word;
        }
        public static void Main(String[] args)
        {
            String mail = Console.ReadLine();
            Console.WriteLine(checkonright(mail));

        }
    }
}