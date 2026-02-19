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
    public DbSet<Movies> Movies { get; set; }
    public DbSet<Categories> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Tell the database that these fields are allowed to be empty (null)
        // This prevents the "Data is Null" crash when reading the teacher's file.
        modelBuilder.Entity<Movies>().Property(m => m.Director).IsRequired(false);
        modelBuilder.Entity<Movies>().Property(m => m.Rating).IsRequired(false);
        modelBuilder.Entity<Movies>().Property(m => m.Edited).IsRequired(false);
        modelBuilder.Entity<Movies>().Property(m => m.LentTo).IsRequired(false);
        modelBuilder.Entity<Movies>().Property(m => m.Notes).IsRequired(false);
    
        //Commented out because the linked database already has it, but it we were making a new one we would need it
        //modelBuilder.Entity<Categories>().HasData(
            //new Categories { CategoryId = 1, CategoryName = "Miscellaneous" },
            //new Categories { CategoryId = 2, CategoryName = "Drama" },
            //new Categories { CategoryId = 3, CategoryName = "Television" },
            //new Categories { CategoryId = 4, CategoryName = "Horror/Suspense" },
            //new Categories { CategoryId = 5, CategoryName = "Comedy" },
            //new Categories { CategoryId = 6, CategoryName = "Family" },
            //new Categories { CategoryId = 7, CategoryName = "Action/Adventure" },
            //new Categories { CategoryId = 8, CategoryName = "VHS" }
        //);
    }
}