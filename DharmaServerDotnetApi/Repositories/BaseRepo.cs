using AutoMapper;
using DharmaServerDotnetApi.Database;
using DharmaServerDotnetApi.Helpers;
using Microsoft.EntityFrameworkCore;

namespace DharmaServerDotnetApi.Repositories;

public interface IBaseRepo {

    Task<bool> CheckIfEntityExists<T>( int entityId )
            where T : BaseEntity;

    Task<ICollection<TDto>> GetAllEntities<TModel, TDto>()
            where TModel : BaseEntity
            where TDto : BaseEntity;

    Task<TDto> GetEntityById<TModel, TDto>( int entityId )
            where TModel : BaseEntity
            where TDto : BaseEntity;

    Task<TDto> UpdateEntity<TModel, TDto>( int entityId, TDto updatedEntityData )
            where TModel : BaseEntity
            where TDto : BaseEntity;

    Task<TGetDto> CreateEntity<TModel, TCreateDto, TGetDto>( TCreateDto newEntityData )
            where TModel : BaseEntity;

}

public class BaseRepo : IBaseRepo {

    // CONSTRUCTOR
    private readonly DharmaDbContext _dbContext;
    private readonly IMapper _mapper;

    public BaseRepo( DharmaDbContext dbContext, IMapper mapper ) {
        _dbContext = dbContext;
        _mapper = mapper;

    }

    // CREATE

    public async Task<TGetDto> CreateEntity<TModel, TCreateDto, TGetDto>( TCreateDto newEntityData )
            where TModel : BaseEntity {

        var newEntityEntry = _mapper.Map<TModel>( newEntityData );

        try {
            await _dbContext.Set<TModel>()
                            .AddAsync( newEntityEntry );
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception e) { throw new Exception( e.Message ); }

        var createdEntity = _mapper.Map<TGetDto>( newEntityEntry );

        return createdEntity;

    }

    // READ

    public async Task<ICollection<TDto>> GetAllEntities<TModel, TDto>()
            where TModel : BaseEntity
            where TDto : BaseEntity {

        var result = _mapper.Map<List<TDto>>( await _dbContext.Set<TModel>()
                                                              .ToListAsync() );

        return result;
    }

    public async Task<TDto> GetEntityById<TModel, TDto>( int entityId )
            where TModel : BaseEntity
            where TDto : BaseEntity {
        try {
            var result = _mapper.Map<TDto>( await _dbContext.Set<TModel>()
                                                            .FindAsync( entityId ) );

            if (result is null) { throw new Exception( "Entity not found by the provided ID" ); }

            return result;
        }
        catch (Exception e) { throw new Exception( e.Message ); }
    }

// UPDATE

    public async Task<TDto> UpdateEntity<TModel, TDto>( int entityId, TDto updatedEntityData )
            where TModel : BaseEntity
            where TDto : BaseEntity {
        try {
            var entityToUpdate = GetEntityById<TModel, TDto>( entityId );

            await _mapper.Map( updatedEntityData, entityToUpdate );

            await _dbContext.SaveChangesAsync();

            var updatedEntity = _mapper.Map<TDto>( entityToUpdate );

            return updatedEntity;
        }
        catch (Exception e) { throw new Exception( e.Message ); }
    }

    // HELPER

    public async Task<bool> CheckIfEntityExists<T>( int entityId )
            where T : BaseEntity {
        var result = await _dbContext.Set<T>()
                                     .AnyAsync( x => x.Id == entityId );

        return result;
    }

}