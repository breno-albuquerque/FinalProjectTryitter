using Tryitter.Transport;
using Xunit.Sdk;

namespace TryitterTest.Transport
{
    public class CreateStudentRequestTest
    {
        private readonly string _email;
        private readonly string _password;
        private readonly string _fullName;

        public CreateStudentRequestTest()
        {
            _email = "teste@teste.com";
            _password = "teste123";
            _fullName = "teste";
        }

        [Fact(DisplayName = "Deve instanciar o objeto com propriedades corretas")]
        public void ShouldInstanceObject()
        {
            //  arrange - act
            var createStudentRequest = new CreateStudentRequest
            {
                Email = _email,
                Password = _password,
                FullName = _fullName
            };

            // assert
            AssertProperties(createStudentRequest, _email, _password, _fullName);
        }

        [Fact(DisplayName = "Deve lançar excessão com propriedades inválidas")]
        public void ShouldThrowExcepetionWithInvalidProperties()
        {
            //  arrange 
            var createStudentRequest = new CreateStudentRequest
            {
                Email = "teste",
                Password = _password,
                FullName = _fullName
            };

            //  act
            Action act = () => AssertProperties(createStudentRequest, _email, _password, _fullName);

            //  assert
            act.Should().Throw<XunitException>();
        }

        private static void AssertProperties(CreateStudentRequest result, string email, string password, string fullName)
        {
            result.Email.Should().Be(email);
            result.Password.Should().Be(password);
            result.FullName.Should().Be(fullName);
        }
    }
}
