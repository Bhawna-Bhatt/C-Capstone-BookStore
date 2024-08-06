using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        //[HttpGet]


        // [HttpGet("/")]
        //[HttpPost]
        //[HttpPut]
        //[HttpDelete]
    }
}


/*
 * 2. Authors:
    * GET /authors : Retrieve a list of all authors
    * GET /authors/{author_id} : Retrieve details of a specific author 
    * POST /authors : Add a new author
    * PUT /authors/{author_id} : Update details of an existing author 
    * DELETE /authors/{author_id} : Delete a specific author
    * */