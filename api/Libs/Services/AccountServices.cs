namespace Niftyers;

public class AccountServices : IAccountServices {
    
    readonly IRepository<User> dbUsers;
    public AccountServices(IRepository<User> _dbUsers) {
        dbUsers = _dbUsers;
    }

    public ResponseUserList GetAllUsers() {
        var lst =  dbUsers.List().Select(u => new DtoUserInfo() {
            Id = u.Id.ToString(),
            Name = u.Name,
            Username = u.Username,
            Password = u.Password
        });
        return new ResponseUserList() {
            Success = true,
            Message = string.Format("{0} no of records found", lst.Count()),
            Data = lst
        };
    }

    public ResponseUser UserCreate(PayloadUser payload)
    {
        var Result = new ResponseUser();
        var NewUser = new User() {
            Id = Guid.NewGuid(),
            Name = payload.Name,
            Username = payload.Username,
            Password = payload.Password
        };
      
        var IsCreated = dbUsers.Create(NewUser);

        if (IsCreated == false) {
            Result.Message = "User creation falied";
            return Result;
        }

        Result.Success = true;
        Result.Message =  "user is successfully created";
        Result.Data = new DtoUserInfo() {
            Id = NewUser.Id.ToString(),
            Name = NewUser.Name,
            Username = NewUser.Username,
            Password = NewUser.Password
        };

        return Result;
    }

    public ResponseUser UserUpdate(PayloadUser payload)
    {
        var Result = new ResponseUser();
        
        if (payload.Id == null || payload.Id == "") {
            Result.Message = "ID is Required";
            return Result;
        }

        var UserResult = dbUsers.Find(user => user.Id.ToString() == payload.Id);

        if ( UserResult == null)
        {
            Result.Message = "User Not Found";
            return Result;
        }

        UserResult.Name = payload.Name;
        UserResult.Username = payload.Username;
        UserResult.Password = payload.Password;
        
        var IsUpdated = dbUsers.Update(UserResult);

        if (IsUpdated == false) {
            Result.Message = "User update falied";
            return Result;
        }

        Result.Data = new DtoUserInfo(){
            Id = UserResult.Id.ToString(),
            Name = UserResult.Name,
            Username = UserResult.Username,
            Password = UserResult.Password
        };
        Result.Success = true;
        Result.Message = "Sucessfully updated"; 

        return Result;

    }

    public Response UserDelete(PayloadUser payload)
    {
        var Result = new Response();


        if ( payload.Id == null || payload.Id == "") {
            
            Result.Message = " ID is Required";
            return Result;
        }

        var UserResult = dbUsers.Find( user => user.Id.ToString() == payload.Id);

        if (UserResult == null) 
        {
            Result.Message = "User  Not-Found";
            return Result;
        }

        UserResult.Name = payload.Name;
        UserResult.Username = payload.Username;
        UserResult.Password = payload.Password;

        var IsDeleted = dbUsers.Delete(UserResult);

        Result.Success = true;
        Result.Message = " Succesfully Deleted!";

        return Result; 
    }

}