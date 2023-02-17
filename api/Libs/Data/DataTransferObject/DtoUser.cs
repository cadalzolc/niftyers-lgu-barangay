namespace Niftyers;

public class DtoUser {
    public string Id { get; set; } = "";
    public string Name { get; set; } = "";
}

public class DtoUserInfo : DtoUser {
    public string Username { get; set; } = "";
    public string Password { get; set; } = "";
}