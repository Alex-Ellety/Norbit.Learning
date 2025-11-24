using System.Threading.Channels;

namespace Square_OddNums
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите число: ");

            int n = Int32.Parse(Console.ReadLine());

            List<int> oddNumbers = GetOddNumbers(n);

            Console.WriteLine(string.Join(", ", oddNumbers));

            Console.WriteLine(GetSquare(n));
        }

        /// <summary>
        /// Создает список нечетных чисел в диапазоне от 1 до <paramref name="n"/>.
        /// </summary>
        /// <param name="n">Граница диапазона.</param>
        /// <returns>список с нечетных чисел от 1 до <paramref name="n"/>.</returns>
        static List<int> GetOddNumbers(int n)
        {
            List<int> numbers = new List<int>();

            for (int i = 1; i <= n; i++)
            {
                if (i % 2 != 0)
                    numbers.Add(i);
            }

            return numbers;
        }

        /// <summary>
        /// Создает квадрат, заполненный символом "X" со сторонами длиной <paramref name="n"/>.
        /// </summary>
        /// <param name="n">Длина сторон квадрата.</param>
        /// <returns>квадрат.</returns>
        static string GetSquare(int n)
        {
            string str = "";

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    str += "X";
                }

                str += "\n";
            }

            return str;
        }
    }
}
