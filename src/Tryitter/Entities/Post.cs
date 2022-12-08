namespace Tryitter.Entities
{
    public class Post
    {
        public int? PostId { get; set; }

        public Student Student { get; set; }

        public string Text { get; set; }
    }
}
