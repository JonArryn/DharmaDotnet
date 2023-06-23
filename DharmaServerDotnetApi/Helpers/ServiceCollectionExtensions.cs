using DharmaServerDotnetApi.Repositories;

namespace DharmaServerDotnetApi.Helpers;

public static class RepositoryService {

    public static void AddRepositories( this IServiceCollection services ) {
        services.AddScoped<IBaseRepo, BaseRepo>();
        services.AddScoped<IBookRepo, BookRepo>();
        services.AddScoped<IAuthorRepo, AuthorRepo>();
    }

    public static void AddHelpers( this IServiceCollection services ) {
        services.AddScoped<IBaseRepo, BaseRepo>();
    }

}

public static class MiddlewareService {

    public static void AddCors( this WebApplicationBuilder builder ) {
        var allowedIPs = builder.Configuration.GetSection( "AllowedIPs" )
                                .Get<List<string>>();

        builder.Services.AddCors( options => {
            options.AddPolicy( "AllowSpecificOrigins",
                               builder => {
                                   builder.WithOrigins( allowedIPs.ToArray() )
                                          .AllowAnyHeader()
                                          .AllowAnyMethod();
                               } );
        } );
    }

}