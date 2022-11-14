/*требуется метод, генерирующий двумерную матрицу символов, заполненную пробелами
 второй метод принимает координаты XY в этой матрице вызывает первый метод и в этих координатах символ "*" */
using System;
namespace Practice_13_addition
{
    public class program
    {
        public static string[][] generate2()
        {
            Random rnd = new Random();
            string[][] matrix = new string[rnd.Next(2,49)+1][];
            matrix[0] = new string[matrix.Length];
            for (int i = 0; i < matrix.Length; i++)
            {
                if (i < 10) matrix[0][i] = Convert.ToString(i) + "_";
                else matrix[0][i] = Convert.ToString(i);
            }
            for(int i = 1; i < matrix.Length; i++)
            {
                matrix[i] = new string[matrix.Length];
                for(int j = 0; j < matrix[i].Length; j++)
                {

                    if (i < 10) matrix[i][0] = Convert.ToString(i) + "_";
                    else matrix[i][0] = Convert.ToString(i);
                    matrix[i][j] = "  ";
                }
            }
            Console.WriteLine($"матрица была создана размером {matrix[0].Length-1} на {matrix[0].Length - 1}");
            return matrix;
        }
        public static string[][] FindAndChange(string[][] matrix)
        {
            Console.Write("Введите первую координату в пределах матрицы: ");
            int X = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите вторую координату в пределах матрицы: ");
            int Y = Convert.ToInt32(Console.ReadLine());
            matrix[X][Y] = "*";
            return matrix;
        }
        public static void Main(string[] args)
        {
            string[][] matrix = generate2();
            FindAndChange(matrix);
            for(int i = 0; i < matrix.Length ; i++)
            {
                for(int j = 0; j<matrix[i].Length; j++)
                {
                    Console.Write($"{matrix[i][j]} ");
                }
                Console.Write($"\n");
            }
        }
    }
}
