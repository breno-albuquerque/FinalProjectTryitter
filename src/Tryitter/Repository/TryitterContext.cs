using Microsoft.EntityFrameworkCore;
using Tryitter.Entities;

namespace Tryitter.Repository
{
    public class TryitterContext : DbContext, ITryitterContext
    {
        public TryitterContext(DbContextOptions<TryitterContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Module> Modules { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"
                Server=127.0.0.1;
                Database=tryitter_db;
                User=SA;
                Password=tryitter-strong-password;
                Encrypt=False;
            ");
            }
        }
    }
}
