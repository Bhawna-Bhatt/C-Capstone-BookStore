using AutoMapper;
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
        private readonly IMapper _mapper;

        public BooksController(IBookstoreRepository bookStoreRepository, IMapper mapper)
        {
            _bookstoreRepository = bookStoreRepository ?? throw new ArgumentNullException(nameof(bookStoreRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooks()
        {

            //var genres = GenreDataStore.Current.Genres;
            var bookEntities = await _bookstoreRepository.GetBooksAsync();

            // var results = new List<BookDto>();
            //foreach (var book in bookEntities)
            //{
            //   results.Add(new BookDto
            //  {
            //     BookId = book.BookId,
            //    Title = book.Title,
            //   Price = book.Price,
            //  AuthorId = book.AuthorId,
            //  GenreId = book.GenreId,
            //  PublicationDate = book.PublicationDate
            //});
            //}


            //return Ok(results);


            return Ok(_mapper.Map<IEnumerable<BookDto>>(bookEntities));
        }




        [HttpGet("{id}", Name = "GetBook")]

        public async Task<ActionResult<GenreDto>> GetBook(int id)
        {
            
            var book = await _bookstoreRepository.GetBookAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<BookDto>(book));
        }


        [HttpPost]

        public async Task<ActionResult<BookDto>> CreateBook(BookForCreationDto book)
        {
            

            var finalBook = _mapper.Map<Entities.Book>(book);

            await _bookstoreRepository.AddBook(finalBook);

            

            await _bookstoreRepository.SaveChangesAsync();

            var createdBookToReturn = _mapper.Map<Models.BookDto>(finalBook);

            return CreatedAtRoute("GetBook",
                new
                {
                    id = createdBookToReturn.BookId
                }, finalBook);


        }
        [HttpPut("{bookId}")]

        public async Task<ActionResult> UpdateBook(int bookId, BookForUpdateDto book)
        {

            var bookEntity = await _bookstoreRepository.GetBookAsync(bookId);

            if (bookEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(book, bookEntity);
            await _bookstoreRepository.SaveChangesAsync();


            return NoContent();

        }

        [HttpDelete("{bookId}")]

        public async Task<ActionResult> DeleteBook(int bookId)

        {
            var bookFromDatabase = await _bookstoreRepository.GetBookAsync(bookId);
            if (bookFromDatabase == null)
            {
                return NotFound();
            }

            //GenreDataStore.Current.Genres.Remove(genreFromDatabase);
            _bookstoreRepository.DeleteBook(bookFromDatabase);
            await _bookstoreRepository.SaveChangesAsync();

            return NoContent();
        }
    }
}


/*    * GET /books : Retrieve a list of all books
    * GET /books/{book_id} : Retrieve details of a specific book 
    * POST /books : Add a new book
    * PUT /books/{book_id} : Update details of an existing book 
    * DELETE /books/{book_id} : Delete a specific book */