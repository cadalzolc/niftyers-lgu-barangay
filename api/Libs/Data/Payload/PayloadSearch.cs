namespace Niftyers;

public class PayloadSearch : DtoUserInfo {
    public string ColumnName { get; set; } = "";
    public string Qualifier { get; set; } = "";
    public string Value { get; set; } = "";
}