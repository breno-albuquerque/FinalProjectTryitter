using Tryitter.Entities;

namespace Tryitter.Repository
{
    public class TryitterRepository : ITryitterRepository
    {
        private readonly ITryitterContext _context;

        public TryitterRepository(ITryitterContext context)
        {
            _context = context;
        }

        public void CreateStudent(Student student)
        {
            _context.Students.Add(student);

            _context.SaveChanges();
        }
    }
}
