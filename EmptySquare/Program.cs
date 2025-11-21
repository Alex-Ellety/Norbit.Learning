namespace EmptySquare
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите число: ");

            int n = Int32.Parse(Console.ReadLine());

            Console.WriteLine(GetString2(n));
        }
        static string GetString2(int n)
        {
            string str = "";

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                    if (i == 1 || i == n || j == 1 || j == n)
                        str += "X";
                    else
                        str += " ";

                str += "\n";
            }

            return str;
        }

    }
}
