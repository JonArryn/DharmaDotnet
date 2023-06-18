using DharmaServerDotnetApi.Models;

namespace DharmaServerDotnetApi.Repositories.BookRepository;

public interface IBookRepository {

    Task<ICollection<Book>> GetAllBooks();

    Task<Book> GetBookById( int id );

    Task<Book> CreateNewBook( Book newBook );

    Task<Book> UpdateBook( int id, Book newBookData );

    Task<Book> DeleteBook( int id );

}