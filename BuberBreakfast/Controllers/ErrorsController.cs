using Microsoft.AspNetCore.Mvc;
namespace BuberBreakfast.Controllers;
public class ErrorsController : ControllerBase
{
  [Route("/error")]
  public IActionResult Error()
  {
    // Here we can add error handling logic
    return Problem(); // 500 Internal Server Error
  }
}