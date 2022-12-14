using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tryitter.Entities;
using Tryitter.Repository;
using Tryitter.Transport;

namespace Tryitter.Controllers
{
    [ApiController]
    [Route("student")]
    public class StudentController : Controller
    {
        private readonly ITryitterRepository _tryitterRepository;

        public StudentController(ITryitterRepository tryitterRepository)
        {
            _tryitterRepository = tryitterRepository;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult CreateStudent([FromBody] CreateStudentRequest request)
        {
            var student = new Student
            {
                Email = request.Email!,
                Password = request.Password,
                FullName = request.FullName,
            };

            string token = _tryitterRepository.CreateStudent(student)!;

            if (token == null)
            {
                return Problem("Student already exists", default, 400);
            }

            return StatusCode(201, new { token });
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult StudentLogin([FromBody] LoginRequest request)
        {
            var login = new Login
            {
                Email = request.Email,
                Password = request.Password
            };

            string token = _tryitterRepository.StudentLogin(login);

            if (token == null)
            {
                return Problem("Student does not exists", default, 400);
            }

            return StatusCode(201, new { token });
        }
    }
}