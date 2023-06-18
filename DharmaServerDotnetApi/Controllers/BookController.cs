using DharmaServerDotnetApi.Helpers;
using DharmaServerDotnetApi.Models;
using DharmaServerDotnetApi.Repositories.BookRepository;
using Microsoft.AspNetCore.Mvc;

namespace DharmaServerDotnetApi.Controllers;

[ApiController]
[Route( "api/[controller]" )]
public class BookController : ControllerBase {

    private readonly IBookRepository _bookRepository;

    public BookController( IBookRepository bookRepository ) {
        _bookRepository = bookRepository;

    }

    [HttpGet]
    public async Task<ActionResult<RepositoryResponse<ICollection<Book>>>> GetAllBooks() {

        var rawBookList = await _bookRepository.GetAllBooks();

        var result = CreateResponses<Book, BookDto>.CreateDtoListResponse( rawBookList );

        return Ok( result );
    }

    [HttpGet( "{id}" )]
    public async Task<ActionResult<Book>> GetBookById( int id ) {

        var result = await _bookRepository.GetBookById( id );

        if (result is null) {
            return NotFound();
        }

        if (!ModelState.IsValid) {
            return BadRequest( ModelState );
        }

        return Ok( result );

    }

    [HttpPost]
    public async Task<ActionResult<Book>> CreateNewBook( Book newBook ) {

        var result = await _bookRepository.CreateNewBook( newBook );

        return Ok( result );

    }

    [HttpPut( "{id}" )]
    public async Task<ActionResult<Book>> UpdateBook( int id, Book newBookData ) {

        var updatedBook = await _bookRepository.UpdateBook( id,
                newBookData );

        if (updatedBook is null) {
            return NotFound();
        }

        return Ok( updatedBook );

    }

    [HttpDelete( "{id}" )]
    public async Task<ActionResult<Book>> DeleteBook( int id ) {

        return Ok( await _bookRepository.DeleteBook( id ) );

    }

}