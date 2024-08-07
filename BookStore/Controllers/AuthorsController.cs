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
            
            var author = await _bookstoreRepository.GetAuthorAsync(id);

            if (author == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<AuthorDto>(author));
        }
        [HttpPost]

        public async Task<ActionResult<AuthorDto>> CreateAuthor(AuthorForCreationDto author)
        {
           

            var finalAuthor = _mapper.Map<Entities.Author>(author);

            await _bookstoreRepository.AddAuthor(finalAuthor);

            await _bookstoreRepository.SaveChangesAsync();

            var createdAuthorToReturn = _mapper.Map<Models.AuthorDto>(finalAuthor);

            return CreatedAtRoute("GetAuthor",
                new
                {
                    id = createdAuthorToReturn.AuthorId
                }, finalAuthor);


        }
        [HttpPut("{authorId}")]

        public async Task<ActionResult> UpdateAuthor(int authorId, AuthorForUpdateDto author)
        {

            var authorEntity = await _bookstoreRepository.GetAuthorAsync(authorId);

            if (authorEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(author, authorEntity);
            await _bookstoreRepository.SaveChangesAsync();


            return NoContent();

        }

        [HttpDelete("{authorId}")]

        public async Task<ActionResult> DeleteAuthor(int authorId)

        {
            var authorFromDatabase = await _bookstoreRepository.GetAuthorAsync(authorId);
            if (authorFromDatabase == null)
            {
                return NotFound();
            }

            //GenreDataStore.Current.Genres.Remove(genreFromDatabase);
            _bookstoreRepository.DeleteAuthor(authorFromDatabase);
            await _bookstoreRepository.SaveChangesAsync();

            return NoContent();
        }
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