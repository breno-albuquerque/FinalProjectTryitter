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

        [HttpPost("post")]
        public IActionResult CreateStudent([FromBody] CreateStudentRequest request)
        {
            var student = new Student
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
            };

            _tryitterRepository.CreateStudent(student);

            return NoContent();
        }
    }
}