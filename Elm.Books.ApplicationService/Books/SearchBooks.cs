using Elm.Books.Domain.Contracts;
using Elm.Books.Domain.Models.Books;
using MediatR;

namespace Elm.Books.ApplicationService.Books;
public record GetBooksRequest(BooksModel BooksModel) : IRequest<GetBooksResponse>;
public class GetBooksResponse
{
    public List<BooksData> booksData { get; set; }
}
public class SearchBooksHandler : IRequestHandler<GetBooksRequest, GetBooksResponse>
{
    public const string ROUTE = "api/V1/GetBooks";

    private readonly IBookRepository _bookRepository;

    public SearchBooksHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<GetBooksResponse> Handle(GetBooksRequest req, CancellationToken cancellationToken)
    {
        var books = await _bookRepository.GetAllBooksAsync(req.BooksModel);
        return new GetBooksResponse()
        {
            booksData = books.ToList()
        };
    }
}
