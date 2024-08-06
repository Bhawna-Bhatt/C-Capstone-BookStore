using Microsoft.EntityFrameworkCore;
using BookStore.Entities;


namespace BookStore.DbContexts
{
    public class BookStoreContext : DbContext   
    {
        public DbSet<Book> Books { get; set; }
        public  DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
       public BookStoreContext(DbContextOptions<BookStoreContext> options) : base (options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>()
                 .HasData(
                new Genre("Self-Help")
                {
                    GenreId =1
                });

            modelBuilder.Entity<Author>()
             .HasData(
               new Author("Chetan Bhagat")
               {
                  AuthorId = 1, 
                   Biography = "Chetan Bhagat is a bestselling Indian author and columnist known for his novels that explore contemporary Indian society and youth culture. He is also a motivational speaker and a former investment banker. Some of his popular works include \"Five Point Someone,\" \"2 States,\" and \"The 3 Mistakes of My Life.\""
               }

               );

            modelBuilder.Entity<Book>()
            .HasData(
           new Book("11 Rules of Life") 
           {    BookId =1,
               AuthorId = 1,
               GenreId = 1,
               Price = 9.99m,
               PublicationDate = new DateTime(2023,11,23)

           }
           );



            base.OnModelCreating(modelBuilder);
        } 

    }
}
