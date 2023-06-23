using DharmaServerDotnetApi.Helpers;

namespace DharmaServerDotnetApi.Models;

public class Library : BaseEntity {

    public string Name { get; set; }
    public ICollection<LibraryBook>? LibraryBooks { get; set; }

}

public class DTOGetLibrary : BaseEntity {

    public string Name { get; set; }

}

public class DTOCreateLibrary {

    public string Name { get; set; }

}