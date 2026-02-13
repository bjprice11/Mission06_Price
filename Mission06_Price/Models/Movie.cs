using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Mission06_Price.Models;

//Creates a class to receive the input from the forms and puts them into the database
public class Movie
{
    [Key]
    [Required]
    public int MovieId { get; set; } // get set makes it so you get the name out of the database as welll as set it to a new variable.
    [Required]
    public string Category{ get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "Please enter a valid year.")] //makes the year have to be a valid number
    public int Year { get; set; }
    [Required]
    public string Director { get; set; }
    [Required]
    public string Rating { get; set; }
    public string? Edited { get; set; }
    public string? LentTo { get; set; }
    [StringLength(25)] // only allow strings of 25 characters or shorter
    public string? Notes { get; set; }
}