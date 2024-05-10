using System.Data.SqlClient;
using WebApplication2.Models.DTOs;

namespace WebApplication2.Repositories;

public class BookRepository : IBookRepository
{
    private IConfiguration _configuration;

    public BookRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public BookDTO GetAuthorsGenres(int id)
    {
        using SqlConnection con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        using SqlCommand com = new SqlCommand();
        con.Open();
        using var cmd = new SqlCommand();
        com.Connection = con;
        com.CommandText =
            "SELECT books.PK, books.title ,authors.PK,authors.first_name,authors.last_name ,genres.PK,genres.name FROM books JOIN books_authors ON books.PK = books_authors.FK_book JOIN authors ON authors.PK = books_authors.FK_author JOIN books_genres ON books.PK =books_genres.FK_book JOIN genres ON books_genres.FK_genre=genres.PK WHERE books.PK=@id";
        com.Parameters.AddWithValue("@id", id);
        var dr = com.ExecuteReader();
        if (!dr.HasRows)
        {
            return null;
        }

        bool flag = true;
        var Book = new BookDTO();
        while (dr.Read())
        {
            if (flag)
            {
                Book = new BookDTO
                {
                    Id = (int)dr["PK"],
                    Title = dr["title"].ToString(),
                    Authors = new List<AuthorDTO>(),
                    Genres = new List<String>()
                };
                flag = false;
            }

            var author = new AuthorDTO
            {
                FirstName = dr["first_name"].ToString(),
                LastName = dr["last_name"].ToString()
            };
            var genres = dr["name"].ToString();

            if (!Book.Genres.Contains(genres))
            {
                Book.Genres.Add(genres);
            }

            if (!Book.Authors.Any(a => a.FirstName == author.FirstName && a.LastName == author.LastName))
            {
                Book.Authors.Add(author);
            }

        }

        return Book;

    }

    public int RemoveGenre(int id)
    {
        using SqlConnection con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        using SqlCommand com = new SqlCommand();
        con.Open();
        using var cmd = new SqlCommand();
        com.Connection = con;
        com.CommandText =
            "DELETE FROM genres WHERE PK = @id";
        com.Parameters.AddWithValue("@id", id);
        var dr = com.ExecuteNonQuery();
        return dr;



    }
}
