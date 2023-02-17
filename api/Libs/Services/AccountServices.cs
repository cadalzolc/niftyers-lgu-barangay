using System.Linq;

namespace Niftyers;

public class AccountServices : IAccountServices {
    
    readonly IRepository<User> dbUsers;
    public AccountServices(IRepository<User> _dbUsers) {
        dbUsers = _dbUsers;
    }

    public ResponseUserList UserList() {
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

    public ResponseUser UserFindById(string id)
    {
        var Result = new ResponseUser();

        if (id == null || id == "")
        {
            Result.Message = "Id is Required";
            return Result;
        }

        var UserResult = dbUsers.Find(User => User.Id.ToString() == id);
        
        if (UserResult == null)
        {
            Result.Message = "User Not-Found";
            return Result;
        }

        Result.Data = new DtoUserInfo(){
            Id = UserResult.Id.ToString(),
            Name = UserResult.Name,
            Username = UserResult.Username,
            Password = UserResult.Password
        };
        Result.Success = true;
        Result.Message = "User found";
        
        return Result;
    }

    public ResponseUserList UserSearch(PayloadSearch payload)
    {
        var Result = new ResponseUserList();

        if (payload.ColumnName == null || payload.ColumnName == "")
        {
           Result.Message = " Column name is Required ";
           return Result;
        }
       
        if (payload.Qualifier == null || payload.Qualifier == "")
        {
           Result.Message = " Qualifier is Required";
           return Result;
        }

        var LstUser = new List<User>();

        switch(payload.Qualifier) {
            case "==":
                if (payload.ColumnName == "name") {
                    LstUser = dbUsers.List(user => user.Name == payload.Value).ToList();
                } else {
                    LstUser = dbUsers.List(user => user.Username == payload.Value).ToList();
                }
            break;
            case "()":
                if (payload.ColumnName == "name") {
                    LstUser = dbUsers.List(user => user.Name.ToLower().Contains(payload.Value.ToLower())).ToList();
                } else {
                    LstUser = dbUsers.List(user => user.Username.ToLower().Contains(payload.Value.ToLower())).ToList();
                }
            break;
            case "!=":
                if (payload.ColumnName == "name") {
                    LstUser = dbUsers.List(user => user.Name != payload.Value).ToList();
                } else {
                    LstUser = dbUsers.List(user => user.Username != payload.Value).ToList();
                }
            break;
        }

        Result.Data = LstUser.Select(u => new DtoUserInfo {
            Id = u.Id.ToString(),
            Name = u.Name,
            Username = u.Username,
            Password = u.Password
        });
        Result.Success = true;
        Result.Message = string.Format("{0} records found", LstUser.Count());
            
        return Result;
    }
    

}