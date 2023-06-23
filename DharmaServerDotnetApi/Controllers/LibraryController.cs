using DharmaServerDotnetApi.Helpers;
using DharmaServerDotnetApi.Models;
using DharmaServerDotnetApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DharmaServerDotnetApi.Controllers;

[Route( "api/[controller]" )]
[ApiController]
public class LibraryController : DharmaController {

    private readonly IBaseRepo _libraryRepo;

    public LibraryController( IBaseRepo libraryRepo ) {
        _libraryRepo = libraryRepo;

    }

    // CREATE

    [HttpPost]
    public async Task<ActionResult<DTOGetLibrary>> CreateLibrary( [FromBody] DTOCreateLibrary newLibrary ) {
        var result = await _libraryRepo.CreateEntity<Library, DTOCreateLibrary, DTOGetLibrary>( newLibrary );

        return CreateResponse( result );
    }

    // READ
    [HttpGet]
    public async Task<ActionResult<ICollection<DTOGetLibrary>>> GetAllLibraries() {

        var result = await _libraryRepo.GetAllEntities<Library, DTOGetLibrary>();
        return CreateResponse( result );
    }

    [HttpGet( "{id}" )]
    public async Task<ActionResult<DTOGetLibrary>> GetLibraryById( int id ) {
        var result = await _libraryRepo.GetEntityById<Library, DTOGetLibrary>( id );

        return CreateResponse( result );
    }

}