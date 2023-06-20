using AutoMapper;
using DharmaServerDotnetApi.Database;
using DharmaServerDotnetApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DharmaServerDotnetApi.Repositories;

public interface IAuthorRepo {

    Task<ICollection<Author>> GetAllAuthors();

    Task<Author> GetAuthorById( int id );

    Task<ICollection<Book>> GetAuthorBooks( int authorId );

}

public class AuthorRepo : IAuthorRepo {

    private readonly DharmaDbContext _dbContext;
    private readonly IMapper _mapper;

    public AuthorRepo( DharmaDbContext _dbContext, IMapper mapper ) {
        _mapper         = mapper;
        this._dbContext = _dbContext;
    }

    public async Task<ICollection<Author>> GetAllAuthors() {
        return await _dbContext.Author.ToListAsync();
    }

    public async Task<Author> GetAuthorById( int id ) {
        var author = await _dbContext.Author.FindAsync( id );

        if (author is null) {
            return null;
        }

        return author;
    }

    public async Task<ICollection<Book>> GetAuthorBooks( int authorId ) {
        var bookList = await _dbContext.Book.Where( book => book.AuthorId == authorId )
                .ToListAsync();

        return bookList;
    }

    public async Task<Author> UpdateAuthor( int id, DTOUpdateAuthor authorDtoUpdateData ) {
        var author = await _dbContext.Author.FindAsync( id );

        if (author is null) {
            return null;
        }

        author = _mapper.Map<Author>( authorDtoUpdateData );

        await _dbContext.SaveChangesAsync();

        return author;
    }

}