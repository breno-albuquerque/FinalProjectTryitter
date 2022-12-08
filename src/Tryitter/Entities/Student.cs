namespace Tryitter.Entities
{
    public class Student
    {
        public int? StudentId { get; set; }

        public long Cpf { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Module? Module { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}
