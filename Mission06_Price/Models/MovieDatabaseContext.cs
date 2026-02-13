using Microsoft.EntityFrameworkCore;

namespace Mission06_Price.Models;
//Bridge between C# and Database
public class MovieDatabaseContext : DbContext //inherites properities of DBContext
{
    //gets the location of the database and the options
    public MovieDatabaseContext(DbContextOptions<MovieDatabaseContext> options) : base(options)
    {
        
    }
    //Looks for and creates a database according to the Movie.cs Model
    public DbSet<Movie> MovieDatabase { get; set; }
}