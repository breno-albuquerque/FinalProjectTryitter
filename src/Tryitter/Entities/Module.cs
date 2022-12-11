using System.ComponentModel.DataAnnotations;

namespace Tryitter.Entities
{
    public class Module
    {
        [Key]
        public int? ModuleId { get; set; }

        public string? Title { get; set; }

        public ICollection<Student>? Students { get; set; }
    }
}
