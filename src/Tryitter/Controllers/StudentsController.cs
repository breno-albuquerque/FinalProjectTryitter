using Microsoft.AspNetCore.Mvc;
using Tryitter.Entities;
using Tryitter.Repository;
using Tryitter.Transport;

namespace Tryitter.Controllers
{
    [ApiController]
    [Route("students")]
    public class StudentsController : Controller
    {
        private readonly ITryitterRepository _tryitterRepository;

        public StudentsController(ITryitterRepository tryitterRepository)
        {
            _tryitterRepository = tryitterRepository;
        }

        [HttpPost("post")]
        public IActionResult CreateStudent([FromBody] CreateStudentRequest request)
        {
            var student = new Student
            {
                Cpf = request.Cpf,
                FirstName = request.FirstName,
                LastName = request.LastName,
            };

            _tryitterRepository.CreateStudent(student);

            return NoContent();
        }
    }
}