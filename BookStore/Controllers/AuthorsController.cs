using AutoMapper;
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
        private readonly IMapper _mapper;
        public AuthorsController(IBookstoreRepository bookStoreRepository, IMapper mapper)
        {
            _bookstoreRepository = bookStoreRepository ?? throw new ArgumentNullException(nameof(bookStoreRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<AuthorDto>>> GetAuthors()
        {

            //var genres = GenreDataStore.Current.Genres;
            var authorEntities = await _bookstoreRepository.GetAuthorsAsync();

            return Ok(_mapper.Map<IEnumerable<AuthorDto>>(authorEntities));


        }



        [HttpGet("{id}", Name = "GetAuthor")]

        public async Task<ActionResult<AuthorDto>> GetAuthor(int id)
        {
            //var genreToReturn = GenreDataStore.Current.Genres.FirstOrDefault(c => c.GenreId == id);

            var author = await _bookstoreRepository.GetAuthorAsync(id);

            if (author == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<AuthorDto>(author));
        }
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