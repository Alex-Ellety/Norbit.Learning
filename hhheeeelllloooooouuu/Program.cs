namespace hhheeeelllloooooouuu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите слово: ");

            string value = Console.ReadLine();

            Console.WriteLine(HasWord(value, "hello"));
        }

        /// <summary>
        /// Определяет можно ли получить <paramref name="targetWord"/>, удалив некоторые буквы из <paramref name="value"/>.
        /// </summary>
        /// <param name="value">слово.</param>
        /// <returns>true, если удалось найти <paramref name="targetWord"/>, в противном случае false.</returns>
        static bool HasWord(string value, string targetWord)
        {
            CheckValueGreaterThan(value, "Ожидается, строка не будет пустой.", nameof(value));

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

        public static void CheckValueGreaterThan(string value, string message,
            string paramName, double limit = 1)
        {
            if (value.Length < limit)
            {
                throw new ArgumentException(message, paramName);
            }
        }
    }
}
