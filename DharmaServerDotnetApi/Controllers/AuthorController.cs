using AutoMapper;
using DharmaServerDotnetApi.Helpers;
using DharmaServerDotnetApi.Models;
using DharmaServerDotnetApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DharmaServerDotnetApi.Controllers;

[Route( "api/[controller]" )]
[ApiController]
public class AuthorController : DharmaController {

    private readonly IAuthorRepo _authorRepo;
    private readonly IMapper _mapper;

    public AuthorController( IAuthorRepo authorRepo, IMapper mapper ) {
        _authorRepo = authorRepo;
        _mapper     = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<ICollection<DTOAuthor>>> GetAllAuthors() {
        var authors = _mapper.Map<ICollection<DTOAuthor>>( await _authorRepo.GetAllAuthors() );

        return CreateResponse( authors );
    }

    [HttpGet( "{authorId}" )]
    public async Task<ActionResult<DTOAuthor>> GetAuthorById( int authorId ) {
        var author = _mapper.Map<DTOAuthor>( await _authorRepo.GetAuthorById( authorId ) );

        return CreateResponse( author );
    }

    [HttpGet( "{authorId}/book" )]
    public async Task<ActionResult<ICollection<DTOGetBook>>> GetAuthorBooks( int authorId ) {
        var authorBooks = _mapper.Map<ICollection<DTOGetBook>>( await _authorRepo.GetAuthorBooks( authorId ) );

        return CreateResponse( authorBooks );
    }

}