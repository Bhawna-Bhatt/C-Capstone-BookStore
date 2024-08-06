using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BookStore.Entities
{
    public class Author
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      
        public int AuthorId { get; set; }

        [Required]
        [MaxLength(50)]
        
        public string Name { get; set; }
        [MaxLength(1000)]
        
   
        public string? Biography { get; set; }


        public Author(string name)
        {
            Name = name;
        }

    }





}

