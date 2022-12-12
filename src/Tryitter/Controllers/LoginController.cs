using Microsoft.AspNetCore.Mvc;
using Tryitter.Entities;
using Tryitter.Repository;
using Tryitter.Services;

namespace Tryitter.Controllers;

[ApiController]
[Route("[controller]")]
public class LoginController : ControllerBase
{
    [HttpPost]
    public ActionResult<string> Login([FromBody] Student student)
    {
        try
        {
            TryitterRepository tryitterRepository = new();
            var newStudent = TryitterRepository.(student);
            if (!newStudent)
            {
                return NotFound("Student not found.");
            }
            var token = new TokenGenerator().Generate();
            return Ok(token);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
