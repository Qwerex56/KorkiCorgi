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

    [HttpPost(template: nameof(CreateAccount), Name = nameof(CreateAccount))]
    public ActionResult<string> CreateAccount([FromBody] UserDto userDto) {
        if (!ModelState.IsValid) {
            return BadRequest(userDto);
        }
        
        var result = _accountService.RegisterNewAccount(userDto);
        
        if (result is false) {
            return BadRequest();
        }

        return Ok(result);
    }
    
    [HttpGet(template: nameof(LoginToAccount), Name = nameof(LoginToAccount))]    
    public IActionResult LoginToAccount([FromBody] UserDto userDto) {
        if (!ModelState.IsValid) {
            Console.WriteLine("bad dto");
            return BadRequest(userDto);
        }

        if (_accountService.LoginAccount(userDto)) {
            Console.WriteLine("Will log in");
            
            HttpContext.Response.Cookies.Append("user", userDto.Email, new CookieOptions{
                Expires = DateTime.UtcNow.AddDays(7),
                IsEssential = true,
            });
            
            return Ok("User logged in.");
        }
        
        Console.WriteLine("Will not log in");
        
        return BadRequest("Invalid password or username.");
    }
    
    [HttpGet("/GetLoginState")]
    public IActionResult GetLoginState() {
        if (!HttpContext.Request.Cookies.TryGetValue("user", out var user)) {
            return NotFound("No user login state found.");
        }
        
        var userDto = JsonSerializer.Deserialize<string>(user);
        return Ok(userDto);
    }

    [HttpGet(template: "/GetAccount/{email}", Name = nameof(GetAccount))]
    public IActionResult GetAccount(string email) {
        var user = _accountService.GetUserByEmail(email);
        return Ok(user);
    }
}