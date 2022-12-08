namespace Tryitter.Entities
{
    public class Module
    {
        public int? ModuleId { get; set; }

        public string Subject { get; set; }

        public int BlocksQuantity { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
