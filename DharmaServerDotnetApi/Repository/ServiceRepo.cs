using DharmaServerDotnetApi.Repository.BookRepository;

namespace DharmaServerDotnetApi.Repository;

public static class ServiceRepo {

    public static void AddServiceRepo( this WebApplicationBuilder builder ) {

        builder.Services.AddScoped<IBookRepository, BookRepository.BookRepository>();
    }

}