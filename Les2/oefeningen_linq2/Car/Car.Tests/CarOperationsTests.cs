namespace Car.Tests
{
    internal class CarOperationsTests
    {
        [Test]
        public void GetAllCarsWithAPriceLessThan15000AndBuildAfter2016_With2CarsWithPriceBelow15000AndBuildAfter2016_ReturnsThe2Cars()
        {

            // Arrange
            List<Car> cars = new List<Car>()
            {
                new Car("VW", "Golf", 2017, 17495, Transmission.MANUAL), // Prijs hoger dan 150000 en na 2016
                new Car("VW", "Polo", 2020, 9850, Transmission.AUTOMATIC),// Prijs lager dan 150000 en na 2016 V
                new Car("Opel", "Astra", 2016, 11450, Transmission.AUTOMATIC),  // Prijs lager dan 150000 en in 2016
                new Car("VW", "Golf", 2015, 18320, Transmission.AUTOMATIC), // Prijs hoger dan 150000 en voor 2016
                new Car("Ford", "Focus", 2016, 8715, Transmission.MANUAL), // Prijs lager dan 150000 en in 2016
                new Car("Opel", "Corsa", 2017, 9120, Transmission.MANUAL), // Prijs lager dan 150000 en na 2016 V
                new Car("Ford", "Fiësta", 2015, 7890, Transmission.AUTOMATIC) // Prijs lager dan 150000 en voor 2016
            };

            CarOperations sut = new CarOperations(cars);

            List<Car> expectedResult = new List<Car>()
            {
                new Car("VW", "Polo", 2020, 9850, Transmission.AUTOMATIC),// Prijs lager dan 150000 en na 2016 V
                new Car("Opel", "Corsa", 2017, 9120, Transmission.MANUAL), // Prijs lager dan 150000 en na 2016 V
            };

            // Act
            IEnumerable<Car> actualResult = sut.GetAllCarsWithAPriceLessThan15000AndBuildAfter2016();

            // Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult).UsingPropertiesComparer());
        }

        [Test]
        public void GetAllUniqueModelNamesOfCarsWithAutomaticTransmission_With2ModelsHavingAutomaticTransmissionAnd1DuplicateModel_Returns2Models()
        {
            // Arrange
            List<Car> cars = new List<Car>()
            {
                new Car("VW", "Golf", 2017, 17495, Transmission.MANUAL), 
                new Car("VW", "Polo", 2020, 9850, Transmission.AUTOMATIC),
                new Car("Opel", "Astra", 2016, 11450, Transmission.AUTOMATIC),  
                new Car("VW", "Golf", 2015, 18320, Transmission.MANUAL),
                new Car("Ford", "Focus", 2016, 8715, Transmission.MANUAL),
                new Car("Opel", "Corsa", 2017, 9120, Transmission.MANUAL),
                new Car("VW", "Polo", 2015, 7890, Transmission.AUTOMATIC) 
            };

            CarOperations sut = new CarOperations(cars);

            IEnumerable<string> expectedResult = new List<string>() { "Polo", "Astra" };

            // Act
            IEnumerable<string> result = sut.GetAllUniqueModelNamesOfCarsWithAutomaticTransmission();

            // Assert
            Assert.That(result, Is.EquivalentTo(expectedResult));

        }
    }
}
