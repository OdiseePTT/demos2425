using Spectre.Console;

namespace Person;
public class Program
{
    public static void Main()
    {
        PersonRepository personRepository = new PersonRepository();
        foreach (Person item in personRepository.GetAllPersons()) 
        {
            Console.WriteLine(item.FirstName);
        }
    }
}