﻿using BookStore.DbContexts;
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
        public Task AddAuthor()
        {
            throw new NotImplementedException();
        }

        public Task AddBook()
        {
            throw new NotImplementedException();
        }

        public async Task AddGenre(Genre genre)
        {
             _context.Genres.Add(genre);
        }

        public Task<bool> AuthorExistsAsync(int authorId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> BookExistsAsync(int bookId)
        {
            throw new NotImplementedException();
        }

        public void DeleteAuthor(int authorId)
        {
            throw new NotImplementedException();
        }

        public void DeleteBook(int bookId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GenreExistsAsync(int genreId)
        {
            throw new NotImplementedException();
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
