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
        public IActionResult CreateStudent([FromBody] StudentRequest request)
        {
            try
            {
                var student = new Student
                {
                    Email = request.Email,
                    Password = request.Password,
                    FullName = request.FullName,
                };

                string token = _tryitterRepository.CreateStudent(student);

                return StatusCode(201, new { token });
            } 
            catch (InvalidOperationException e)
            {
                return Conflict(e.Message);
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult GetStudent([FromRoute] int id)
        {
            try
            {
                var loggedStudentId = User.Claims.FirstOrDefault();  

                if (loggedStudentId.Value != id.ToString())
                    return Unauthorized($"You are not logged as student {id}");

                var student = _tryitterRepository.GetStudent(id);

                return Ok(student);
            }
            catch (InvalidOperationException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public IActionResult UpdateStudent([FromRoute] int id, [FromBody] StudentRequest request)
        {
            try
            {
                var loggedStudentId = User.Claims.FirstOrDefault();

                if (loggedStudentId.Value != id.ToString())
                    return Unauthorized($"You are not logged as student {id}");

                var student = new Student
                {
                    Email = request.Email,
                    Password = request.Password,
                    FullName = request.FullName,
                };

                _tryitterRepository.UpdateStudent(id, student);

                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult DeleteStudent([FromRoute] int id)
        {
            try
            {
                var loggedStudentId = User.Claims.FirstOrDefault();

                if (loggedStudentId.Value != id.ToString())
                    return Unauthorized($"You are not logged as student {id}");

                _tryitterRepository.DeleteStudent(id);

                return NoContent();
            }
            catch (InvalidOperationException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult StudentLogin([FromBody] LoginRequest request)
        {
            try
            {
                var login = new Login
                {
                    Email = request.Email,
                    Password = request.Password
                };

                string token = _tryitterRepository.StudentLogin(login);

                return StatusCode(201, new { token });
            }
            catch (InvalidOperationException e)
            {
                return Unauthorized(e.Message);
            }
        }
    }
}