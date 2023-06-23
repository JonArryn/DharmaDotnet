using AutoMapper;
using DharmaServerDotnetApi.Constants;
using DharmaServerDotnetApi.Database;
using DharmaServerDotnetApi.Helpers;
using DharmaServerDotnetApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DharmaServerDotnetApi.Repositories;

public interface IBookRepo {

    Task<ICollection<DTOGetBook>> GetAllBooks( QueryParams queryParams );

    Task<ICollection<DTOGetBookWithAuthor>> GetAllBooksWithAuthor();

    Task<DTOGetBook> GetBookById( int id, QueryParams queryParams );

    Task<DTOGetBookWithAuthor> GetBookByIdWithAuthor( int id );

    Task<DTOGetBook> CreateBook( DTOCreateBook newBook );

    Task<DTOGetBook> UpdateBook( int id, DTOCreateBook newBookData );

    Task<DTOGetBook> DeleteBook( int id );

}

//TODO want to return only IDs of related data with an ID such as author
//TODO only expose related data on embeds
public class BookRepo : IBookRepo {

    private readonly IBaseRepo _baseRepo;
    private readonly DharmaDbContext _dbContext;
    private readonly IMapper _mapper;

    public BookRepo( DharmaDbContext dbContext, IMapper mapper, IBaseRepo baseRepo ) {
        _dbContext = dbContext;
        _mapper = mapper;
        _baseRepo = baseRepo;
    }

// GET ALL
    public async Task<ICollection<DTOGetBook>> GetAllBooks( QueryParams queryParams ) {
        var books = _dbContext.Book.AsQueryable();

        if (!string.IsNullOrEmpty( queryParams.Filter )) {
            books = books.Where( book => book.Title.Contains( queryParams.Filter ) );
        }

        if (!string.IsNullOrEmpty( queryParams.SortBy )) {
            books = books.OrderBy( book => EF.Property<object>( book, queryParams.SortBy ) );
        }

        if (queryParams.Embed == BookEmbeds.Author) {
            _mapper.Map<ICollection<DTOGetBookWithAuthor>>( await books.ToListAsync() );
        }

        var bookList = await books.ToListAsync();

        return _mapper.Map<ICollection<DTOGetBook>>( bookList );
    }

    public async Task<ICollection<DTOGetBookWithAuthor>> GetAllBooksWithAuthor() {
        return _mapper.Map<ICollection<DTOGetBookWithAuthor>>( await _dbContext.Book.ToListAsync() );
    }

// GET BY ID
    public async Task<DTOGetBook> GetBookById( int id, QueryParams queryParams ) {
        var book = _mapper.Map<DTOGetBook>( await _dbContext.Book.FindAsync( id ) );

        return book;
    }

    public async Task<DTOGetBookWithAuthor> GetBookByIdWithAuthor( int id ) {
        var book = _mapper.Map<DTOGetBookWithAuthor>( await _dbContext.Book.FindAsync( id ) );

        return book;
    }

// DELETE
//TODO ensure this returns nothing
//TODO ensure this doesn't delete the author
    public async Task<DTOGetBook> DeleteBook( int id ) {
        var book = await _dbContext.Book.FindAsync( id );

        if (book is null) { throw new Exception( "Book not found by the provided Id" ); }

        var result = _dbContext.Book.Remove( book );
        await _dbContext.SaveChangesAsync();

        var deletedBook = _mapper.Map<DTOGetBook>( result );

        return deletedBook;
    }

// CREATE
//TODO Check for existing author by certain fields to prevent author duplication
    public async Task<DTOGetBook> CreateBook( DTOCreateBook newBookDto ) {
        try {
            var newBookEntry = _mapper.Map<Book>( newBookDto );

            var authorExists = await _baseRepo.CheckIfEntityExists<Author>( newBookDto.AuthorId );

            if (authorExists == false) { throw new Exception( "Author not found by the provided ID" ); }

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
        catch (Exception e) { throw new Exception( e.Message ); }
    }

// UPDATE

//TODO set up mapping for possible partial updates
    public async Task<DTOGetBook> UpdateBook( int id, DTOCreateBook updateBookDto ) {
        var book = await _dbContext.Book.FindAsync( id );

        if (book is null) { return null; }

        _mapper.Map( updateBookDto, book );

        await _dbContext.SaveChangesAsync();

        var updatedBook = _mapper.Map<DTOGetBook>( book );

        return updatedBook;
    }

}