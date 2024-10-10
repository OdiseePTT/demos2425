using System.Collections.Generic;
using System.Linq;

namespace Numbers
{
    public class NumbersOperations
    {

        int[] numbers;

        public NumbersOperations(int[] numbers)
        {
            this.numbers = numbers;

        }

        // 1. De getalen die groter of gelijk zijn aan 50
        public IEnumerable<int> GetNumbersHigherOrEqualTo50()
        {
            return numbers.Where(number => number >=50);
        }

        // 2. De getallen tussen 30 en 60 (beide grenzen inbegrepen)
        public IEnumerable<int> GetNumbersBetween30And60Including()
        {
            return numbers.Where(x=>x>=30 && x<=60);
        }

        // 3. Alle oneven getallen
        public IEnumerable<int> GetOddNumbers()
        {
            return null;
        }

        // 4. De getallen die zowel een veelvoud zijn van 3 als van 5
        public IEnumerable<int> GetMultiplesOf3And5()
        {
            return null;
        }

        // 5. Een IEnumerable<> waarbij elk getal vervangen werd door het dubbele van het oorspronkelijke getal
        public IEnumerable<int> GetDoubles()
        {
            // (parameter1 , parameter2) => {return parameter1+ parameter2;}
            // return numbers.Select((number)=> { return number * 2; });
            return numbers.Select(number => number * 2);
        }

        // 6. Een IEnumerable<> waarbij elk oneven getal vervangen werd door de helft van het oorspronkelijke getal
        public IEnumerable<double> GetHalfOfOddNumbers()
        {
            return null;
        }

        // 7. Het aantal getallen die een veelvoud zijn van 5 (tip: maak hiervoor uitsluitend gebruik van de Count(..)-methode!)
        public int CountMultiplesOf5()
        {
            return 0;
        }

        // 8. Het laatste getal in de array waarvan het kwadraat kleiner is dan 2000 (Tip: maak hiervoor uitsluitend gebruik van de methode Last(..)!
        public int GetLastNumberWithSquareSmallerThan2000()
        {
            return numbers.LastOrDefault(number => number * number < 2000, 0);
        }

        // 9. De som van alle getallen die deelbaar zijn door 5 of 6.
        public int GetSumOfNumbersDividebleBy5Or6()
        {
            return 0;
        }

        // 10. Alle oneven getallen in de array, gesorteerd van groot naar klein
        public IEnumerable<int> GetAllOddNumbersSortedDescending()
        {
            return null;
        }
    }
}
