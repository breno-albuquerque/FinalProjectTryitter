using FluentAssertions;
using Tryitter.Transport;
using Xunit.Sdk;

namespace TryitterTest.Transport
{
    public class LoginRequestTest
    {
        private readonly string _email;
        private readonly string _password;

        public LoginRequestTest()
        {
            _email = "teste@teste.com";
            _password = "teste123";
        }

        [Fact(DisplayName = "Deve instanciar o objeto com propriedades corretas")]
        public void ShouldInstanceObject()
        {
            //  arrange - act
            var loginRequest = new LoginRequest
            {
                Email = _email,
                Password = _password
            };

            // assert
            AssertProperties(loginRequest, _email, _password);
        }

        [Fact(DisplayName = "Deve lançar excessão com propriedades inválidas")]
        public void ShouldThrowExcepetionWithInvalidProperties()
        {
            //  arrange 
            var loginRequest = new LoginRequest
            {
                Email = "teste",
                Password = _password
            };

            //  act
            Action act = () => AssertProperties(loginRequest, _email, _password);

            //  assert
            act.Should().Throw<XunitException>();
        }

        private static void AssertProperties(LoginRequest result, string email, string password)
        {
            result.Email.Should().Be(email);
            result.Password.Should().Be(password);
        }
    }
}

