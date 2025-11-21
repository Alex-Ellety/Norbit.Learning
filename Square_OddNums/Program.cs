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

            Console.WriteLine(GetString(n));
        }
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

        static string GetString(int n)
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
