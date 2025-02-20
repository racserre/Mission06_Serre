using Microsoft.EntityFrameworkCore;

namespace Mission06_Serre.Models
{
    // This class represents the database context for the Movie Collection application.
    // It inherits from DbContext, allowing interaction with the database using Entity Framework Core.
    public class MovieCollectionContext : DbContext
    {
        // Constructor that accepts database options and passes them to the base DbContext.
        public MovieCollectionContext(DbContextOptions<MovieCollectionContext> options) : base(options)
        {
        }

        // DbSet property that represents the "Movies" table in the database.
        // This allows querying and managing movie records through Entity Framework.
        public DbSet<Movie> Movies { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Miscellaneous"},
                new Category { CategoryId = 2, CategoryName = "Drama"},
                new Category { CategoryId = 3, CategoryName = "Televison"},
                new Category { CategoryId = 4, CategoryName = "Horror/Suspense"},
                new Category { CategoryId = 5, CategoryName = "Comedy"},
                new Category { CategoryId = 6, CategoryName = "Family"},
                new Category { CategoryId = 7, CategoryName = "Action/Adventure"},
                new Category { CategoryId = 8, CategoryName = "VHS"}
                
                );
        }
    }
}
