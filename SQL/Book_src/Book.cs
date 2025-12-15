namespace Book_src
{
    internal partial class Program
    {
        public class Book
        {
            public string Title { get; set; }
            public string Author { get; set; }
            public int? Year { get; set; }
            public string Publisher { get; set; }
            public int? Pages { get; set; }
            public string Genre { get; set; }
            public double Price { get; set; }
            public int? Amount { get; set; }

            public override string ToString()
            {
                return $"{Title}, {Author}, {Year}, {Publisher}, " +
                    $"{Pages}, {Genre}, {Price}, {Amount}";
            }
        }
    }
}
