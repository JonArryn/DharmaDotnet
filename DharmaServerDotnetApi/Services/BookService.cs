using AutoMapper;
using DharmaServerDotnetApi.Repositories;

namespace DharmaServerDotnetApi.Services;

public class BookService {

    private readonly BookRepo _bookRepo;
    private readonly IMapper _mapper;

    public BookService( BookRepo bookRepo, IMapper mapper ) {
        _bookRepo = bookRepo;
        _mapper = mapper;

    }

    // public async Task<ICollection<DTOGetBook>> GetAllBooks( QueryParams queryParams ) { }

}