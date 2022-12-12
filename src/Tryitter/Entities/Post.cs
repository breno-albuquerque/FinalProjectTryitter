using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tryitter.Entities
{
    public class Post
    {
        public int? PostId { get; set; }
        public int StudentId { get; set; }
        public string Text { get; set; }
        public object? Images { get; set; }
  }
}
