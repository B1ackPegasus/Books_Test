using WebApplication2.Models.DTOs;
using WebApplication2.Repositories;

namespace WebApplication2.Services;

public class BookService : IBookService
{
   private IBookRepository _bookRepository;

   public BookService(IBookRepository bookRepository)
   {
      _bookRepository = bookRepository;
   }
   
   public BookDTO GetAuthorsGenres(int id)
   {
      return _bookRepository.GetAuthorsGenres(id);
   }

   public int RemoveGenre(int id)
   {

      return _bookRepository.RemoveGenre(id);
   }
}