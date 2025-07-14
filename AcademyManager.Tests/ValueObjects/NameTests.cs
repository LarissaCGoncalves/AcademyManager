using AcademyManager.Domain.ValueObjects;

namespace AcademyManager.Tests.ValueObjects
{
    public class NameTests
    {
        [Fact]
        public void ShouldReturnErrorWhenNameIsEmpty()
        {
            // Arrange
            var name = "";

            // Act
            var result = new Name(name);

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void ShouldReturnErrorWhenNameIsNull()
        {
            // Arrange
            string? name = null;

            // Act
            var result = new Name(name);

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void ShouldReturnErrorWhenNameIsLessThan3Characters()
        {
            // Arrange
            var name = "ab";

            // Act
            var result = new Name(name);

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void ShouldReturnSucessWhenNameIsValid()
        {
            // Arrange
            var name = "nome válido";

            // Act
            var result = new Name(name);

            // Assert
            Assert.True(result.IsValid);
        }
    }
}
