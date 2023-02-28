namespace Niftyers;

public class ResidentServices : IResidentServices  {
    
    readonly IRepository<Resident> repositoryResident;
    public ResidentServices(IRepository<Resident> injectResident) {
         repositoryResident = injectResident;
    }

    public ResidentsResponseList List() {
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
        return new ResidentsResponseList() {
            Success = true,
            Message = string.Format("{0} no records found", lst.Count()),
            Data = lst
        };
    }

    public Response Create(PayloadResident payload) {

        var Result = new Response();
        var duplication = repositoryResident.Exists(Resident => Resident.FirstName == payload.FirstName);

        if (duplication == true) {
            Result.Message = "Resident Already Exist";
            return Result;
        }

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
        var result = new ResidentsResponse();

        if (payload.ID == null || payload.ID == ""){
           result.Message = "ID is Required";
            return result;
        } 
        var duplication = repositoryResident.Exists( response => response.FirstName == payload.FirstName && response.ID.ToString() != payload.ID);
        
        if (duplication == true) 
        {
            result.Message = "Resident Already Exist";
            return result;
        }

        var NotResident = repositoryResident.Find(Response => Response.ID.ToString() == payload.ID);
        
        if (NotResident == null )
        {
            result.Message = "Resident Not Found";
            return result;
        } 

        NotResident.FirstName = payload.FirstName;
        NotResident.LastName = payload.LastName;
        NotResident.MidleName = payload.MidleName;
        NotResident.Gender = payload.Gender;
        NotResident.BirthDate = payload.BirthDate;
        NotResident.Age = 0;
        NotResident.CivilStatus = payload.CivilStatus;
        NotResident.Address = payload.Address;
        NotResident.Occupation = payload.Occupation;
        NotResident.ContactNumber = payload.ContactNumber;


        var Isresident = repositoryResident.Update(NotResident);

        if (Isresident == false){
            result.Message = "User Update Falied";
            return result;
        }

         result.Data = new DtoResident(){
            ID = NotResident.ID.ToString(),
            NO = NotResident.No,
            FirstName = NotResident.FirstName,
            LastName = NotResident.LastName,
            MidleName = NotResident.MidleName,
            Gender = NotResident.Gender,
            BirthDate = NotResident.BirthDate,
            Age = "0",
            CivilStatus = NotResident.CivilStatus,
            Address = NotResident.Address,
            Occupation = NotResident.Occupation,
            ContactNumber = NotResident.ContactNumber,

        };
        result.Success = true;
        result.Message = "Successly Updated";

        return result;
    }

    public Response Delete(PayloadResident payload)
    {
       var result = new ResidentsResponse();

        if (payload.ID == null || payload.ID == "") {
            
            result.Message = " ID is Required";
            return result;

        }

        var Resident = repositoryResident.Find( Resident => Resident.ID.ToString() == payload.ID );

        if (payload.ID == null)
        {
        
        result.Message = "Resident Not Found";
        return result;

        }

        Resident.No = payload.NO;
        Resident.FirstName = payload.FirstName;
        Resident.LastName = payload.LastName;
        Resident.MidleName = payload.MidleName;
        Resident.Gender = payload.Gender;
        Resident.BirthDate = payload.BirthDate;
        Resident.Age = 0;
        Resident.CivilStatus = payload.CivilStatus;
        Resident.Occupation = payload.Occupation;
        Resident.ContactNumber = payload.ContactNumber;

        var IsDeleted = repositoryResident.Delete(Resident);

        result.Success = true;
        result.Message = "Successfully Deleted!";

        return result;
       
}
    public ResidentsResponse Find(string ID)
    {
         var result = new ResidentsResponse();

         if (ID == null || ID == "")
         {
            result.Message = "Residents ID Required";
            return result;
         } 
         
         var Resident = repositoryResident.Find(resident => resident.ID.ToString() == ID);

         if ( Resident == null)
         {
            result.Message = "Resident Not-Found";
            return result;
         } 
         result.Data = new DtoResident(){

            FirstName = Resident.FirstName,
            MidleName = Resident.MidleName,
            LastName = Resident.LastName,
            Gender = Resident.Gender,
            BirthDate = Resident.BirthDate,
            Age = "0",
            Address = Resident.Address,
            Occupation = Resident.Occupation,
            ContactNumber = Resident.ContactNumber,
        
         };
         result.Success = true;
         result.Message = "Resident Found";
         

         return result;
    }

    public ResidentsResponseList Search(PayloadResidentSearch payload)
    {
        var result = new ResidentsResponseList();

        if(payload.FirstName == null || payload.FirstName == "")
        {
            result.Message = "First name is Required ";
            return result;
        }

        if(payload.Qualifier == null || payload.Qualifier == "" )
        {
            result.Message = "Qualifier is Required";
            return result;
        }

        var ListResident = new List<Resident>();

        switch(payload.Qualifier){
            case "==":
                if (payload.MembersName == "name"){
                    ListResident = repositoryResident.List(Resident => Resident.FirstName == payload.Value).ToList();
                } else {
                    ListResident = repositoryResident.List(Resident => Resident.FirstName == payload.Value).ToList();
                }
                break; 
                case "()":
                    if (payload.MembersName == "name"){
                        ListResident = repositoryResident.List(Resident => Resident.FirstName != payload.Value ).ToList();
                    } else {
                        ListResident = repositoryResident.List(Resident => Resident.FirstName != payload.Value).ToList();
                    }
                break; 
        }
        result.Data = ListResident.Select(Resident => new DtoResident{
            ID = Resident.ID.ToString(),
            FirstName =Resident.FirstName,
            MidleName = Resident.MidleName,
            LastName = Resident.LastName,
            Gender = Resident.Gender,
            BirthDate = Resident.BirthDate,
            Age = "0",
            Address = Resident.Address,
            Occupation = Resident.Occupation,
            ContactNumber = Resident.ContactNumber
        });
        result.Success = true;
        result.Message = string.Format("{0} Records Found", ListResident.Count());

        return result;
    }

     
}
