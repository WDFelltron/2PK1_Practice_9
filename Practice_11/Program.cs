using System;
namespace Practice_11
{
    public class Program
    {
        public static string checkonright(String word)
        {
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
            return word;
        }
        public static void Main(String[] args)
        {
            String mail = Console.ReadLine();
            Console.WriteLine(checkonright(mail));

        }
    }
}