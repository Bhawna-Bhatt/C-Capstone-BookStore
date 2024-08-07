using BookStore.DbContexts;
using BookStore.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Services
{
    public class BookStoreRepository : IBookstoreRepository
    {
        private readonly BookStoreContext _context;

        public BookStoreRepository(BookStoreContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task AddAuthor(Author author)
        {
            await _context.Authors.AddAsync(author);
        }

        public async Task AddBook(Book book)
        {
           await _context.Books.AddAsync(book);
        }

        public async Task AddGenre(Genre genre)
        {
            await _context.Genres.AddAsync(genre);
        }

        public async Task<bool> AuthorExistsAsync(int authorId)
        {
            return await _context.Authors.AnyAsync(c=> c.AuthorId==authorId);
        }

        public async Task<bool> BookExistsAsync(int bookId)
        {
            return await (_context.Books.AnyAsync(c=> c.BookId==bookId));
        }

        public void DeleteAuthor(Author author)
        {
            _context.Authors.Remove(author);
        }

        public void DeleteBook(Book book)
        {
            _context.Books.Remove(book);
        }

        public void DeleteGenre(Genre genre)
        {
            _context.Genres.Remove(genre);
        }

        public async Task<bool> GenreExistsAsync(int genreId)
        {
           return await _context.Genres.AnyAsync(c=>c.GenreId==genreId);
        }

        public async Task<Author?> GetAuthorAsync(int authorId)
        {
            return await _context.Authors.Where(c => c.AuthorId == authorId).FirstOrDefaultAsync();
        }

        public Task<Author?> GetAuthorForBookAsync(int bookId, int authorId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Author>> GetAuthorsAsync()
        {
            return await _context.Authors.OrderBy(b => b.Name).ToListAsync();
        }

        public async Task<Book?> GetBookAsync(int bookId)
        {
            return await _context.Books
                .Where(c => c.BookId == bookId).FirstOrDefaultAsync();


        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
           return await _context.Books.OrderBy(b=>b.Title).ToListAsync();
        }

        public async Task<Genre?> GetGenreAsync(int genreId)
        {
            return await _context.Genres.Where(c => c.GenreId == genreId).FirstOrDefaultAsync();
        }

        public Task<Genre?> GetGenreForBookAsync(int bookId, int genreId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Genre>> GetGenresAsync()
        {
            return await _context.Genres.OrderBy(g => g.GenreName).ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }

        public Task UpdateAuthor(Author author)
        {
            throw new NotImplementedException();
        }

        public Task UpdateBook(Book book)
        {
            throw new NotImplementedException();
        }

        public Task UpdateGenre(Genre genre)
        {
            throw new NotImplementedException();
        }

       
    }
}
