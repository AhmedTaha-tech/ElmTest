namespace Elm.Books.Domain.Models.Books
{
    public record BooksModel
    (
        string SearchCriteria,
        int PageIndex,
        short PageSize
     );
}
