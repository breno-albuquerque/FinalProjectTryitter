using Tryitter.Entities;
using Tryitter.Services;
using Microsoft.EntityFrameworkCore;

namespace Tryitter.Repository
{
    public class TryitterRepository : ITryitterRepository
    {
        private readonly TryitterContext _context;
        private readonly TokenGenerator _tokenGenerator = new();

        public TryitterRepository(TryitterContext context)
        {
            _context = context;
        }

        public string? CreateStudent(Student student)
        {
            Student studentExists = _context.Students.Where(e => e.Email == student.Email).FirstOrDefault();
            if (studentExists != null)
            {
                return null;
            }
            _context.Students.Add(student);

            _context.SaveChanges();
            return _tokenGenerator.Generate(student);
        }
        public string? StudentLogin(Login login)
        {
            Student? student = _context.Students.Where(e =>e.Email == login.Email && e.Password == login.Password).FirstOrDefault();
            if (student == null)
            {
                return null;
            }
            return _tokenGenerator.Generate(student);
        }
  }
}
