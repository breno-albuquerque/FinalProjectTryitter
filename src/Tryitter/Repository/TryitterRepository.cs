using Microsoft.EntityFrameworkCore;
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

        public void CreatePost(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
        }

        public Post? GetPost(int postId)
        {
            return _context.Posts.Where(p => p.PostId == postId).FirstOrDefault();
        }

        public void EditPost(Post post, Post updatePost)
        {
            post.Text = updatePost.Text ?? post.Text;
            _context.SaveChanges();
        }

         public List<Post>? Posts(int studentId)
        {
            var student = _context.Students.Where(s => s.StudentId == studentId).FirstOrDefault();
            if (student == null)
            {
                return null;
            }
            return _context.Posts.Include(p => p.Images).Where(p => p.StudentId == studentId).OrderByDescending(p => p.PostId).ToList();
        }
    }
}
