using AutoMapper;
using DharmaServerDotnetApi.Models;

namespace DharmaServerDotnetApi.Helpers;

public class AutoMapperConfig : Profile {

    public AutoMapperConfig() {
        CreateMap<Book, DTOGetBook>();
        CreateMap<Author, DTOAuthor>();

        CreateMap<DTOCreateBook, Book>()
                .ForMember ( targetProp => targetProp.CreatedAt, opt => opt.MapFrom ( _ => DateTime.UtcNow ) )
                .ForMember (
                targetProp => targetProp.Author,
                opt => opt.MapFrom (
                src => new Author {
                    FirstName = src.Author.FirstName,
                    LastName = src.Author.LastName,
                    MiddleName = src.Author.MiddleName,
                    PenName = src.Author.PenName,
                } ) )
                .ForMember ( targetProp => targetProp.LibraryBooks, opt => opt.Ignore() );
    }

}