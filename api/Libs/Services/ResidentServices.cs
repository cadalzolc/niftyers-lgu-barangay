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

    public Response Create(PayloadResident payload) {

        var Result = new Response();

        var newResident = new Resident() {
            ID = Guid.NewGuid(),
            No = payload.NO,
            FirstName = payload.FirstName,
            LastName = payload.LastName,
            MidleName = payload.MidleName,
            Gender = payload.Gender,
            BirthDate = payload.BirthDate,
            Age = 0,
            CivilStatus = payload.CivilStatus,
            Address = payload.Address,
            Occupation = payload.Occupation,
            ContactNumber = payload.Address
            
        };

        var IsCreate = repositoryResident.Create(newResident);

        if (IsCreate == false) {
            Result.Message = "Resident Was Not Created ";
            return Result;
        }

        Result.Success = true;
        Result.Message = "Resident was Succesfully Created ";

        return Result;
    }
    public Response Update(PayloadResident payload)
    {
        var result = new Response();

        if (payload.ID == null || payload.ID == ""){
            result.Message = "ID is Required";
            return result;
        } 
        return result;
    }

    
    
}