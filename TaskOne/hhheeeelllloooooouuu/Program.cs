namespace hhheeeelllloooooouuu
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Введите исходное слово: ");

            string value = Console.ReadLine();

            Console.Write("Введите искомое слово: ");

            string targetWord = Console.ReadLine();

            Console.WriteLine(HasWord(value, targetWord));
        }

        /// <summary>
        /// Определяет можно ли получить <paramref name="targetWord"/>, удалив некоторые буквы из <paramref name="value"/>.
        /// </summary>
        /// <param name="value">слово.</param>
        /// <returns>true, если удалось найти <paramref name="targetWord"/>, в противном случае false.</returns>
        public static bool HasWord(string value, string targetWord)
        {
            CheckValueGreaterThan(value, "Ожидается, что строка не будет пустой.", nameof(value));
            CheckValueGreaterThan(targetWord, "Ожидается, что строка не будет пустой.", nameof(targetWord));
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
        /// Проверяет, что входные данные <paramref name="value"/> больше <paramref name="limit"/> 
        /// и выводит <paramref name="message"/> при ошибке.
        /// </summary>
        /// <param name="value">Входные данные.</param>
        /// <param name="message">Сообщение ошибки.</param>
        /// <param name="paramName">Параметр, где произошла ошибка.</param>
        /// <param name="limit">Недопустимое значение.</param>
        /// <exception cref="ArgumentException"></exception>
        public static void CheckValueGreaterThan(string value, string message,
            string paramName, int limit = 0)
        {
            if (value.Length <= limit)
            {
                throw new ArgumentException(message, paramName);
            }
        }
    }
}
