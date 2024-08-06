using BookStore.Models;
using BookStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("/api/books")]
    public class BooksController : ControllerBase
    {
        private readonly IBookstoreRepository _bookstoreRepository;

        public BooksController(IBookstoreRepository bookStoreRepository)
        {
            _bookstoreRepository = bookStoreRepository ?? throw new ArgumentNullException(nameof(bookStoreRepository));
        }

         [HttpGet]

        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooks()
        {

            //var genres = GenreDataStore.Current.Genres;
            var bookEntities = await _bookstoreRepository.GetBooksAsync();

            var results = new List<BookDto>();
            foreach (var book in bookEntities)
            {
                results.Add(new BookDto
                {
                   BookId = book.BookId,
                    Title = book.Title,
                    Price = book.Price,
                    AuthorId = book.AuthorId,
                    GenreId= book.GenreId,
                    PublicationDate= book.PublicationDate 
                });
            }


            return Ok(results);
        }

        // public JsonResult GetBooks()
        //{

        //        }


        ///  [HttpGet("/")]
        // [HttpPost]
        // [HttpPut]
        // [HttpDelete]
    }
}

/*    * GET /books : Retrieve a list of all books
    * GET /books/{book_id} : Retrieve details of a specific book 
    * POST /books : Add a new book
    * PUT /books/{book_id} : Update details of an existing book 
    * DELETE /books/{book_id} : Delete a specific book */