using DharmaServerDotnetApi.Helpers;

namespace DharmaServerDotnetApi.Models;

public class User : BaseEntity {

    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

}