

using Tryitter.Entities;
using Tryitter.Services;

namespace TryitterTest
{
  public class TestToken
  {
    [Theory(DisplayName = "Token is not null")]
    [InlineData("teste@teste.com", "teste123")]
    public void TestTokenGeneratorSuccess(string email, string password)
    {
      Student student = new() { Email = email, Password = password };
      TokenGenerator token = new();
      string response = token.Generate(student);
      response.Should().NotBeNull();
    }

    [Theory(DisplayName = "TokenGenerator contains JWT 3 parts")]
    [InlineData("teste@teste.com", "teste123")]
    public void TestTokenGeneratorKeySuccess(string email, string password)
    {
      Student student = new() { Email = email, Password = password };
      var token = new TokenGenerator().Generate(student);
      var validTokenFormat = token.Split('.');
      Assert.Equal(3, validTokenFormat.Length);
    }
  }
}