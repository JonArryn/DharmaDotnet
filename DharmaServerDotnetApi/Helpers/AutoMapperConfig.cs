using AutoMapper;
using DharmaServerDotnetApi.Models;

namespace DharmaServerDotnetApi.Helpers;

public class AutoMapperConfig : Profile {

    public AutoMapperConfig() {

        // LIBRARY
        CreateMap<Library, DTOGetLibrary>();
        CreateMap<DTOCreateLibrary, Library>();

        // BOOK
        CreateMap<Book, DTOGetBook>();
        CreateMap<Book, DTOGetBookWithAuthor>();
        CreateMap<DTOCreateBook, Book>();

        // AUTHOR
        CreateMap<Author, DTOAuthor>();
    }

}