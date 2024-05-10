using WebApplication2.Models.DTOs;

namespace WebApplication2.Repositories;

public interface IBookRepository
{
   
        public BookDTO GetAuthorsGenres(int id);

        public int RemoveGenre(int id);
    
}