using DharmaServerDotnetApi.Repositories.BookRepository;

namespace DharmaServerDotnetApi.Repositories;

public static class RepositoryService {

    public static void AddServiceRepo( this WebApplicationBuilder builder ) {

        builder.Services.AddScoped<IBookRepository, BookRepository.BookRepository>();
    }

}