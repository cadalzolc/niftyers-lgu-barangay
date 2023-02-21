namespace Niftyers;

public class ResidentServices : IResidentServices  {
    
    readonly IRepository<Resident> repositoryResident;
    public ResidentServices(IRepository<Resident> injectResident) {
         repositoryResident = injectResident;
    }

    public Response List() {
        var lst = repositoryResident.List().Select(injecResident => new DtoResident() {
            ID = injecResident.ID.ToString(),
            FirstName = injecResident.FirstName,
            LastName = injecResident.LastName,
            MidleName = injecResident.MidleName,
            Gender = injecResident.Gender,
            BirthDate = injecResident.BirthDate,
            Age = injecResident.Age.ToString(""),
            CivilStatus = injecResident.CivilStatus,
            Address = injecResident.Address,
            Occupation = injecResident.Occupation,
            ContactNumber = injecResident.Occupation
        });
        return new Response() {
            Success = true,
            Message = string.Format("{0} no records found", lst.Count())
        };
    }

    public Response Create() {

        var Result = repositoryResident.List();
        return new Response();
    }
    
}