using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Entities
{
    public class Genre
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        

        public int GenreId { get; set; }


        [Required]
        [MaxLength(50)]
        

        public string GenreName { get; set; }

        public Genre() { }

        public Genre(string name)
        {
            GenreName = name;
        }

    

    }
}
