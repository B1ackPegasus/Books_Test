using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models.DTOs;

public class AuthorDTO
{
    [MaxLength(50)]
    public string FirstName{ get; set; }
    [Required]
    [MaxLength(100)]
    public string LastName{ get; set; }
}