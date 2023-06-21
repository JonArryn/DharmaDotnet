namespace DharmaServerDotnetApi.Models;

public class Book {

    public int Id { get; set; }
    public string Title { get; set; }
    public int? AuthorId { get; set; }
    public Author? Author { get; set; }
    public ICollection<LibraryBook>? LibraryBooks { get; set; }
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;

}

public class DTOGetBook {

    public int Id { get; set; }
    public string Title { get; set; }
    public int AuthorId { get; set; }
    public DTOAuthor Author { get; set; }

}

public class DTOCreateBook {

    public string Title { get; set; }
    public int? AuthorId { get; set; }
    public DTOCreateAuthor? Author { get; set; }

}