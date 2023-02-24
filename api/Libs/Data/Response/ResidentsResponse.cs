namespace Niftyers;

public class ResidentsResponse : Response{ 
    public DtoResident Data { get; set; } = new DtoResident();

}

public class ResidentsResponseList : Response {
    public IEnumerable<DtoResident> Data {get; set;} = new List<DtoResident>();
}