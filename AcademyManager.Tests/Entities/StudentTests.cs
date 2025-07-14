using AcademyManager.Domain.Entities;
using AcademyManager.Domain.ValueObjects;

namespace AcademyManager.Tests.Entities
{
    public class StudentTests
    {
        private readonly Name _name;
        private readonly Cpf _cpf;
        private readonly Email _email;
        private readonly Password _password;

        public StudentTests()
        {
            _name = new Name("Lucas");
            _cpf = new Cpf("50510199003");
            _email = new Email("teste@teste.com");
            _password = new Password("Senh@123");
        }

        [Fact]
        public void ShouldReturnError_WhenEnrollmentAlreadyExists()
        {
            // Arrange
            var student = new Student(_name, new DateOnly(2000,1,1), _cpf, _email, _password);

            var enrollment1 = new Enrollment(0, 1);
            var enrollment2 = new Enrollment(0, 1);

            student.AddEnrollment(enrollment1);

            // Act
            student.AddEnrollment(enrollment2);

            // Assert
            Assert.False(student.IsValid);
        }

        [Fact]
        public void ShouldReturnSuccess_WhenEnrollmentDoesNotExist()
        {
            // Arrange
            var student = new Student(_name, new DateOnly(2000, 1, 1), _cpf, _email, _password);

            var enrollment1 = new Enrollment(0, 1);
            var enrollment2 = new Enrollment(0, 2);

            student.AddEnrollment(enrollment1);

            // Act
            student.AddEnrollment(enrollment2);

            // Assert
            Assert.True(student.IsValid);
        }
    }
}
