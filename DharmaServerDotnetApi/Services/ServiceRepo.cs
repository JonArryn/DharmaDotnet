using DharmaServerDotnetApi.Services.BookService;

namespace DharmaServerDotnetApi.Services;

public static class ServiceRepo {

    public static void AddServiceRepo( this WebApplicationBuilder builder ) {

        builder.Services.AddScoped<IBookService, BookService.BookService>();
    }

}