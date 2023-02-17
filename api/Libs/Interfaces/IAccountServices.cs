namespace Niftyers;

public interface IAccountServices 
{
     
    ResponseUserList UserList();
    ResponseUser UserCreate(PayloadUser payload);
    ResponseUser UserUpdate(PayloadUser payload);
    Response UserDelete(PayloadUser payload);
    ResponseUser UserFindById(string id);

}