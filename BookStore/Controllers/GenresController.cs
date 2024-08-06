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
            
            public GenresController(IBookstoreRepository bookStoreRepository)
        {
           _bookstoreRepository = bookStoreRepository ?? throw new ArgumentNullException(nameof(bookStoreRepository));
        }
   
      
            [HttpGet]

            public async Task<ActionResult<IEnumerable<GenreDto>>> GetGenres()
            {

            //var genres = GenreDataStore.Current.Genres;
            var genreEntities = await _bookstoreRepository.GetGenresAsync();

            var results = new List<GenreDto>();
            foreach (var genre in genreEntities)
            {
                results.Add(new GenreDto
                {
                    GenreId = genre.GenreId,
                    GenreName = genre.GenreName
                });
            }
        

            return Ok(results);
            }


        [HttpGet("{id}", Name ="GetGenre")]

        public ActionResult<GenreDto> GetGenre(int id)
        {
            var genreToReturn = GenreDataStore.Current.Genres.FirstOrDefault(c => c.GenreId == id);

            if (genreToReturn == null)
            {
                return NotFound();
            }

            return Ok(genreToReturn);
 }
        [HttpPost]

        public ActionResult<GenreDto> CreateGenre(GenreForCreationDto genre) 
        {
            var genreId = GenreDataStore.Current.Genres.Count() + 1;

            var finalGenre = new GenreDto()
            {
                GenreId = genreId,
                GenreName = genre.GenreName
            };

            GenreDataStore.Current.Genres.Add(finalGenre);

            return CreatedAtRoute("GetGenre",
                new
                {
                    id = genreId
                },finalGenre);

            
        }

        [HttpPut("{genreId}")]

        public ActionResult UpdateGenre(int genreId, GenreForUpdateDto genre)
        {
            var genreFromDatabase = GenreDataStore.Current.Genres
                    .FirstOrDefault(c=>c.GenreId == genreId);
            if(genreFromDatabase == null)
            {
                return NotFound();
            }

            genreFromDatabase.GenreId = genreId;
            genreFromDatabase.GenreName = genre.GenreName;

            return NoContent();

        }

        [HttpDelete("{genreId}")]

        public ActionResult DeleteGenre(int genreId)

        {
            var genreFromDatabase = GenreDataStore.Current.Genres
                   .FirstOrDefault(c => c.GenreId == genreId);
            if (genreFromDatabase == null)
            {
                return NotFound();
            }

            GenreDataStore.Current.Genres.Remove(genreFromDatabase);
            return NoContent();
        }

           
        
    }

  
}

/*
 * Genres:
GET /genres : Retrieve a list of all genres
GET /genres/{genre_id} : Retrieve details of a specific genre 
POST /genres : Add a new genre */
