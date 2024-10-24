namespace PhoneBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PhoneBookOperations phoneBookOperations = new PhoneBookOperations();

            phoneBookOperations.AddContact("Matthias", "Druwé", "123456789");
        }
    }
}