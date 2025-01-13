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
    
    
    public IActionResult LoginToAccount([FromBody] UserDto userDto) {
        if (!ModelState.IsValid) {
            return BadRequest(userDto);
        }

        if (_accountService.LoginAccount(userDto)) {
            HttpContext.Response.Cookies.Append("user", userDto.Email, new CookieOptions{
                Expires = DateTime.UtcNow.AddDays(7),
                IsEssential = true,
            });

            return Ok("User logged in.");
        }
        
        return BadRequest("Invalid password or username.");
    }

    public IActionResult GetLoginState() {
        if (HttpContext.Request.Cookies.TryGetValue("user", out var user)) {
            return Ok($"Welcome back, {user}.");
        }

        return NotFound("No user login state found.");
    }

    [HttpGet(Name = nameof(GetAccount))]
    public IActionResult GetAccount() {
        var user = _accountService.GetUserByEmail("us@example.com");
        return Ok(user);
    }
}