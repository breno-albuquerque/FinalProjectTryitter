using System.Net;
using System.Net.Http.Headers;
using Tryitter.Entities;
using Tryitter.Services;

namespace TryitterTest.Integration
{
    public class TryitterIntegrationTest : IClassFixture<TestingWebAppFactory<Program>>
    {
        private readonly TestingWebAppFactory<Program> _factory;

        public TryitterIntegrationTest(TestingWebAppFactory<Program> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData(1)]
        public async Task ShouldBeUnauthorizedWhenGettingStudent(int id)
        {
            var student = new Student
            {
                StudentId = id,
                Email = "test@email.com",
            };

            var app = _factory.CreateClient();

            var response = await app.GetAsync($"/student/{id}");
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }

        [Theory]
        [InlineData(1)]
        public async Task ShouldBeAuthorizedWhenGettingStudent(int id)
        {
            var student = new Student
            {
                StudentId = id,
                Email = "test@email.com",
            };
            var token = new TokenGenerator().Generate(student);

            var app = _factory.CreateClient();
            app.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);       

            var response = await app.GetAsync($"/student/{id}");
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Theory]
        [InlineData(1)]
        public async Task ShouldBeUnauthorizedWhenGettingPost(int id)
        {
            var post = new Post
            {
                PostId = id,
                Text = "text",
                Image = "image"
            };

            var app = _factory.CreateClient();

            var response = await app.GetAsync($"/posts/{id}");
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Theory]
        [InlineData(1)]
        public async Task ShouldBeAuthorizedWhenGettingPost(int id)
        {
            var post = new Post
            {
                PostId = id,
                Text = "text",
                Image = "image"
            };

            var student = new Student
            {
                StudentId = id,
                Email = "test@email.com",
            };

            var token = new TokenGenerator().Generate(student);

            var app = _factory.CreateClient();
            app.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await app.GetAsync($"/posts/{id}");
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

    }
}
