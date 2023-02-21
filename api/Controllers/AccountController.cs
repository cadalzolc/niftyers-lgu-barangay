using Microsoft.AspNetCore.Mvc;

namespace Niftyers;

[ApiController]
[Route("Account")]
public class AccountController : ControllerBase 
{

    readonly IAccountServices svsAccount;
    public AccountController(IAccountServices _svsAccount) {
        svsAccount = _svsAccount;
    }

    public IActionResult Get() 
    {
        var lst = svsAccount.List();
        return Ok(lst);
    }

    [HttpPost("user/create")]
    public IActionResult UserCreate([FromBody] PayloadUser payload) 
    {     
        var result = svsAccount.Create(payload);
        return Ok(result);
    }

    [HttpPost("user/update")]
    public IActionResult UserUpdate([FromBody] PayloadUser payload)
    {
        var result = svsAccount.Update(payload);
        return Ok(result);
    }
    [HttpPost("user/delete")]
    public IActionResult UserDelete([FromBody] PayloadUser payload)
    {
        var result = svsAccount.Delete(payload);
        return Ok(result);
    }

    [HttpGet("user/{id?}")]
    public IActionResult FindUser(string id)
    {
        var result = svsAccount.FindById(id);
        return Ok(result);
    }
    [HttpGet("user/search")]
    public IActionResult UserSearch([FromBody] PayloadSearch payload)
    {
        var result = svsAccount.Search(payload);
        return Ok(result);
    }

}