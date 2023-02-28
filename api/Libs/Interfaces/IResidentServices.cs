namespace Niftyers; 

public interface IResidentServices
{
    ResidentsResponseList List();
    Response Create(PayloadResident payload);
    Response Update(PayloadResident payload);
    Response Delete(PayloadResident payload);
    ResidentsResponse Find(string ID);
    ResidentsResponseList Search(PayloadResidentSearch payload);
}