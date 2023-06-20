using DharmaServerDotnetApi.Repositories;

namespace DharmaServerDotnetApi.Helpers;

public static class RepositoryService {

    public static void AddServiceRepo( this WebApplicationBuilder builder ) {
        builder.Services.AddScoped<IBookRepo, BookRepo>();
        builder.Services.AddScoped<IAuthorRepo, AuthorRepo>();
    }

}