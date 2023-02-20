using Microsoft.AspNetCore.Mvc;

namespace Niftyers;

[ApiController]
[Route("Residential")]

public class ResidentialController : ControllerBase 
{
    //readonly svsResidential;
    //public ResidentialController(IAccountServices _svsRedisdential){
        //svsResidential = _svsRedisdential;
    //}

    public IActionResult Get()
    {
        //var lst = svsResidential.UserList();
        return Ok();
    }

    [HttpGet("user/create/residential")]
    public IActionResult UserResidentialCreate([FromBody] PayloadUser payload)
    {
        //var result = svsResidential.UserCreate(payload);
        return Ok();
    }
    [HttpPost("user/update/residential")]
    public IActionResult UserResidentialUpdate([FromBody] PayloadUser payload)
    {
        //var result = svsResidential.UserUpdate(payload);
        return Ok();
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
