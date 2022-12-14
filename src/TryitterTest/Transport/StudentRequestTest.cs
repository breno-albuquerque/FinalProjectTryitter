using FluentAssertions;
using Tryitter.Transport;
using Xunit.Sdk;

namespace TryitterTest.Transport
{
    public class StudentRequestTest
    {
        private readonly string _email;
        private readonly string _password;
        private readonly string _fullName;

        public StudentRequestTest()
        {
            _email = "teste@teste.com";
            _password = "teste123";
            _fullName = "teste";
        }

        [Fact(DisplayName = "Deve instanciar o objeto com propriedades corretas")]
        public void ShouldInstanceObject()
        {
            //  arrange - act
            var createStudentRequest = new StudentRequest
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
            var createStudentRequest = new StudentRequest
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

        private static void AssertProperties(StudentRequest result, string email, string password, string fullName)
        {
            result.Email.Should().Be(email);
            result.Password.Should().Be(password);
            result.FullName.Should().Be(fullName);
        }
    }
}
