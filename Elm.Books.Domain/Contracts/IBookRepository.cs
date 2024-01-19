using Elm.Books.Domain.Entities;
using Elm.Books.Domain.Models.Books;

namespace Elm.Books.Domain.Contracts
{
    public interface IBookRepository
    {
        Task<IEnumerable<BooksData>> GetAllBooksAsync(BooksModel booksModel);
    }
}
