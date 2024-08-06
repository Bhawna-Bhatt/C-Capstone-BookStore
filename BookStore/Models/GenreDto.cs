using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class GenreDto
    {

        public int GenreId { get; set; }

        public string GenreName { get; set; } = string.Empty;
    }
}
