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
    }
}
