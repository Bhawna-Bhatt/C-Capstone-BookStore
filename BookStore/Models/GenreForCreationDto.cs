using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class GenreForCreationDto
    {
        [Required(ErrorMessage ="Please provide a Name for the Genre")]
        [MaxLength(100)]
        public string GenreName { get; set; } = string.Empty;
    }
   
}
