using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Tryitter.Entities;
using Tryitter.Services;

namespace TryitterTest.Integration
{
  public class TryitterPostsIntegrationTest : IClassFixture<TestingWebAppFactory<Program>>
  {
    private readonly TestingWebAppFactory<Program> _factory;

    public TryitterPostsIntegrationTest(TestingWebAppFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task ShouldReturnPosts()
    {
      var client = _factory.CreateClient();

      var response = await client.GetAsync("/posts");

      response.Content.Should().NotBeNull();
    }

    [Theory]
    [InlineData(1)]
    public async Task ShouldBeUnauthorizedWhenGettingPost(int id)
    {
        var app = _factory.CreateClient();

        var response = await app.GetAsync($"/posts/{id}");
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    [Theory]
    [InlineData(1)]
    public async Task ShouldBeAuthorizedWhenGettingPost(int id)
    {
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

    [Fact]
    public async Task PostShouldReturnContentWithText()
    {
      var app = _factory.CreateClient();

      var response = await app.GetAsync("/posts");

      var content = await response.Content.ReadAsStringAsync();

      content.Should().NotBeNull();
    }  
  }
}