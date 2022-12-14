using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Tryitter.Transport
{
    public class PostRequest
    {
        [JsonPropertyName("post")]
        [Required(ErrorMessage = "O campo post está vazio")]
        [MaxLength(300, ErrorMessage = "Seu post pode ter até 300 caracteres")] 
        public string Post { get; set; } = null!;

        //preciso inserir a propriedade images aqui tb (definir se List ou Object)
        [JsonPropertyName("image")]
        public string Image { get; set; } = null!;
    }
}
