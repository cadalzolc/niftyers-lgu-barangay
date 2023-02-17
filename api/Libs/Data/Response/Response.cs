namespace Niftyers;

public class Response {
    public string Message { get; set; } =  "";
    public bool Success { get; set; } = false;
    public string Stamp { get; set; } = DateTime.Now.ToString("yyyy-MM-dd HH:ss");
}