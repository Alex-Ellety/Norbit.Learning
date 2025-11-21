namespace hhheeeelllloooooouuu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();

            Console.WriteLine(HasHello(s));
        }

        static string HasHello(string s)
        {
            string s1 = "hello";
            int initial = 0;

            List<char> chars = new List<char>();

            for (int i = 0; i < s1.Length; i++)
            {
                for (int j = initial; j < s.Length; j++)
                {
                    if (s[j] == s1[i])
                    {
                        chars.Add(s[j]);
                        initial = j + 1;
                        break;
                    }                                     
                }
            }

            string result = string.Join("", chars);

            if (result == s1)
                return "YES";
            else
                return "NO";
        }
    }
}
