namespace Niftyers; 

public interface IResidentServices
{
    Response List();
    Response Create(PayloadResident payload);
    Response Update(PayloadResident payload);
}