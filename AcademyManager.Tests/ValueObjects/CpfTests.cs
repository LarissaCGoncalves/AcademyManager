using AcademyManager.Domain.ValueObjects;

namespace AcademyManager.Tests.ValueObjects
{
    public class CpfTests
    {
        [Fact]
        public void ShouldReturnErrorWhenCpfIsEmpty()
        {
            // Arrange
            var cpf = "";

            // Act
            var result = new Cpf(cpf);

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void ShouldReturnErrorWhenCpfIsNull()
        {
            // Arrange
            string? cpf = null;

            // Act
            var result = new Cpf(cpf);

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void ShouldReturnErrorWhenCpfIsInvalid()
        {
            // Arrange
            var cpf = "111.111.111-11";

            // Act
            var result = new Cpf(cpf);

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void ShouldReturnSucessCpfWhenCpfIsValid()
        {
            // Arrange
            var cpf = "177.331.680-07";

            // Act
            var result = new Cpf(cpf);

            // Assert
            Assert.True(result.IsValid);
        }
    }
}
