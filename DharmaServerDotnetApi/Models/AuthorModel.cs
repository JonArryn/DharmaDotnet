using DharmaServerDotnetApi.Helpers;

namespace DharmaServerDotnetApi.Models;

public class Author : BaseEntity {

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? MiddleName { get; set; }
    public string? PenName { get; set; }
    public ICollection<Book>? Books { get; set; }

}

public class DTOAuthor {

    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public string PenName { get; set; }

}

public class DTOCreateAuthor {

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? MiddleName { get; set; }
    public string? PenName { get; set; }

}

public class DTOUpdateAuthor {

    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? MiddleName { get; set; }
    public string? PenName { get; set; }

}