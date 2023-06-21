using AutoMapper;
using DharmaServerDotnetApi.Database;
using DharmaServerDotnetApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DharmaServerDotnetApi.Repositories;

public interface IBookRepo {

    Task<ICollection<DTOGetBook>> GetAllBooks();

    Task<DTOGetBook> GetBookById( int id );

    Task<DTOGetBook> InsertBook( DTOCreateBook newBook );

    Task<DTOGetBook> UpdateBook( int id, DTOCreateBook newBookData );

    Task<DTOGetBook> DeleteBook( int id );

}

//TODO want to return only IDs of related data with an ID such as author
//TODO only expose related data on embeds
public class BookRepo : IBookRepo {

    private readonly DharmaDbContext _dbContext;
    private readonly IMapper _mapper;

    public BookRepo( DharmaDbContext dbContext, IMapper mapper ) {
        _dbContext = dbContext;
        _mapper = mapper;
    }

// GET ALL
    public async Task<ICollection<DTOGetBook>> GetAllBooks() {
        return _mapper.Map<ICollection<DTOGetBook>>( await _dbContext.Book.ToListAsync() );
    }

// GET BY ID
    public async Task<DTOGetBook> GetBookById( int id ) {
        var book = _mapper.Map<DTOGetBook>( await _dbContext.Book.FindAsync( id ) );

        return book;
    }

// DELETE
//TODO ensure this returns nothing
    public async Task<DTOGetBook> DeleteBook( int id ) {
        var book = await _dbContext.Book.FindAsync( id );

        if (book is null) {
            throw new Exception( "Book not found by the provided Id" );
        }

        var result = _dbContext.Book.Remove( book );
        await _dbContext.SaveChangesAsync();

        var deletedBook = _mapper.Map<DTOGetBook>( result );

        return deletedBook;
    }

// CREATE
//TODO Check for existing author by certain fields to prevent author duplication
    public async Task<DTOGetBook> InsertBook( DTOCreateBook newBookDto ) {
        try {
            var newBookEntry = _mapper.Map<Book>( newBookDto );

            if (newBookDto.AuthorId.HasValue) {
                var authorExists = await _dbContext.Author.AnyAsync( author => author.Id == newBookDto.AuthorId );

                if (authorExists == false) {
                    throw new Exception( "Author not found by the provided ID" );
                }
            }

            await using (var transaction = await _dbContext.Database.BeginTransactionAsync()) {
                try {
                    await _dbContext.Book.AddAsync( newBookEntry );
                    await _dbContext.SaveChangesAsync();

                    await transaction.CommitAsync();
                }
                catch (Exception e) {
                    await transaction.RollbackAsync();

                    throw new Exception( e.Message );
                }
            }

            var createdBook = _mapper.Map<DTOGetBook>( newBookEntry );

            return createdBook;
        }
        catch (Exception e) {

            throw new Exception( e.Message );
        }
    }

// UPDATE

//TODO set up mapping for possible partial updates
    public async Task<DTOGetBook> UpdateBook( int id, DTOCreateBook updateBookDto ) {
        var book = await _dbContext.Book.FindAsync( id );

        if (book is null) {
            return null;
        }

        _mapper.Map( updateBookDto, book );

        await _dbContext.SaveChangesAsync();

        var updatedBook = _mapper.Map<DTOGetBook>( book );

        return updatedBook;
    }

// HELPER
    public async Task<bool> CheckBookExists( int bookId ) {
        return await _dbContext.Book.AnyAsync( book => book.Id == bookId );
    }

}