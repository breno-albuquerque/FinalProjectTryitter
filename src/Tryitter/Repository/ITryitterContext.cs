using Microsoft.EntityFrameworkCore;
using Tryitter.Entities;

namespace Tryitter.Repository
{
    public interface ITryitterContext
    {
        public int SaveChanges();
        public DbSet<Student> Students { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Module> Modules { get; set; }
    }
}
