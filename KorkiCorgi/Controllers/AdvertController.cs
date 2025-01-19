using KorkiCorgi.Models;
using KorkiCorgi.Services;
using Microsoft.AspNetCore.Mvc;

namespace KorkiCorgi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class AdvertController : Controller {
    private readonly IAdvertService _advertService;

    public AdvertController(IAdvertService advertService) {
        _advertService = advertService ?? throw new ArgumentNullException();
    }

    [HttpGet("{advertId:int}", Name = nameof(GetAdvert))]
    public ActionResult<Advert?> GetAdvert(int advertId) {
        if (!ModelState.IsValid) {
            return BadRequest("Incorrect api call.");
        }
        
        if (advertId < 0) {
            return NotFound(advertId);
        }

        var result = _advertService.GetAdvertById(advertId);

        if (result is not null) {
            return Ok(result);
        }

        return NotFound(result);
    }

    [HttpGet()]
    public ActionResult<IEnumerable<Advert>> GetAllAdverts() {
        var result = _advertService.GetAllAdverts();

        return Ok(result);
    }

    [HttpGet(nameof(GetUserAdverts) + "/{userId:int}", Name = nameof(GetUserAdverts))]
    public ActionResult<IEnumerable<Advert>> GetUserAdverts(int userId) {
        return Ok((_advertService.GetAllUserAdverts(userId)));
    }

    [HttpDelete(nameof(DeleteAdvert) + "/{id:int}", Name = nameof(DeleteAdvert))]
    public IActionResult DeleteAdvert(int id) {
        HttpContext.Request.Cookies.TryGetValue("user", out var user);
        
        if (user is null) {
            return BadRequest("You must be logged in.");
        }
        
        var result = _advertService.DeleteAdvert(id);
        return result ? Ok() : BadRequest();
    }
}