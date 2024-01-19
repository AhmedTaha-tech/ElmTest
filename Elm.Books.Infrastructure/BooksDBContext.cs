using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
namespace Elm.Books.Infrastructure
{
    public class BooksDBContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public BooksDBContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }
        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);
    }
}
