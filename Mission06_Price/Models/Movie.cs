using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Mission06_Price.Models;

public class Movie
{
    [Key]
    [Required]
    public int MovieId { get; set; }
    [Required]
    public string Category{ get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "Please enter a valid year.")]
    public int Year { get; set; }
    [Required]
    public string Director { get; set; }
    [Required]
    public string Rating { get; set; }
    public string? Edited { get; set; }
    public string? LentTo { get; set; }
    [StringLength(25)]
    public string? Notes { get; set; }
}