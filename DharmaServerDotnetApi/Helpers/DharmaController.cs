using Microsoft.AspNetCore.Mvc;

namespace DharmaServerDotnetApi.Helpers;

public abstract class DharmaController : ControllerBase {

    protected ActionResult<T> CreateResponse<T>( T data ) {
        if (data is null) {
            return NotFound( "Data not found in the dharma library" );
        }

        if (!ModelState.IsValid) {
            return BadRequest( ModelState );
        }

        var response = new ResponseWrapper<T>{
            Data = data,
        };

        return Ok( response );
    }

    protected IActionResult CreateErrorResponse( string errorMessage ) {
        var errorResponse = new{
            error = errorMessage,
        };

        return BadRequest( errorResponse );
    }

}