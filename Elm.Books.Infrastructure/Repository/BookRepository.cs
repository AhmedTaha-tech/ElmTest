using Dapper;
using Elm.Books.Domain.Contracts;
using Elm.Books.Domain.Entities;
using Elm.Books.Domain.Models.Books;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Elm.Books.Infrastructure.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BooksDBContext _booksDBContext;

        public BookRepository(BooksDBContext booksDBContext)
        {
            _booksDBContext = booksDBContext;
        }

        public async Task<IEnumerable<BooksData>> GetAllBooksAsync(BooksModel booksModel)
        {
            using (var connection = _booksDBContext.CreateConnection())
            {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("SearchCriteria", booksModel.SearchCriteria);
                    parameters.Add("PageIndex", booksModel.PageIndex);
                    parameters.Add("@PageSize", booksModel.PageSize);
                    return await connection.QueryAsync<BooksData>("GteBooks", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
