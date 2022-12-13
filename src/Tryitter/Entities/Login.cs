using System.ComponentModel.DataAnnotations;

namespace Tryitter.Entities
{
    public struct Login
    {
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Email is not valid")]
        public string Email { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;

        public Login(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}