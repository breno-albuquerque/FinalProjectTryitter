using Tryitter.Entities;

namespace Tryitter.Repository
{
    public class TryitterRepository : ITryitterRepository
    {
        private readonly ITryitterContest _context;

        public TryitterRepository(ITryitterContext context)
        {
            _context = context;
        }

        public void CreateStudent(Student student)
        {
            _context.Students.Add(student);

            _context.SaveChanges();
        }
        private bool StudentExists(int registration)
        {
            return (_context.Students?.Any(e => e.Registration == registration)).GetValueOrDefault();
        }
  }
}
