using Spectre.Console;
using System;
using System.Collections.Generic;

namespace Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = GetRandomArray(10);
            NumbersOperations no = new NumbersOperations(numbers);

            PrintRule("Start nummers");
            PrintArray(numbers);

            PrintRule("nummers hoger dan of gelijk aan 50");
            PrintArray(no.GetNumbersHigherOrEqualTo50());

            PrintRule("nummers tussen 30 en 60");
            PrintArray(no.GetNumbersBetween30And60Including());

            PrintRule("Oneven nummers");
            PrintArray(no.GetOddNumbers());

            PrintRule("nummers deelbaar door 3 en 5");
            PrintArray(no.GetMultiplesOf3And5());

            PrintRule("dubbele van de nummers");
            PrintArray(no.GetDoubles());

            PrintRule("de helft van alle oneven nummers");
            PrintArray(no.GetHalfOfOddNumbers());

            PrintRule("aantal getallen deelbaar door 5");
            AnsiConsole.WriteLine(no.CountMultiplesOf5());

            PrintRule("Het laatste nummer met een kwadraat kleiner dan 2000");
            AnsiConsole.WriteLine(no.GetLastNumberWithSquareSmallerThan2000());

            PrintRule("Som van alle getallen deelbaar door 5 of 6");
            AnsiConsole.WriteLine(no.GetSumOfNumbersDividebleBy5Or6());

            PrintArray(no.GetAllOddNumbersSortedDescending());

        }

        private static void PrintRule(string title)
        {
            AnsiConsole.Write(new Rule(title));
        }

        static int[] GetRandomArray(int arrayLength)
        {
            int[] array = new int[arrayLength];
            Random random = new Random();

            for (int i = 0; i < arrayLength; i++)
            {
                array[i] = random.Next(5000);
            }

            return array;
        }

        static void PrintArray<T>(IEnumerable<T> e)
        {
            if (e != null)
            {
                AnsiConsole.WriteLine(String.Join(",", e));
            }
            else
            {
                AnsiConsole.WriteLine();
            }
        }
    }


}
