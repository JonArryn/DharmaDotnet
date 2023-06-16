using DharmaServerDotnetApi.Models;
using DharmaServerDotnetApi.Services.BookService;
using Microsoft.AspNetCore.Mvc;

namespace DharmaServerDotnetApi.Controllers;

[ApiController]
[Route( "api/[controller]" )]
public class BookController : ControllerBase {

    private readonly IBookService _bookService;

    public BookController( IBookService bookService ) {
        _bookService = bookService;

    }

    [HttpGet]
    public async Task<ActionResult<List<Book>>> GetAllBooks() {

        return await _bookService.GetAllBooks();
    }

    [HttpGet( "{id}" )]
    public async Task<ActionResult<Book>> GetBookById( int id ) {

        var result = await _bookService.GetBookById( id );

        if (result is null) {
            return NotFound( "Book not found" );
        }

        return Ok( result );
    }

    [HttpPost]
    public async Task<ActionResult<Book>> CreateNewBook( Book newBook ) {

        var result = await _bookService.CreateNewBook( newBook );

        return Ok( result );

    }

    [HttpPut( "{id}" )]
    public async Task<ActionResult<Book>> UpdateBook( int id, Book newBookData ) {

        var updatedBook = await _bookService.UpdateBook( id,
                newBookData );

        if (updatedBook is null) {
            return NotFound();
        }

        return Ok( updatedBook );

    }

    [HttpDelete( "{id}" )]
    public async Task<ActionResult<Book>> DeleteBook( int id ) {

        return Ok( await _bookService.DeleteBook( id ) );

    }

}