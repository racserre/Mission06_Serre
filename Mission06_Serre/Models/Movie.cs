using System.ComponentModel.DataAnnotations;

// This file defines the Movie model, which represents the structure of the "Movies" table in the database.
// It includes properties for storing movie details, along with validation attributes to enforce data integrity.

namespace Mission06_Serre.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int MovieID { get; set; } // Primary key

        [Required]
        public string Category { get; set; } // Required category field

        [Required]
        public string Title { get; set; } // Required movie title

        [Required]
        public int Year { get; set; } // Required release year

        [Required]
        public string Director { get; set; } // Required director name

        [Required]
        public string Rating { get; set; } // Required MPAA rating (e.g., G, PG, PG-13, R)

        public bool? Edited { get; set; } // Nullable boolean indicating if the movie has been edited

        public string LentTo { get; set; } // Optional field to record who borrowed the movie

        [StringLength(25)]
        public string Notes { get; set; } // Optional notes field with a maximum length of 25 characters
    }
}
