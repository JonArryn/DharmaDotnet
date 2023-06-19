namespace DharmaServerDotnetApi.Helpers;

public class ResponseWrapper<TData> {

    public TData Data { get; set; }
    public bool Success { get; set; } = true;
    public DateTime RequestTimeUtc { get; set; } = DateTime.UtcNow;

}