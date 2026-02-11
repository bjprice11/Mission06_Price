using Microsoft.EntityFrameworkCore;

namespace Mission06_Price.Models;

public class MovieDatabaseContext : DbContext
{
    public MovieDatabaseContext(DbContextOptions<MovieDatabaseContext> options) : base(options)
    {
        
    }
    
    public DbSet<Movie> MovieDatabase { get; set; }
}