using Tryitter.Entities;

namespace TryitterTest.Entities
{
    public class PostTest
    {
        private readonly int _postId = 1;
        private readonly string _text = "test-text";
        private readonly string _image = "test-image";
  
        [Fact(DisplayName = "Deve instanciar a entidade")]
        public void shouldInstanceEntity()
        {
            var post = new Post
            {
                PostId = _postId,
                Text = _text,
                Image = _image
            };

            post.PostId.Should().Be(_postId);
            post.Text.Should().Be(_text);
            post.Image.Should().Be(_image);
        }
    }
}
