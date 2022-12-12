using Tryitter.Entities;
using Tryitter.Services;
﻿using Microsoft.EntityFrameworkCore;

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
        }

        public void CreatePost(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
            return _tokenGenerator.Generate(student);
        }

        public string? StudentLogin(Login login)
        {
            Student? student = _context.Students.Where(e =>e.Email == login.Email && e.Password == login.Password).FirstOrDefault();
            
            return _tokenGenerator.Generate(student);
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
