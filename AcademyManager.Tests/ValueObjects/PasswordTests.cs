using AcademyManager.Domain.ValueObjects;

namespace AcademyManager.Tests.ValueObjects
{
    public class PasswordTests
    {
        [Fact]
        public void ShouldReturnErrorWhenPasswordIsEmpty()
        {
            // Arrange
            var password = "";

            // Act
            var result = new Password(password);

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void ShouldReturnErrorWhenPasswordIsNull()
        {
            // Arrange
            string? password = null;

            // Act
            var result = new Password(password);

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void ShouldReturnErrorWhenPasswordIsLessThan8Characters()
        {
            // Arrange
            string password = "Nova@12";

            // Act
            var result = new Password(password);

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void ShouldReturnErrorWhenPasswordDoesNotHaveUpperLetters()
        {
            // Arrange
            string password = "nova@123";

            // Act
            var result = new Password(password);

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void ShouldReturnErrorWhenPasswordDoesNotHaveLowerLetters()
        {
            // Arrange
            string password = "NOVA@123";

            // Act
            var result = new Password(password);

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void ShouldReturnErrorWhenPasswordDoesNotHaveNumbers()
        {
            // Arrange
            string password = "Nova@abc";

            // Act
            var result = new Password(password);

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void ShouldReturnErrorWhenPasswordDoesNotHaveLetters()
        {
            // Arrange
            string password = "12345678";

            // Act
            var result = new Password(password);

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void ShouldReturnSucessWhenPasswordIsValid()
        {
            // Arrange
            string password = "Nova@123";

            // Act
            var result = new Password(password);

            // Assert
            Assert.True(result.IsValid);
        }
    }
}
