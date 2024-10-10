using System.Collections.Generic;
using System.Linq;

namespace Car
{
    public class CarOperations
    {
        List<Car> cars;

        public CarOperations(List<Car> cars)
        {
            this.cars = cars;
        }

        //1. Een List<> met alle auto’s die minder kosten dan €10.000,00 (tip: gebruik de ToList()-methode van IEnumerable<> om een IEnumerable om te zetten naar een List<>).
        public IEnumerable<Car> GetCarsWithAPriceLessThan10000()
        {
            return null; ;
        }

        //2. Alle auto’s die minder kosten dan €15.000,00 en die ná 2016 gebouwd zijn.
        public IEnumerable<Car> GetAllCarsWithAPriceLessThan15000AndBuildAfter2016()
        {
            return cars.Where(car => car.Price < 15000 && car.ConstructionYear > 2016);
        }

        //3. Een IEnumerable<> met alle model-namen van de verschillende auto’s (tip: gebruik de methode Distinct() om duplicaten te verwijderen).
        public IEnumerable<string> GetAllUniqueModelNames()
        {
            return null;
        }

        //4. Een List<> met de model-namen van alle auto’s met een automatische transmissie.Verwijder eventuele duplicaten!
        public IEnumerable<string> GetAllUniqueModelNamesOfCarsWithAutomaticTransmission()
        {
            // Where => filter/conditie
            // Select => transformatie
            // Distinct => duplicaten verwijderen
            return cars.Where(car => car.Transmission == Transmission.AUTOMATIC).Select(car => car.Model).Distinct();
        }

        //5. Bereken de gemiddelde prijs van de auto’s met een manuele transmissie.
        public double GetAveragePriceOfCarsWithManualsTransmission()
        {
            return 0.0;
        }

        //6. De prijs van de duurste auto van het merk Ford.
        public double GetPriceOfMostExpensiveFord()
        {
            return 0.0;
        }

        //7. De drie goedkoopste auto’s met een bouwjaar ná 2016 (tip: maak gebruik van de methode Take(..) om het aantal resultaten te beperken).
        public IEnumerable<Car> Get3CheapestCarsBuildAfter2016()
        {
            return null;
        }

        //8. Het aantal auto’s met een manuele transmissie die minder kosten dan €12.500,00.
        public int GetNumberOfManualCarsThatCostLessThan12500()
        {
            return 0;
        }

        //9. Een List<> met de auto’s die een automatische transmissie hebben, gesorteerd van duur naar goedkoop.
        public List<Car> GetAutomaticCarsSortedByPriceDescending()
        {
            return null;
        }

        //10. Een lijst met de merknamen van de auto’s die meer kosten dan €12.000,00, alfabetische gesorteerd (aflopend). Vermijd dubbels!
        public IEnumerable<string> GetUniqueMakesFromCarsThatCostMoreThan12000SortAlfabeticallyDescending()
        {
            return null;
        }
    }
}
