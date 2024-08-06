using BookStore.Models;
using BookStore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {

        private readonly IBookstoreRepository _bookstoreRepository;
        public AuthorsController(IBookstoreRepository bookStoreRepository)
        {
            _bookstoreRepository = bookStoreRepository ?? throw new ArgumentNullException(nameof(bookStoreRepository));
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<AuthorDto>>> GetAuthors()
        {

            //var genres = GenreDataStore.Current.Genres;
            var authorEntities = await _bookstoreRepository.GetAuthorsAsync();

            var results = new List<AuthorDto>();
            foreach (var author in authorEntities)
            {
                results.Add(new AuthorDto
                {
                   AuthorId = author.AuthorId,
                   Name = author.Name,
                   Biography = author.Biography

                });
            }


            return Ok(results);
        }



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