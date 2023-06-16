using DharmaServerDotnetApi.Models;

namespace DharmaServerDotnetApi.Repository.BookRepository;

public interface IBookRepository {

    Task<List<Book>> GetAllBooks();

    Task<Book>? GetBookById( int id );

    Task<Book> CreateNewBook( Book newBook );

    Task<Book> UpdateBook( int id, Book newBookData );

    Task<Book> DeleteBook( int id );

}