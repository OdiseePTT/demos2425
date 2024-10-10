namespace TreinTickets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IKaart kaart = new EnkelTicket(DateTime.Today,"Brussel", "Leuven", "12345");
            EnkelTicket enkelTicket = new EnkelTicket(DateTime.Today, "Brussel", "Leuven", "12345");


            Console.WriteLine("demo");


        }
    }
}
