namespace DharmaServerDotnetApi.Helpers;

public static class CreateResponse<TModel, UDto>
        where TModel : class, new()
        where UDto : class, new() {

    public static ResponseWrapper<ICollection<UDto>> DtoListResponse( ICollection<TModel> rawListData ) {

        var responseObject = new ResponseWrapper<ICollection<UDto>>();

        var dtoList = new List<UDto>();

        foreach (var item in rawListData) {
            var mappedItem = Mapper.Map<TModel, UDto>( item );

            dtoList.Add( mappedItem );
        }

        responseObject.Data = dtoList;

        return responseObject;

    }

    public static ResponseWrapper<UDto> SingleDtoResponse( TModel rawData ) {
        var responseObject = new ResponseWrapper<UDto>();

        var mappedItem = Mapper.Map<TModel, UDto>( rawData );

        responseObject.Data = mappedItem;

        return responseObject;
    }

}