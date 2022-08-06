using BuberBreakfast.Contracts.Breakfast;
using Microsoft.AspNetCore.Mvc;
namespace BuberBreakfast.Controllers;
[ApiController]
public class BreakfastsController : ControllerBase
{
  [HttpPost("/breakfasts")]
  public IActionResult CreateBreakfast(CreateBreakfastRequest request)
  {
    return Ok();
  }

  [HttpGet("/breakfasts/{id:guid}")]
  public IActionResult GetBreakfast(Guid id)
  {
    return Ok(id);
  }

  [HttpPut("/breafasts/{id:guid}")]
  public IActionResult UpsertBreakfastRequest(Guid id, UpsertBreakfastRequest request)
  {
    return Ok(request);
  }

  [HttpDelete("/breakfasts/{id:guid}")]
  public IActionResult DeleteBreakfast(Guid id)
  {
    return Ok(id);
  }
}