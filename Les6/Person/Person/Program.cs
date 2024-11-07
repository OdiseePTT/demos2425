using Spectre.Console;

namespace HigherLowerGame;
public class Program
{
    public static void Main()
    {
        PersonRepository personRepository = new PersonRepository();
        personRepository.AddPerson(new Person("John", "Doe", DateTime.Today));
    }
}