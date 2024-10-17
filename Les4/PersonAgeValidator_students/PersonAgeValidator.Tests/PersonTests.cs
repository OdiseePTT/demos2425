using PersonAgeValidator.Tests.TestDoubles;

namespace PersonAgeValidator.Tests
{
    internal class PersonTests
    {
        [Test]
        public void Ctor_WithValidAge_ReturnsPersonObject()
        {
            // Arrange
            string firstname = "John";
            string lastname = "Doe";
            int age = 19;

            // Act
            Person result = new Person(firstname, lastname, age, new TrueAgeValidatorTestDouble());

            // Assert
            Assert.That(result.FirstName, Is.EqualTo("John"));
            Assert.That(result.LastName, Is.EqualTo("Doe"));
            Assert.That(result.Age, Is.EqualTo(19));
        }

        [Test]
        public void Ctor_WithInValidAge_ThrowsException()
        {

            // Arrange
            string firstname = "John";
            string lastname = "Doe";
            int age = 90;

            // Act
            Action act =  () => new Person(firstname, lastname, age, new FalseAgeValidatorTestDouble());

            // Assert
            Assert.That(act, Throws.TypeOf<Exception>().With.Message.EqualTo("age invalid"));

        }
    }
}
