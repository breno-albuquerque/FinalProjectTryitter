using Tryitter.Repository;
using Tryitter.Entities;

namespace TryitterTest.StudentController;

public class StudentControllerTests
{
    [Theory(DisplayName = "Cadastra um estudante e gera um token corretamente")]
    [MemberData(nameof(TestCreateStudent))]
    public void TestCreateStudent(string studentName, string email, string password, TryitterContext context)
    {
        TryitterRepository? _tryitterRepository = new(context);
        Student student = new() 
            { 
                FullName = studentName, 
                Email = email, 
                Password = password 
            };
        var token = _tryitterRepository.CreateStudent(student);

        token.Should().NotBeNull();
        Student response = context.Students.Where(s => s.Email == email).FirstOrDefault()!;
        response.Email.Should().Be(email);

        var responseFail = _tryitterRepository.CreateStudent(student);
        responseFail.Should().BeNull();

    }
}