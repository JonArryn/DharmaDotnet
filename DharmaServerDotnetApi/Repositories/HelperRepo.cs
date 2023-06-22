using DharmaServerDotnetApi.Database;
using DharmaServerDotnetApi.Helpers;
using Microsoft.EntityFrameworkCore;

namespace DharmaServerDotnetApi.Repositories;

public interface IHelperRepo {
    Task<bool> CheckIfEntityExists<T>(int entityId) where T : BaseEntity;
}

public class HelperRepo : IHelperRepo {

    private readonly DharmaDbContext _dbContext;

    public HelperRepo( DharmaDbContext dbContext ) {
        _dbContext = dbContext;

    }

    public async Task<bool> CheckIfEntityExists<T>( int entityId )
            where T : BaseEntity {
        var result = await _dbContext.Set<T>()
                                     .AnyAsync( x => x.Id == entityId );

        return result;
    }

}