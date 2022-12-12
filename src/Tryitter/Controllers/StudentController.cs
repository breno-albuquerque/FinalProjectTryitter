using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tryitter.Entities;
using Tryitter.Repository;
using Tryitter.Transport;

namespace Tryitter.Controllers
{
    [ApiController]
    [Route("students")]
    public class StudentController : Controller
    {
        private readonly ITryitterRepository _tryitterRepository;

        public StudentController(ITryitterRepository tryitterRepository)
        {
            _tryitterRepository = tryitterRepository;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult CreateStudent([FromBody] Student student)
        {
            
            string token = _tryitterRepository.CreateStudent(student);
            if (token == null)
            {
                return Problem("Student already exists", default, 400);
            }
            return StatusCode(201, new { token });
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult StudentLogin([FromBody] Login login)
        {
            string token = _tryitterRepository.StudentLogin(login);
            if (token == null)
            {
                return Problem("Student does not exists", default, 400);
            }
            return StatusCode(201, new { token });
        }
    }
}