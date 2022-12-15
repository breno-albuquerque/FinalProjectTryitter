using System.Net;
using System.Net.Http.Headers;
using Tryitter.Entities;
using Tryitter.Services;

namespace TryitterTest.Integration
{
    public class TryitterStudentsIntegrationTest : IClassFixture<TestingWebAppFactory<Program>>
    {
        private readonly TestingWebAppFactory<Program> _factory;

        public TryitterStudentsIntegrationTest(TestingWebAppFactory<Program> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData(1)]
        public async Task ShouldBeUnauthorizedWhenGettingStudent(int id)
        {
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
        public async Task ShouldReturnOkDeleteStudent(int id)
        {
            var student = new Student
            {
                StudentId = id,
                Email = "test@email.com",
            };

            var token = new TokenGenerator().Generate(student);

            var app = _factory.CreateClient();
            app.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
           
            var response = await app.DeleteAsync($"/student/{id}");

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

    }
}
