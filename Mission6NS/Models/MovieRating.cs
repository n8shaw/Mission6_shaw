using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission6_shaw.Models
{
    public class MovieRating
    {
        [Key]
        [Required]
        public int MovieId { get; set; }
        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }

        public Category? CategoryName { get; set; }
        
        public string Title { get; set; }
        [Range(1889, int.MaxValue, ErrorMessage = "Year must be greater than 1888.")]
        public int Year { get; set; }
        
        public string? Director { get; set; }
        
        public string? Rating { get; set; }

        public string? LentTo { get; set; }//? so that it is not required and can pass null values

        [StringLength(25, ErrorMessage = "Notes must be limited to 25 characters")]//set max string length
        public string? Notes { get; set; }
        [Required(ErrorMessage = "Please select a value for Edited.")]
        public int Edited { get; set; }
        [Required(ErrorMessage = "Please select a value for Copied To Plex.")]
        public int CopiedToPlex { get; set; }


    }
}
