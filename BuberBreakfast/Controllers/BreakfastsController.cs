using BuberBreakfast.Models;
using BuberBreakfast.Contracts.Breakfast;
using Microsoft.AspNetCore.Mvc;
using BuberBreakfast.Services.Breakfasts;

namespace BuberBreakfast.Controllers;
[ApiController]
[Route("[controller]")]
public class BreakfastsController : ControllerBase
{
  private readonly IBreakfastService _service;

  public BreakfastsController(IBreakfastService service)
  {
    _service = service;
  }

  [HttpPost]
  public IActionResult CreateBreakfast(CreateBreakfastRequest request)
  {
    // Mapping the data from the request to the internal representation of the model
    var breakfast = new Breakfast(
      Guid.NewGuid(),
      request.Name,
      request.Description,
      request.StartDateTime,
      request.EndDateTime,
      DateTime.UtcNow,
      request.Savory,
      request.Sweet
    );
    // Apply the application logic
    _service.CreateBreakfast(breakfast);
    // Converting the data back to the Api definition
    var response = new BreakfastResponse(
      breakfast.Id,
      breakfast.Name,
      breakfast.Description,
      breakfast.StartDateTime,
      breakfast.EndDateTime,
      breakfast.LastModifiedDateTime,
      breakfast.Savory,
      breakfast.Sweet
    );
    // Returning the proper response
    return CreatedAtAction(
      actionName: nameof(GetBreakfast),
      routeValues: new { id = breakfast.Id },
      value: response
    );
  }

  [HttpGet("{id:guid}")]
  public IActionResult GetBreakfast(Guid id)
  {
    Breakfast breakfast = _service.GetBreakfast(id);
    // Mapping to the response
    var response = new BreakfastResponse(
      breakfast.Id,
      breakfast.Name,
      breakfast.Description,
      breakfast.StartDateTime,
      breakfast.EndDateTime,
      breakfast.LastModifiedDateTime,
      breakfast.Savory,
      breakfast.Sweet
    );
    return Ok(response);
  }

  [HttpPut("{id:guid}")]
  public IActionResult UpsertBreakfast(Guid id, UpsertBreakfastRequest request)
  {
    return Ok(request);
  }

  [HttpDelete("{id:guid}")]
  public IActionResult DeleteBreakfast(Guid id)
  {
    return Ok(id);
  }
}