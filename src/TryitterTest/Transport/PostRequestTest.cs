using FluentAssertions;
using Tryitter.Transport;
using Xunit.Sdk;

namespace TryitterTest.Transport
{
    public class PostRequestTest
    {
        private readonly int _studentId;
        private readonly string _post;
        private readonly string _image;

        public PostRequestTest()
        {
            _studentId = 1;
            _post = "teste123";
            _image = "teste";
        }

        [Fact(DisplayName = "Deve instanciar o objeto com propriedades corretas")]
        public void ShouldInstanceObject()
        {
            //  arrange - act
            var createPostRequest = new PostRequest
            {
                StudentId = _studentId,
                Post = _post,
                Image = _image
            };

            // assert
            AssertProperties(createPostRequest, _studentId, _post, _image);
        }

        [Fact(DisplayName = "Deve lançar excessão com propriedades inválidas")]
        public void ShouldThrowExcepetionWithInvalidProperties()
        {
            //  arrange 
            var createPostRequest = new PostRequest
            {
                Post = _post,
                Image = _image
            };

            //  act
            Action act = () => AssertProperties(createPostRequest, _studentId, _post, _image);

            //  assert
            act.Should().Throw<XunitException>();
        }

        private static void AssertProperties(PostRequest result, int studentId, string post, string image)
        {
            result.StudentId.Should().Be(studentId);
            result.Post.Should().Be(post);
            result.Image.Should().Be(image);
        }
    }
}
