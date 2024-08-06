using BookStore.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class BookDto
    {
            public int BookId { get; set; }
            public string Title { get; set; } = string.Empty;

            public decimal Price { get; set; }
            public int AuthorId { get; set; }
            public int GenreId { get; set; }



        }

    }




