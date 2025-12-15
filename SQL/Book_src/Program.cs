using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using System.Linq;

namespace Book_src
{
    internal partial class Program
    {
        public static void Main()
        {
            const string connectionString = @"Data Source=KOMPUTER\SQL2019; Initial Catalog=demobooks; User Id=sa; Password=Ellety1Rock; TrustServerCertificate=True;";

            var classValue = 1;

            var queryString =
              "SELECT " +
                "[title]" +
                ", [author]" +
                ", [year] " +
                ", [publisher]" +
                ", [pages]" +
                ", [genre]" +
                ", [price]" +
                ", [amount]" +
              "FROM [dbo].[books_src] " +
              "WHERE pages > 300 AND price < 1000 " +
              "ORDER BY title";


            var books = new List<Book>();

            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(queryString, connection);

                #region correct params sending
                //"WHERE Class > @classValue " +
                command.Parameters.AddWithValue("@classValue", classValue);
                #endregion

                try
                {
                    connection.Open();
                    using (var book = command.ExecuteReader())
                    {

                        while (book.Read())
                        {
                            books.Add(
                                new Book()
                                {
                                    Title = (string)book[0],
                                    Author = (string)book[1],
                                    Year = GetInt(book[2]),
                                    Publisher = (string)book[3],
                                    Pages = GetInt(book[4]),
                                    Genre = (string)book[5],
                                    Price = (double)book[6],
                                    Amount = GetInt(book[7]),
                                });
                        }
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            DisplayCollection(books);
        }

        private static void DisplayCollection<T>(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }

        public static string GetString(object value)
        {
            if (value == DBNull.Value)
                return null;

            return (string)value;
        }

        public static int? GetInt(object value)
        {
            if (value == DBNull.Value)
                return null;

            return (int)value;
        }
    }
}
