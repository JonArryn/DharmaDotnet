namespace DharmaServerDotnetApi.Helpers;

public static class CreateResponses<TData, UDto>
        where TData : class, new()
        where UDto : class, new() {

    public static RepositoryResponse<ICollection<UDto>> CreateDtoListResponse( ICollection<TData> rawListData ) {

        var responseObject = new RepositoryResponse<ICollection<UDto>>();

        var dtoList = new List<UDto>();

        foreach (var item in rawListData) {
            var mappedItem = Mapper.Map<TData, UDto>( item );

            dtoList.Add( mappedItem );
        }

        responseObject.Data = dtoList;

        return responseObject;

    }

}