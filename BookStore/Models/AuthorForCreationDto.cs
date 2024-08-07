using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class AuthorForCreationDto
    {
        [Required(ErrorMessage = "Please provide a Name for the Author")]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(1000)]
        public string? Biography { get; set; }
    }
}
