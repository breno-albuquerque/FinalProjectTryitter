using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Tryitter.Transport
{
    public class StudentRequest
    {
        [JsonPropertyName("email")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Email is not valid")]
        public string? Email { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("fullName")]
        public string FullName { get; set; }
    }
}
