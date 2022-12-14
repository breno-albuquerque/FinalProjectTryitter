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
        Post? GetPost (int postId);
        List<Post>? Posts(int studentId);
        void EditPost(Post post, Post updatePost);
    }
}
