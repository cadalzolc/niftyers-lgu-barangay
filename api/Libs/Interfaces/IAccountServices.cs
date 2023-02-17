namespace Niftyers;

public interface IAccountServices 
{
    ResponseUserList GetAllUsers();
    ResponseUser UserCreate(PayloadUser payload);
    ResponseUser UserUpdate(PayloadUser payload);
    Response UserDelete(PayloadUser payload);

}