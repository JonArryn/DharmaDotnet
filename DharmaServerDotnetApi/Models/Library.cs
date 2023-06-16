namespace DharmaServerDotnetApi.Models;

public class Library {

    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<LibraryBook>? LibraryBooks { get; set; }

}