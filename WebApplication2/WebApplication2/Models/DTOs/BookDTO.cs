using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models.DTOs;

public class BookDTO
{
    public int Id { get; set; }
    [Required]
    [MaxLength(100)]
    public string Title { get; set;}
    [Required]
    public List<AuthorDTO> Authors { get; set; }
    [Required]
    public List<String> Genres { get; set; }

}