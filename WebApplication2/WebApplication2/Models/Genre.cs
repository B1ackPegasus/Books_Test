using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models;

public class Genre
{
    public int id{ get; set; }
    [MaxLength(100)]
    public string Name{ get; set; }
}