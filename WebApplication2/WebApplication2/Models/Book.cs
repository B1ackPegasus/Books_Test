using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models;

public class Books
{
    public int Id { get; set; }
    [Required]
    [MaxLength(100)]
    public string Title { get; set;}
    
}