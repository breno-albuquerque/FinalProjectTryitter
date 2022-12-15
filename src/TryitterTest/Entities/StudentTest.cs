using Tryitter.Entities;

namespace TryitterTest.Entities
{
    public class StudentTest
    {
        private readonly int _studentId = 1;
        private readonly string _email = "test@email.com";
        private readonly string _password = "test-password";
        private readonly string _fullName = "test-name";

        [Fact(DisplayName = "Deve instanciar a entidade")]
        public void shouldInstanceEntity()
        {
            var student = new Student
            {
                StudentId = _studentId,
                Email = _email,
                Password = _password,
                FullName = _fullName
            };

            student.StudentId.Should().Be(_studentId);
            student.Email.Should().Be(_email);
            student.Password.Should().Be(_password);
            student.FullName.Should().Be(_fullName);
        }
    }
}