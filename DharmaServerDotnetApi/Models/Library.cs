using DharmaServerDotnetApi.Helpers;

namespace DharmaServerDotnetApi.Models;

public class Library : BaseEntity {

    public string Name { get; set; }
    public ICollection<LibraryBook>? LibraryBooks { get; set; }

}