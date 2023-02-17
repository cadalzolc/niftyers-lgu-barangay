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
        var lst = svsAccount.UserList();
        return Ok(lst);
    }

    [HttpPost("user/create")]
    public IActionResult UserCreate([FromBody] PayloadUser payload) 
    {     
        var result = svsAccount.UserCreate(payload);
        return Ok(result);
    }

    [HttpPost("user/update")]
    public IActionResult UserUpdate([FromBody] PayloadUser payload)
    {
        var result = svsAccount.UserUpdate(payload);
        return Ok(result);
    }
    [HttpPost("user/delete")]
    public IActionResult UserDelete([FromBody] PayloadUser payload)
    {
        var result = svsAccount.UserDelete(payload);
        return Ok(result);
    }

    [HttpGet("user/{id?}")]
    public IActionResult FindUser(string id)
    {
        var result = svsAccount.UserFindById(id);
        return Ok(result);
    }

}