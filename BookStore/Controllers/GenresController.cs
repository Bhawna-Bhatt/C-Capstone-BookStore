using AutoMapper;
using BookStore.Models;
using BookStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("/api/genres")]
    public class GenresController : ControllerBase
    {
        
            //Logger

           // private readonly ILogger<GenresController> _logger;
           private readonly IBookstoreRepository _bookstoreRepository;
            private readonly IMapper _mapper;

        public GenresController(IBookstoreRepository bookStoreRepository,
                IMapper mapper)
        {
           _bookstoreRepository = bookStoreRepository ?? throw new ArgumentNullException(nameof(bookStoreRepository));

            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        //   GET /genres : Retrieve a list of all genres

        [HttpGet]

            public async Task<ActionResult<IEnumerable<GenreDto>>> GetGenres()
            {

            //var genres = GenreDataStore.Current.Genres;
            var genreEntities = await _bookstoreRepository.GetGenresAsync();


            return Ok(_mapper.Map<IEnumerable<GenreDto>>(genreEntities));
            }

          //  GET /genres/{genre_id} : Retrieve details of a specific genre 


        [HttpGet("{id}", Name ="GetGenre")]

        public async Task<ActionResult<GenreDto>> GetGenre(int id)
        {
            //var genreToReturn = GenreDataStore.Current.Genres.FirstOrDefault(c => c.GenreId == id);

            var genre = await _bookstoreRepository.GetGenreAsync(id);

            if (genre == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<GenreDto>(genre));



        }
       
        //    * POST /genres : Add a new genre

        [HttpPost]

        public async Task<ActionResult<GenreDto>> CreateGenre(GenreForCreationDto genre) 
        {
            //var genreId = GenreDataStore.Current.Genres.Count() + 1;

            // var finalGenre = new GenreDto()
            //{
            //   GenreId = genreId,
            //   GenreName = genre.GenreName
            //};

            var finalGenre = _mapper.Map<Entities.Genre>(genre);

            await _bookstoreRepository.AddGenre(finalGenre);

            //GenreDataStore.Current.Genres.Add(finalGenre);

            await _bookstoreRepository.SaveChangesAsync();

            var createdGenreToReturn = _mapper.Map<Models.GenreDto>(finalGenre);

            return CreatedAtRoute("GetGenre",
                new
                {
                   id = createdGenreToReturn.GenreId
                }, finalGenre);

            
        }

        [HttpPut("{genreId}")]

        public async Task<ActionResult> UpdateGenre(int genreId, GenreForUpdateDto genre)
        {

            var genreEntity = await _bookstoreRepository.GetGenreAsync(genreId);

            if (genreEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(genre,genreEntity);
            await _bookstoreRepository.SaveChangesAsync();


            return NoContent();

        }

        [HttpDelete("{genreId}")]

        public async Task<ActionResult> DeleteGenre(int genreId)

        {
            var genreFromDatabase = await _bookstoreRepository.GetGenreAsync(genreId);
            if (genreFromDatabase == null)
            {
                return NotFound();
            }

            //GenreDataStore.Current.Genres.Remove(genreFromDatabase);
            _bookstoreRepository.DeleteGenre(genreFromDatabase);
            await _bookstoreRepository.SaveChangesAsync();
            
            return NoContent();
        }

           
        
    }

  
}

/*
 * Genres:
GET /genres : Retrieve a list of all genres
GET /genres/{genre_id} : Retrieve details of a specific genre 
POST /genres : Add a new genre */
