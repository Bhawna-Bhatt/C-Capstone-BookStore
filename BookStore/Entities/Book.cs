using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BookStore.Entities
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       
        public int BookId { get; set; }

        [Required]
        [MaxLength(50)]
      

        public string Title { get; set; }

       
        public decimal Price { get; set; }

      
        
        public DateTime PublicationDate {get;set;}

        [ForeignKey("AuthorId")]
        
        public Author? Author { get; set; }
        public int AuthorId { get; set; }

        [ForeignKey("GenreId")]
       
         public Genre? Genre { get; set; }

        public int GenreId { get; set; }


    public Book(string title)
    {
        Title = title;
    }

}

    }

