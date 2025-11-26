using System.Text;

namespace Norbit.Learning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите число: ");

            int n = Int32.Parse(Console.ReadLine());

            //Console.WriteLine(GetEmptySquare(n));

            //string value = Console.ReadLine();

            //Console.WriteLine(HasWord(value, "hello"));

            //List<int> oddNumbers = GetOddNumbers(n);

            //Console.WriteLine(string.Join(", ", oddNumbers));

            //Console.WriteLine(GetSquare(n));

            //Console.Write("Введите положительное нечётное целое число: ");

            //int n = int.Parse(Console.ReadLine());

            //Console.WriteLine(GetArrow(n));
        }
        /// <summary>
        /// Создает пустой квадрат со сторонами длиной <paramref name="n"/>.
        /// </summary>
        /// <param name="n">Длина сторон квадрата.</param>
        /// <returns>пустой квадрат.</returns>
        static string GetEmptySquare(int n)
        {
            CheckValueGreaterThan(n, "Ожидается, что длина стороны больше 0.", nameof(n));

            string square = "";

            string topAndBottom = new string('X', n);

            StringBuilder emptyMiddle = new StringBuilder();
            emptyMiddle.Append('X');
            emptyMiddle.Append(new string(' ', n - 2));
            emptyMiddle.Append('X');

            string middle = emptyMiddle.ToString();

            for (int i = 1; i <= n; i++)
            {
                if (i == 1 || i == n)
                    square += topAndBottom;
                else
                    square += middle;

                square += "\n";
            }

            return square;
        }

        /// <summary>
        /// Определяет можно ли получить <paramref name="targetWord"/>, удалив некоторые буквы из <paramref name="value"/>.
        /// </summary>
        /// <param name="value">слово.</param>
        /// <returns>true, если удалось найти <paramref name="targetWord"/>, в противном случае false.</returns>
        static bool HasWord(string value, string targetWord)
        {
            CheckValueGreaterThan(value.Length, "Ожидается, строка не будет пустой.", nameof(value));

            int initIndex = 0;

            List<char> chars = new List<char>();

            for (int i = 0; i < targetWord.Length; i++)
            {
                for (int j = initIndex; j < value.Length; j++)
                {
                    if (value[j] == targetWord[i])
                    {
                        chars.Add(value[j]);
                        initIndex = j + 1;
                        break;
                    }
                }
            }

            string result = string.Join("", chars);

            return result == targetWord;
        }

        /// <summary>
        /// Создает список нечетных чисел в диапазоне от 1 до <paramref name="n"/>.
        /// </summary>
        /// <param name="n">Граница диапазона.</param>
        /// <returns>список нечетных чисел от 1 до <paramref name="n"/>.</returns>
        static List<int> GetOddNumbers(int n)
        {
            CheckValueGreaterThan(n, "Ожидается, что вводное число больше 0.", nameof(n));

            List<int> numbers = new List<int>();

            for (int i = 1; i <= n; i++)
            {
                if (i % 2 != 0)
                    numbers.Add(i);
            }

            return numbers;
        }

        /// <summary>
        /// Создает квадрат, заполненный символом 'X' со сторонами длиной <paramref name="n"/>.
        /// </summary>
        /// <param name="n">Длина сторон квадрата.</param>
        /// <returns>квадрат.</returns>
        static string GetSquare(int n)
        {
            CheckValueGreaterThan(n, "Ожидается, что длина стороны больше 0.", nameof(n));

            string square = "";

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    square += "X";
                }

                square += "\n";
            }

            return square;
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
            string result = "";
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
                    result += matrix[i][j];
                }
                result += "\n";
            }

            return result;
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
            string result = "";

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
                    result += matrix[i][j];
                }
                result += "\n";
            }

            return result;
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
            string result = "";
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
                    result += matrix[i][j] + " ";
                }
                result += "\n";
            }

            return result;
        }

        public static void CheckValueGreaterThan(int value, string message,
            string paramName, int limit = 0)
        {
            if (value <= limit)
            {
                throw new ArgumentException(message, paramName);
            }
        }
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
