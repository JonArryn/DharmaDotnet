using DharmaServerDotnetApi.Database;
using DharmaServerDotnetApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DharmaServerDotnetApi.Repository.BookRepository;

public class BookRepository : IBookRepository {

    private readonly DharmaDbContext _dbContext;

    public BookRepository( DharmaDbContext dbContext ) {
        _dbContext = dbContext;

    }

    public async Task<List<Book>> GetAllBooks() {
        var books = await _dbContext.Book.ToListAsync();

        return books;
    }

    public async Task<Book> GetBookById( int id ) {
        var book = await _dbContext.Book.FindAsync( id );

        if (book is null) {
            return null;
        }

        return book;
    }

    public async Task<Book> CreateNewBook( Book newBook ) {
        var bookEntry = await _dbContext.Book.AddAsync( newBook );
        await _dbContext.SaveChangesAsync();

        var book = await _dbContext.Book.FindAsync( bookEntry.Entity.Id );

        return book;
    }

    public async Task<Book> UpdateBook( int id, Book newBookData ) {
        var book = await _dbContext.Book.FindAsync( id );

        if (book is null) {
            return null;
        }

        book.Title  = newBookData.Title;
        book.Author = newBookData.Author;

        await _dbContext.SaveChangesAsync();

        var updatedBook = await _dbContext.Book.FindAsync( id );

        return updatedBook;
    }

    public async Task<Book> DeleteBook( int id ) {

        var book = await _dbContext.Book.FindAsync( id );

        if (book is null) {
            throw new Exception( "Book not found by the provided Id" );
        }

        _dbContext.Book.Remove( book );
        await _dbContext.SaveChangesAsync();

        return await _dbContext.Book.FindAsync( id );

    }

}