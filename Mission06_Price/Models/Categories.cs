using System.ComponentModel.DataAnnotations;

namespace Mission06_Price.Models;

//Seperate Categories Model that ties into the Movies
public class Categories
{
    [Key]
    public int CategoryId { get; set; }
    public string? CategoryName { get; set; }
}