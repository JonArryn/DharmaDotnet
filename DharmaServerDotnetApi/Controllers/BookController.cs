using AutoMapper;
using DharmaServerDotnetApi.Helpers;
using DharmaServerDotnetApi.Models;
using DharmaServerDotnetApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DharmaServerDotnetApi.Controllers;

[ApiController]
[Route( "api/[controller]" )]
public class BookController : DharmaController {

    private readonly IBookRepo _bookRepo;
    private readonly IMapper _mapper;

    public BookController( IBookRepo bookRepo, IMapper mapper ) {
        _bookRepo = bookRepo;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<ICollection<DTOGetBook>>>
            GetAllBooks( [FromQuery( Name = "embed" )] string? embed ) {

        switch (embed) {
            case null:
            {
                var bookList = _mapper.Map<ICollection<DTOGetBook>>( await _bookRepo.GetAllBooks() );

                return CreateResponse( bookList );
            }
            case "author":
            {
                var bookListWithAuthor =
                        _mapper.Map<ICollection<DTOGetBook>>( await _bookRepo.GetAllBooksWithAuthor() );

                return CreateResponse( bookListWithAuthor );
            }
            default:
                return BadRequest( "Invalid embed" );
        }

    }

    [HttpGet( "{id}" )]
    public async Task<ActionResult<DTOGetBook>> GetBookById( int id ) {
        var book = _mapper.Map<DTOGetBook>( await _bookRepo.GetBookById( id ) );

        return CreateResponse( book );
    }

    [HttpPost]
    public async Task<ActionResult<DTOGetBook>> CreateNewBook( DTOCreateBook newBookDto ) {
        var createdBook = await _bookRepo.CreateBook( newBookDto );

        return CreateResponse( createdBook );
    }

    // TODO update this to merge provided fields with existing data then save rather than explicitly updating fields
    [HttpPut( "{id}" )]
    public async Task<ActionResult<DTOGetBook>> UpdateBook( int id, DTOCreateBook newBookData ) {
        var updatedBook = await _bookRepo.UpdateBook( id, newBookData );

        return CreateResponse( updatedBook );
    }

    // TODO change to deleted at timestamp and return nothing
    [HttpDelete( "{id}" )]
    public async Task<ActionResult<DTOGetBook>> DeleteBook( int id ) {
        var deletedBook = await _bookRepo.DeleteBook( id );

        return CreateResponse( deletedBook );
    }

}