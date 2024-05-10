using WebApplication2.Models.DTOs;

namespace WebApplication2.Services;

public interface IBookService
{
    public BookDTO GetAuthorsGenres(int id);

    public int RemoveGenre(int id);
}