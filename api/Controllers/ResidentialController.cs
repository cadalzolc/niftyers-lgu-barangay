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

    [HttpGet("create/resident")]
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
    [HttpGet("user/Delete/residential")]
    public IActionResult UserResidentialDelete([FromBody] PayloadUser payload)
    {
        //var result = svsResidential.UserDelete(payload);
        return Ok();
    }
    [HttpGet("user/search/residential")]
    public IActionResult UserResidentialSearch([FromBody] PayloadSearch payload)
    {
        //var result = svsResidential.UserSearch(payload);
        return Ok();
    }
}
