namespace PhoneBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PhoneBookOperations phoneBookOperations = new PhoneBookOperations();

           // phoneBookOperations.AddContact("John", "Druwé", "123451788");

            Contact c = phoneBookOperations.Contacts.Last();
            phoneBookOperations.AddQuickDial(c, 2);

            Console.WriteLine(phoneBookOperations.QuickDials);

            foreach (var Contact in phoneBookOperations.QuickDials)
            {
                if (Contact != null)
                {
                     Console.WriteLine(Contact.FirstName);
                }
                {
                    Console.WriteLine("Leeg slot");
                }
            }
        }
    }
}