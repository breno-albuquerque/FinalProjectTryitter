﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tryitter.Entities
{
    public class Post
    {
        [Key]
        public int? PostId { get; set; }

        [MaxLength(300, ErrorMessage = "You reached the maximum amount of characters")]
        public string? Text { get; set; }
        public string? Image { get; set; }
        [ForeignKey("StudentId")]
        public int? StudentId { get; set; }
    }
}
