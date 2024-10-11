using Spectre.Console;
using System.Linq;
using System.Xml;

namespace Car
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = GetListOfCars();

            cars.Sort();
            MyList list = new MyList();

            list.Where(x => x>10);

            CarOperations carOps = new CarOperations(cars);

            PrintRule("Alle auto's");
            PrintList(cars);

            PrintRule("Auto's met een prijs lager dan 10000");
            PrintList(carOps.GetCarsWithAPriceLessThan10000());

            PrintRule("Auto's met een prijs lager dan 15000 en gebouwd na 2016");
            PrintList(carOps.GetAllCarsWithAPriceLessThan15000AndBuildAfter2016());

            PrintRule("Alle unieke modelnamen");
            PrintList(carOps.GetAllUniqueModelNames());

            PrintRule("Alle unieke modelnamen van auto's met automatische transmissie");
            PrintList(carOps.GetAllUniqueModelNamesOfCarsWithAutomaticTransmission());

            PrintRule("Gemiddelde prijs van alle auto's met manuele transmissie");
            AnsiConsole.WriteLine(carOps.GetAveragePriceOfCarsWithManualsTransmission());

            PrintRule("Prijs van de duurste ford"); 
            AnsiConsole.WriteLine(carOps.GetPriceOfMostExpensiveFord());

            PrintRule("3 goedkoopste wagens, gebouwd na 2016");
            PrintList(carOps.Get3CheapestCarsBuildAfter2016());

            PrintRule("aantal auto's met manuale transmissie en een kost lager dan 12500");
            AnsiConsole.WriteLine(carOps.GetNumberOfManualCarsThatCostLessThan12500());

            PrintRule("Alle autimatische wagens gesorteerd volgens prijs aflopend");
            PrintList(carOps.GetAutomaticCarsSortedByPriceDescending());

            PrintRule("Alle unieke merken van auto's die meer kosten dan 12000 omgekeerd alfabetisch gesorteerd ");
            PrintList(carOps.GetUniqueMakesFromCarsThatCostMoreThan12000SortAlfabeticallyDescending());
        }

        private static void PrintRule(string title)
        {
            AnsiConsole.Write(new Rule(title));
        }

        private static void PrintList<T>(IEnumerable<T> items)
        {
            if (items == null)
            {
                AnsiConsole.WriteLine();
                return;
            }
            else
            {
                foreach (T item in items)
                {
                    AnsiConsole.WriteLine(item.ToString());
                }

            }
        }

        private static List<Car> GetListOfCars()
        {
            return new List<Car> {
                new Car("VW", "Golf", 2017, 17495, Transmission.MANUAL),
                new Car("VW", "Polo", 2015, 9850, Transmission.AUTOMATIC),
                new Car("Opel", "Astra", 2016, 11450, Transmission.AUTOMATIC),
                new Car("VW", "Golf", 2018, 18320, Transmission.AUTOMATIC),
                new Car("Ford", "Focus", 2016, 8715, Transmission.MANUAL),
                new Car("Opel", "Corsa", 2017, 9120, Transmission.MANUAL),
                new Car("Ford", "Fiësta", 2016, 7890, Transmission.AUTOMATIC)
            };
        }
    }
}
