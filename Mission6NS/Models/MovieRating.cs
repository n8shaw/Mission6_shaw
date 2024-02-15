using System.ComponentModel.DataAnnotations;

namespace Mission6_shaw.Models
{
    public class MovieRating
    {
        [Key]
        [Required]
        public int MovieID { get; set; }
        
        public string Category { get; set; }
        
        public string Title { get; set; }
        
        public int StartYear { get; set; }
        
        public int EndYear { get; set; }
        
        public string Director { get; set; }
        
        public string Rating { get; set; }

        public string? LentTo { get; set; }//? so that it is not required and can pass null values

        [StringLength(25, ErrorMessage = "Notes must be limited to 25 characters")]//set max string length
        public string? Notes { get; set; }

        public bool? Edited { get; set; }


    }
}
