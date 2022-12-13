using System.ComponentModel.DataAnnotations;

namespace Tryitter.Entities
{
    public class Student
    {
        [Key]
        public int? StudentId { get; set; }

        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Email is not valid")]
        public string Email { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;

        [Required]
        public string FullName { get; set; } = null!;

        public Module? Module { get; set; }

        public ICollection<Post>? Posts { get; set; }
    }
}
