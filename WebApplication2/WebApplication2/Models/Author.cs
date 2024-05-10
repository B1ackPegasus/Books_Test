using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models;

public class Author
{
    public int Id{ get; set; }
    [MaxLength(50)]
    public string FirstName{ get; set; }
    [Required]
    [MaxLength(100)]
    public string LastName{ get; set; }
}