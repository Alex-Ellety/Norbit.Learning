using System.Linq;
using System.Text;

namespace Figures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите положительное нечётное целое число: ");

            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(GetArrow(n));
        }

        /// <summary>
        /// Создает ромб из символов 'X', где длина каждой диагонали равна <paramref name="n"/>, n - положительное нечётное целое число.
        /// </summary>
        /// <param name="n">Длина диагонали.</param>
        /// <param name="border">Символ для заполнения краев фигуры.</param>
        /// <param name="middle"></param>
        /// <returns>Ромб со сторонами длиной <paramref name="n"/>.</returns>
        static string GetDiamond(int n, char border = 'X', char middle = ' ')
        {
            CheckValueGreaterThan(n, "Ожидается, что число будет больше 0.", nameof(n));
            CheckValueIsOdd(n, "Ожидается, что число будет нечетное.", nameof(n));

            char[][] matrix = new char[n][];
            StringBuilder result = new StringBuilder();
            int center = n / 2;

            for (int i = 0; i < n; i++)
            {
                matrix[i] = new char[n];
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i + j == center ||
                        i - j == center ||
                        j - i == center ||
                        i + j == center + (n - 1))
                    {
                        matrix[i][j] = border;
                    }
                    else
                    {
                        matrix[i][j] = middle;
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    result.Append(matrix[i][j]);
                }
                result.Append("\n");
            }

            return result.ToString();
        }

        /// <summary>
        /// Создает треугольник из символов 'X', где длина каждой диагонали равна <paramref name="n"/>, n - положительное нечётное целое число.
        /// </summary>
        /// <param name="n">Длина диагонали.</param>
        /// <param name="border">Символ для заполнения краев фигуры.</param>
        /// <param name="middle"></param>
        /// <returns>Треугольник со сторонами длиной <paramref name="n"/>.</returns>
        static string GetTriangle(int n, char border = 'X', char middle = ' ')
        {
            CheckValueGreaterThan(n, "Ожидается, что число будет больше 0.", nameof(n));
            CheckValueIsOdd(n, "Ожидается, что число будет нечетное.", nameof(n));

            char[][] matrix = new char[n][];
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                matrix[i] = new char[n];
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (j == 0 || i == n - 1 || j == i)
                    {
                        matrix[i][j] = border;
                    }
                    else
                    {
                        matrix[i][j] = middle;
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    result.Append(matrix[i][j]);
                }
                result.Append("\n");
            }

            return result.ToString();
        }

        /// <summary>
        /// Создает стрелку вправо из символов 'X' размером <paramref name="n"/>, n - положительное нечётное целое число.
        /// </summary>
        /// <param name="n">Размер стрелки.</param>
        /// <param name="border">Символ для заполнения краев фигуры.</param>
        /// <param name="middle"></param>
        /// <returns>Стрелку вправо.</returns>
        static string GetArrow(int n, char border = 'X', char middle = ' ')
        {
            CheckValueGreaterThan(n, "Ожидается, что число будет больше 0.", nameof(n));
            CheckValueIsOdd(n, "Ожидается, что число будет нечетное.", nameof(n));

            char[][] matrix = new char[n][];
            StringBuilder result = new StringBuilder();
            int center = n / 2;

            for (int i = 0; i < n; i++)
            {
                matrix[i] = new char[n];
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (j == 0 ||
                        (j == i && i <= center) ||
                        (j == (n - 1) - i) && (i > center))
                    {
                        matrix[i][j] = border;
                    }
                    else
                    {
                        matrix[i][j] = middle;
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    result.Append(matrix[i][j]);
                }
                result.Append("\n");
            }

            return result.ToString();
        }

        /// <summary>
        /// Проверяет, что входные данные <paramref name="value"/> больше <paramref name="limit"/> 
        /// и выводит <paramref name="message"/> при ошибке.
        /// </summary>
        /// <param name="value">Входные данные.</param>
        /// <param name="message">Сообщение ошибки.</param>
        /// <param name="paramName">Параметр, где произошла ошибка.</param>
        /// <param name="limit">Недопустимое значение.</param>
        /// <exception cref="ArgumentException"></exception>
        public static void CheckValueGreaterThan(int value, string message,
            string paramName, int limit = 0)
        {
            if (value <= limit)
            {
                throw new ArgumentException(message, paramName);
            }
        }

        /// <summary>
        /// Проверяет число <paramref name="value"/> на нечетность и выводит <paramref name="message"/> при ошибке.
        /// </summary>
        /// <param name="value">Входные данные для проверки.</param>
        /// <param name="message">Сообщение ошибки.</param>
        /// <param name="paramName">Параметр, где произошла ошибка.</param>
        /// <exception cref="ArgumentException"></exception>
        public static void CheckValueIsOdd(int value, string message,
            string paramName)
        {
            if (value % 2 == 0)
            {
                throw new ArgumentException(message, paramName);
            }
        }
    }
}
