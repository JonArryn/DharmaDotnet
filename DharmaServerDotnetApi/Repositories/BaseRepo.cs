using AutoMapper;
using DharmaServerDotnetApi.Database;
using DharmaServerDotnetApi.Helpers;
using Microsoft.EntityFrameworkCore;

namespace DharmaServerDotnetApi.Repositories;

public interface IBaseRepo {
    Task<bool> CheckIfEntityExists<T>(int entityId) where T : BaseEntity;
}

public class BaseRepo : IBaseRepo {

    private readonly DharmaDbContext _dbContext;
    private readonly IMapper _mapper;

    public BaseRepo( DharmaDbContext dbContext, IMapper mapper ) {
        _dbContext = dbContext;
        _mapper = mapper;

    }

    public async Task<bool> CheckIfEntityExists<T>( int entityId )
            where T : BaseEntity {
        var result = await _dbContext.Set<T>()
                                     .AnyAsync( x => x.Id == entityId );

        return result;
    }

}