using Microsoft.AspNetCore.Mvc;

namespace Niftyers;

[ApiController]
[Route("Residential")]

public class ResidentialController : ControllerBase 
{

    readonly IResidentServices svcResident;
    public ResidentialController(IResidentServices injectRes) 
    {
        svcResident = injectRes;
    }
    [HttpGet("resident/list")]
    public IActionResult Get()
    {
        var lst = svcResident.List();
        return Ok(lst);
    }

    [HttpPost("create/resident")]
    public IActionResult ResidentCreate([FromBody] PayloadResident payload)
    {
        var result = svcResident.Create(payload);
        return Ok(result);
    }
    [HttpPost("update/resident")]
    public IActionResult ResidentUpdate([FromBody] PayloadResident payload)
    {
        var result = svcResident.Update(payload);
        return Ok(result);
    }
    [HttpPost("Delete/Information")]
    public IActionResult ResidentDelete([FromBody] PayloadResident payload)
    {
        var result = svcResident.Delete(payload);
        return Ok(result);
    }
    [HttpGet("Resident/Find/Credentials")]
    public IActionResult ResidentFind(string ID)
    {
        var result = svcResident.Find(ID);
        return Ok(result);
    }
    [HttpGet("Resident/Search")]
    public IActionResult ResidentSearch([FromBody] PayloadResidentSearch payload)
    {
        var result = svcResident.Search(payload);
        return Ok(result);
    }
}
