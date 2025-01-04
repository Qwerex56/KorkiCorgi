using System.Text.Json;
using KorkiCorgi.DataTransferObjects;
using KorkiCorgi.Services;
using Microsoft.AspNetCore.Mvc;

namespace KorkiCorgi.Controllers;

// TODO: https://learning.oreilly.com/library/view/architecting-asp-net-core/9781805123385/Text/Chapter_13.xhtml#_idParaDest-385
// TODO: https://learning.oreilly.com/library/view/architecting-asp-net-core/9781805123385/Text/Chapter_06.xhtml

[ApiController]
[Route("api/v1/[controller]")]
public class AccountController : Controller {
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService) {
        _accountService =
            accountService ?? throw new ArgumentNullException(nameof(accountService));
    }

    [HttpPost(Name = nameof(CreateAccount))]
    public ActionResult<string> CreateAccount([FromBody] UserDto userDto) {
        if (!ModelState.IsValid) {
            return BadRequest(userDto);
        }
        
        var result = _accountService.RegisterNewAccount(userDto);
        
        if (result is false) {
            return BadRequest();
        }
        
        var msg = JsonSerializer.Serialize(result);
        
        Console.WriteLine(msg);
        
        return Ok(result);
    }

    // [HttpPost]
    // public IActionResult LoginToAccount(UserDto userDto) {
    //     if (!ModelState.IsValid) {
    //         return BadRequest(userDto);
    //     }
    //
    //     return Ok();
    // }

    [HttpGet(Name = nameof(GetAccount))]
    public IActionResult GetAccount() {
        var user = _accountService.GetUserByEmail("us@example.com");
        return Ok(user);
    }
}