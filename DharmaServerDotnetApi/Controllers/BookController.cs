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
    public async Task<ActionResult<ResponseWrapper<ICollection<Book>>>> GetAllBooks() {

        var rawBookList = await _bookRepository.GetAllBooks();

        var response = CreateResponse<Book, BookDto>.DtoListResponse( rawBookList );

        return Ok( response );
    }

    [HttpGet( "{id}" )]
    public async Task<ActionResult<ResponseWrapper<Book>>> GetBookById( int id ) {

        var book = await _bookRepository.GetBookById( id );

        if (book is null) {
            return NotFound();
        }

        if (!ModelState.IsValid) {
            return BadRequest( ModelState );
        }

        var response = CreateResponse<Book, BookDto>.SingleDtoResponse( book );

        return Ok( response );

    }

    [HttpPost]
    public async Task<ActionResult<ResponseWrapper<Book>>> CreateNewBook( Book newBook ) {

        var createdBook = await _bookRepository.CreateNewBook( newBook );

        var response = CreateResponse<Book, BookDto>.SingleDtoResponse( createdBook );

        return Ok( response );

    }

    // TODO update this to merge provided fields with existing data then save rather than explicitly updating fields
    [HttpPut( "{id}" )]
    public async Task<ActionResult<ResponseWrapper<Book>>> UpdateBook( int id, Book newBookData ) {

        var updatedBook = await _bookRepository.UpdateBook( id,
                newBookData );

        if (updatedBook is null) {
            return NotFound();
        }

        var response = CreateResponse<Book, BookDto>.SingleDtoResponse( updatedBook );

        return Ok( response );

    }

    // TODO change to deleted at timestamp and return nothing
    [HttpDelete( "{id}" )]
    public async Task<ActionResult<ResponseWrapper<Book>>> DeleteBook( int id ) {

        var deletedBook = await _bookRepository.DeleteBook( id );

        var response = CreateResponse<Book, BookDto>.SingleDtoResponse( deletedBook );

        return Ok();

    }

}