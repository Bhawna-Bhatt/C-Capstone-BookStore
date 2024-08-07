using BookStore.Entities;

namespace BookStore.Services
{
    public interface IBookstoreRepository
    {
        // Books
        Task<IEnumerable<Book>> GetBooksAsync();//

        Task<Book?> GetBookAsync(int bookId);
        Task<bool> BookExistsAsync(int bookId);
        Task AddBook(Book book);

        Task UpdateBook(Book book);

        void DeleteBook(Book book);

        //Authors
        Task<IEnumerable<Author>> GetAuthorsAsync();//
        Task<Author?> GetAuthorAsync(int authorId);

        Task<bool> AuthorExistsAsync(int authorId);
        Task AddAuthor(Author author);

        Task UpdateAuthor(Author author);
        void DeleteAuthor(Author author);

        Task<Author?> GetAuthorForBookAsync(int bookId, int authorId);
        //Genres
        Task<IEnumerable<Genre>> GetGenresAsync(); //
        Task<Genre> GetGenreAsync(int genreId);

        Task<bool> GenreExistsAsync(int genreId);

        Task<Genre?> GetGenreForBookAsync(int bookId, int genreId);
        Task AddGenre(Genre genre);

        Task UpdateGenre(Genre genre);

        void DeleteGenre(Genre genre);

        Task<bool> SaveChangesAsync();
    }
}


/*
 Books:
PUT /books/{book_id} : Update details of an existing book 
Authors:
PUT /authors/{author_id} : Update details of an existing author 
*/