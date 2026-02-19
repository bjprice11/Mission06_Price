using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Mission06_Price.Models;

//Creates a class to receive the input from the forms and puts them into the database
public class Movies
{
    [Key]
    [Required]
    public int MovieId { get; set; } // get set makes it so you get the name out of the database as well as set it to a new variable.
    [Required(ErrorMessage = "Please pick a movie category")]
    public int? CategoryId{ get; set; }
    [ForeignKey("CategoryId")]
    public Categories? Categories { get; set; }
    [Required(ErrorMessage = "Please enter a Title")]
    public string? Title { get; set; }
    [Range(0, int.MaxValue, ErrorMessage = "Please enter a valid year.")] //makes the year have to be a valid number
    public int? Year { get; set; }
    //[Required(ErrorMessage = "Please enter a Director")]
    public string? Director { get; set; }
    [Required]
    public string? Rating { get; set; }
    [Required(ErrorMessage = "Please enter if it was Edited")]
    public int? Edited { get; set; }
    public string? LentTo { get; set; }
    [Required(ErrorMessage = "Please Tell if it has been Copied")]
    public int? CopiedToPlex{ get; set; }
    [StringLength(25)] // only allow strings of 25 characters or shorter
    public string? Notes { get; set; }
}