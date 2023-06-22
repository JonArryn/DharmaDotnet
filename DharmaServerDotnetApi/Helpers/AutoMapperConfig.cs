using AutoMapper;
using DharmaServerDotnetApi.Models;

namespace DharmaServerDotnetApi.Helpers;

public class AutoMapperConfig : Profile {

    public AutoMapperConfig() {
        CreateMap<Book, DTOGetBook>();
        CreateMap<Book, DTOGetBookWithAuthor>();
        CreateMap<Author, DTOAuthor>();

        CreateMap<DTOCreateBook, Book>();
    }

}