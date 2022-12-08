﻿using System.Text.Json.Serialization;

namespace Tryitter.Transport
{
    public class CreateStudentRequest
    {
        [JsonPropertyName("cpf")]
        public long Cpf { get; set; }

        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; }
    }
}
