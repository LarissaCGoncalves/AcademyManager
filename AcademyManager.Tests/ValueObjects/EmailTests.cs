using AcademyManager.Domain.ValueObjects;

namespace AcademyManager.Tests.ValueObjects
{
    public class EmailTests
    {
        [Fact]
        public void ShouldReturnErrorWhenEmailIsEmpty()
        {
            // Arrange
            var email = "";

            // Act
            var result = new Email(email);

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void ShouldReturnErrorWhenEmailIsNull()
        {
            // Arrange
            string? email = null;

            // Act
            var result = new Email(email);

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void ShouldReturnErrorWhenEmailIsInvalid()
        {
            // Arrange
            var email = "gmail";

            // Act
            var result = new Email(email);

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void ShouldReturnSucessEmailWhenEmailIsValid()
        {
            // Arrange
            var email = "teste@teste.com";

            // Act
            var result = new Email(email);

            // Assert
            Assert.True(result.IsValid);
        }
    }
}
