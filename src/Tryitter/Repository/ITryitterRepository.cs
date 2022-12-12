using Tryitter.Entities;

namespace Tryitter.Repository
{
    public interface ITryitterRepository
    {
        string CreateStudent(Student student);
        string StudentLogin(Login login);
    }
}
