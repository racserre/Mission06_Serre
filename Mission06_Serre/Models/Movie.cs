using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Serre.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int MovieId { get; set; } // Primary key

        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }

        public Category? Category { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; } // Required movie title

        [Required(ErrorMessage = "Year is required.")]
        [Range(1888, int.MaxValue, ErrorMessage = "Year must be 1888 or later.")]
        public int Year { get; set; } // Required release year (no movie before 1888)

        public string? Director { get; set; } // Director name

        public string? Rating { get; set; } // MPAA rating (e.g., G, PG, PG-13, R)

        [Required(ErrorMessage = "Edited status is required.")]
        public bool Edited { get; set; } // Required boolean 

        public string? LentTo { get; set; } // Optional field to record who borrowed the movie

        [Required(ErrorMessage = "CopiedToPlex status is required.")]
        public bool CopiedToPlex { get; set; } // Required boolean

        [StringLength(25, ErrorMessage = "Notes cannot exceed 25 characters.")]
        public string? Notes { get; set; } // Optional notes field with max length of 25 characters
    }
}
