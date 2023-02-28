namespace Niftyers;

public abstract class Person {
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string MidleName { get; set; } = string.Empty;
    public string Gender { get; set; } = string.Empty;
    public string BirthDate { get;  set;} = string.Empty;
    public int Age { get; set; } = 0;
    public string CivilStatus { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Occupation { get; set; } = string.Empty;
    public string ContactNumber { get; set; } = string.Empty;
}