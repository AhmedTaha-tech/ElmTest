using Elm.Books.ApplicationService.Books;
using Elm.Books.Domain.Models.Books;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Elm.Books.Api.Controllers
{
    public class BookController : Controller
    {
        readonly IMediator _mediator;
        /// <summary>
        /// Serach by Book Title, Book Description,Author, Publish Date (Format yyyy-MM-dd ex:2022-07-17)
        /// </summary>
        public BookController(IMediator mediator) => _mediator = mediator;
        [HttpGet(SearchBooksHandler.ROUTE)]
        [ProducesResponseType(typeof(GetBooksResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<GetBooksResponse>> GetBooks([FromQuery] BooksModel booksModel)
                => Ok(await _mediator.Send(new GetBooksRequest(booksModel)));
    }
}
