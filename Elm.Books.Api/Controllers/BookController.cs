using Elm.Books.ApplicationService.Books;
using Elm.Books.Domain.Models.Books;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Elm.Books.Api.Controllers
{
    public class BookController : Controller
    {
        readonly IMediator _mediator;

        public BookController(IMediator mediator) => _mediator = mediator;
        [HttpPost(SearchBooksHandler.ROUTE)]
        [ProducesResponseType(typeof(GetBooksResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<GetBooksResponse>> GetBooks([FromBody] BooksModel booksModel)
                => Ok(await _mediator.Send(new GetBooksRequest(booksModel)));
    }
}
