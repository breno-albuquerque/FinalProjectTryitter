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

        public string CreateStudent(Student student)
        {
            Student studentExists = _context.Students.Where(e => e.Email == student.Email).FirstOrDefault()!;

            if (studentExists != null)
                throw new InvalidOperationException("Student already exists");

            _context.Students.Add(student);
            _context.SaveChanges();

            return _tokenGenerator.Generate(student);
        }

        public Student GetStudent(int studentId)
        {
            var student = _context.Students.Where(s => s.StudentId == studentId).FirstOrDefault();

            if (student == null)
                throw new InvalidOperationException("Student Not Found");

            return student;
        }

        public void UpdateStudent(int studentId, Student newStudent)
        {
            var student = GetStudent(studentId);

            student.Email = newStudent.Email;
            student.Password = newStudent.Password;
            student.FullName = newStudent.FullName;

            _context.SaveChanges();
        }

        public void DeleteStudent(int studentId)
        {
            var student = GetStudent(studentId);

            _context.Students.Remove(student);
            _context.SaveChanges();
        }

        public string StudentLogin(Login login)
        {
            Student? student = _context.Students.Where(e => e.Email == login.Email && e.Password == login.Password).FirstOrDefault();

            if (student == null)
                throw new InvalidOperationException("Invalid login credentials");

            return _tokenGenerator.Generate(student);
        }

        public void CreatePost(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
        }

        public Post GetPost(int postId)
        {
            var post = _context.Posts.Where(p => p.PostId == postId).FirstOrDefault();

            if (post == null)
                throw new InvalidOperationException("Post not found");

            return post;
        }

        public void UpdatePost(int postId, Post updatePost)
        {
            var post = GetPost(postId);

            if (post.StudentId != updatePost.StudentId)
                throw new InvalidOperationException($"You can't update a post from another student");

            post.Text = updatePost.Text;
            post.Image = updatePost.Image;

            _context.SaveChanges();
        }

        public void DeletePost(int postId, int studentId)
        {
            var post = GetPost(postId);

            if (post.StudentId != studentId)
                throw new InvalidOperationException($"You can't delete a post from another student");

            _context.Remove(post);
            _context.SaveChanges();
        }
    }
}
