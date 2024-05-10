using Microsoft.AspNetCore.Mvc;
using WebApplication2.Services;

namespace WebApplication2.Controllers;
[ApiController]
[Route("api")]

public class BooksController : ControllerBase
{
    private IBookService _ibs;

    public BooksController(IBookService ibs)
    {
        _ibs = ibs;
    }
    [HttpGet("books/{id:int}")]
    public IActionResult GetStudent(int id)
    {
        var Authors = _ibs.GetAuthorsGenres(id);

        if (Authors == null)
        {
            return NotFound("No book found");
        }

        return Ok(Authors);
    }

    [HttpDelete("genres/{id:int}")]
    public IActionResult DeleteGenre(int id)
    {
        var aff = _ibs.RemoveGenre(id);
        return NoContent();
    }
}