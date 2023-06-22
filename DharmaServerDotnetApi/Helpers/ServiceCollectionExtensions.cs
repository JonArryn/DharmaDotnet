using DharmaServerDotnetApi.Repositories;

namespace DharmaServerDotnetApi.Helpers;

public static class RepositoryService {

    public static void AddRepositories( this IServiceCollection services ) {
        services.AddScoped<IBookRepo, BookRepo>();
        services.AddScoped<IAuthorRepo, AuthorRepo>();
    }

    public static void AddHelpers( this IServiceCollection services ) {
        services.AddScoped<IHelperRepo, HelperRepo>();
    }

}