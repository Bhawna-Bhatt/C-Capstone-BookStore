using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class AuthorDto
    {
    
        public int AuthorId { get; set; }

        public string Name { get; set; } = string.Empty;
       

        public string? Biography { get; set; }


       
    }
}
