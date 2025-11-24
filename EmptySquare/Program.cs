using System.Text;

namespace EmptySquare
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите число: ");

            int n = Int32.Parse(Console.ReadLine());

            Console.WriteLine(GetEmptySquare(n));
        }
        /// <summary>
        /// Создает пустой квадрат со сторонами длиной <paramref name="n"/>.
        /// </summary>
        /// <param name="n">Длина сторон квадрата.</param>
        /// <returns>пустой квадрат.</returns>
        static string GetEmptySquare(int n)
        {
            CheckValueGreaterThan(n, "Ожидается, что длина стороны больше 0", nameof(n));

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

        public static void CheckValueGreaterThan(int value, string message,
            string paramName, int limit = 1)
        {
            if (value <= limit)
            {
                throw new ArgumentException(message, paramName);
            }
        }

    }
}
