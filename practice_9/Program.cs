using System;
namespace practice_9
{
    public class Program
    {
        private static int[][] generate2()
        {
            Random random = new Random();
            int[][] h = new int[10][];
            for (int i = 0; i < 10; i++)
            {
                h[i] = new int[random.Next(4, 21)];
            }
            Console.WriteLine("Исходный массив:");
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < h[i].Length; j++)
                {
                    h[i][j] = random.Next(-999,999);
                    Console.Write($"{h[i][j]} ");
                }
                Console.WriteLine($"\n");
            }
            return h;
        }
        public static void Main(String[] args)
        {
            int[][] g = generate2();
            int[] l = new int[g.GetLength(0)];
            int[] maxs = new int[g.GetLength(0)];
            int k;
            int[] countm = new int[g.GetLength(0)];
            int ind1 = 0;
            int ind2 = 0;
            for (int i = 0; i < g.GetLength(0); i++)
            {
                k = g[i][0];
                for (int j = 0; j < g[i].Length; j++)
                {
                    if (g[i][j] > k)
                    {
                        countm[i] += g[i][j];
                        k = g[i][j];
                        ind1 = i;
                        ind2 = j;
                    }
                }
                countm[i] /= g[i].Length;
                maxs[i] = k;
                l[i] = g[i][g[i].Length - 1];
                k = g[i][0];
                g[i][0] = g[ind1][ind2];
            }
            
            Console.WriteLine($"Массив с последними элементами из каждой строки зубчатой матрицы: ");
            for (k = 0; k < l.Length; k++)
            {
                Console.Write($"{l[k]} ");
            }
            Console.WriteLine($"\nМассив с максимальными элементами из каждой строки зубчатой матрицы: ");
            for (k = 0; k < maxs.Length; k++)
            {
                Console.Write($"{maxs[k]} ");
            }
            Console.WriteLine($"\nИзмененная Матрица");
            for (int i = 0; i < g.GetLength(0); i++)
            {
                for( int j = 0; j < g[i].Length; j++)
                {
                    Console.Write($"{g[i][j]} ");
                }
                Console.WriteLine($"\n");
            }
            Console.WriteLine($"\nРеверсная полученная матрица");
            for (int i = 0; i < g.GetLength(0); i++)
            {
                Array.Reverse(g[i]);
                for (int j = 0; j < g[i].Length; j++)
                {
                    Console.Write($"{g[i][j]} ");
                }
                Console.WriteLine($"\n");
            }
            Console.WriteLine($"\nСреднее число в каждой строке");
            for (int i=0; i < g.GetLength(0); i++)
            {
                Console.Write($"{countm[i]} ");
            }
        }
    }
}