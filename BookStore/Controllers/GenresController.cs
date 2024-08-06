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
   
      
            [HttpGet]

            public async Task<ActionResult<IEnumerable<GenreDto>>> GetGenres()
            {

            //var genres = GenreDataStore.Current.Genres;
            var genreEntities = await _bookstoreRepository.GetGenresAsync();


            return Ok(_mapper.Map<IEnumerable<GenreDto>>(genreEntities));
            }


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
