namespace Niftyers; 

public class DtoResident {
    public string ID { get; set; } = "";
    public string NO { get; set; } = "";
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string MidleName { get; set; } = "";
    public string Gender { get; set; } = "";
    public string BirthDate { get; set; } = "";
    public string Age { get; set; } = "";
    public string CivilStatus { get; set; } = "";
    public string Address { get; set; } = "";
    public string Occupation { get; set; } = "";
    public string ContactNumber { get; set; } = "";
}

public class DtoResidentInfo : Response
{
  public string ID { get; set; } = "";
  public string No { get; set; } = "";
}