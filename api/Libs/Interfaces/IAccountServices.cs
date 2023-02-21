namespace Niftyers;

public interface IAccountServices 
{   
    ResponseUserList List();
    ResponseUser Create(PayloadUser payload);
    ResponseUser Update(PayloadUser payload);
    Response Delete(PayloadUser payload);
    ResponseUser FindById(string id);
    ResponseUserList Search(PayloadSearch payload);
}