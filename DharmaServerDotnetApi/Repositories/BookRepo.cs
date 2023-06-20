using DharmaServerDotnetApi.Database;
using DharmaServerDotnetApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DharmaServerDotnetApi.Repositories;

public interface IBookRepo {

    Task<ICollection<Book>> GetAllBooks();

    Task<Book> GetBookById( int id );

    Task<Book> CreateNewBook( Book newBook );

    Task<Book> UpdateBook( int id, Book newBookData );

    Task<Book> DeleteBook( int id );

}

//TODO want to return only IDs of related data with an ID such as author
//TODO only expose related data on embeds
public class BookRepo : IBookRepo {

    private readonly DharmaDbContext _dbContext;

    public BookRepo( DharmaDbContext dbContext ) {
        _dbContext = dbContext;
    }

// GET ALL
    public async Task<ICollection<Book>> GetAllBooks() {
        return await _dbContext.Book.ToListAsync();
    }

// GET BY ID
    public async Task<Book> GetBookById( int id ) {
        var book = await _dbContext.Book.FindAsync( id );

        return book;
    }

// CREATE
//TODO newBook should be a createDto
    public async Task<Book> CreateNewBook( Book newBook ) {
        var bookEntry = await _dbContext.Book.AddAsync( newBook );

        await _dbContext.SaveChangesAsync();

        return bookEntry.Entity;
    }

// UPDATE

//TODO set up mapping for possible partial updates
    public async Task<Book> UpdateBook( int id, Book newBookData ) {
        var book = await _dbContext.Book.FindAsync( id );

        if (book is null) {
            return null;
        }

        book.Title  = newBookData.Title;
        book.Author = newBookData.Author;

        await _dbContext.SaveChangesAsync();

        return book;
    }

// DELETE

    public async Task<Book> DeleteBook( int id ) {
        var book = await _dbContext.Book.FindAsync( id );

        if (book is null) {
            throw new Exception( "Book not found by the provided Id" );
        }

        var result = _dbContext.Book.Remove( book );
        await _dbContext.SaveChangesAsync();

        return result.Entity;
    }

// HELPER
    public async Task<bool> CheckBookExists( int bookId ) {
        return await _dbContext.Book.AnyAsync( book => book.Id == bookId );
    }

}