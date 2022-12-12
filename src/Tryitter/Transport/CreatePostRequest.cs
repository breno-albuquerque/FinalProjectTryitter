using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace Tryitter.Transport
{
    public class CreatePostRequest
    {
        [JsonPropertyName("studentId")]
        [Required(ErrorMessage = "O id do estudante é obrigatório")]
            public int StudentId { get; set; }

        [JsonPropertyName("post")]
        [Required(ErrorMessage = "O campo post está vazio")]
        [MaxLength(300, ErrorMessage = "Seu post pode ter até 300 caracteres")]
            public string Post { get; set; }

        //preciso inserir a propriedade images aqui tb (definir se List ou Object)
    }
}
