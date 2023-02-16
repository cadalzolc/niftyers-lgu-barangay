namespace Niftyers;

public class ResponseUser : Response {
    public DtoUserInfo Data { get; set; } = new DtoUserInfo();
}

public class ResponseUserList : Response {
    public IEnumerable<DtoUserInfo> Data { get; set; } = new List<DtoUserInfo>();
}