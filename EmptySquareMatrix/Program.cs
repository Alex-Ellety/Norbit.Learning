using System.Drawing;

namespace EmptySquareMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите число: ");

            int n = Int32.Parse(Console.ReadLine());

            SquareMatrix(n);
        }
        static void SquareMatrix(int n)
        {
            char[][] matrix = new char[n][];

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = new char[n];

                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (i == 0 || i == n - 1 || j == 0 || j == n - 1)
                        matrix[i][j] = 'X';
                    else
                        matrix[i][j] = ' ';
                }
            }

            foreach (char[] row in matrix)
            {
                foreach (char c in row)
                {
                    Console.Write(c + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
