using Tryitter.Entities;

namespace Tryitter.Repository
{
    public interface ITryitterRepository
    {
        string CreateStudent(Student student);

        Student GetStudent(int studentId);

        void UpdateStudent(int studentId, Student student);

        void DeleteStudent(int idstudentId);

        string StudentLogin(Login login);

        void CreatePost (Post post);

        Post GetPost (int postId);

        void UpdatePost(int postId, Post post);

        void DeletePost(int postId, int studentId);
    }
}
