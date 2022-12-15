using Tryitter.Entities;

namespace TryitterTest.Entities
{
    public class LoginTest
    {
        private readonly string _email = "test@email.com";
        private readonly string _password = "test-password";

        [Fact(DisplayName = "Deve instanciar a entidade")]
        public void shouldInstanceEntity()
        {
            var login = new Login
            {
                Email = _email,
                Password = _password
            };

            login.Email.Should().Be(_email);
            login.Password.Should().Be(_password);
        }
    }
}