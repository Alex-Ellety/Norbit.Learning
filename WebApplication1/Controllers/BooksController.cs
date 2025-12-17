using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        const string connectionString = @"Data Source=KOMPUTER\SQL2019; Initial Catalog=demobooks; User Id=sa; Password=Ellety1Rock; TrustServerCertificate=True;";

        // GET: api/BooksController
        [HttpGet]
        public ActionResult GetAllBooks()
        {
            try
            {
                var queryString = @"
                    SELECT 
                        [title], [author], [year], [publisher], 
                        [pages], [genre], [price]
                    FROM [dbo].[books_src]
                    WHERE pages > 400
                    ORDER BY [title]";

                var books = new List<Book>();

                using (var connection = new SqlConnection(connectionString))
                {
                    var command = new SqlCommand(queryString, connection);

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
                                        Title = GetString(book[0]),
                                        Author = GetString(book[1]),
                                        Year = GetInt(book[2]),
                                        Publisher = GetString(book[3]),
                                        Pages = GetInt(book[4]),
                                        Genre = GetString(book[5]),
                                        Price = GetDouble(book[6]),
                                    });
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        return StatusCode(500, new { error = ex.Message });
                    }
                }

                return Ok(books);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
        private string? GetString(object value)
        {
            return value == DBNull.Value ? null : (string)value;
        }

        private int? GetInt(object value)
        {
            return value == DBNull.Value ? null : (int)value;
        }

        private double GetDouble(object value)
        {
            return value == DBNull.Value ? 0 : (double)value;
        }
    }
}
