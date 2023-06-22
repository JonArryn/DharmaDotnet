using DharmaServerDotnetApi.Helpers;

namespace DharmaServerDotnetApi.Models;

public class LibraryBook : BaseEntity {

    public int BookId { get; set; }
    public Book Book { get; set; }
    public int LibraryId { get; set; }
    public Library Library { get; set; }

}