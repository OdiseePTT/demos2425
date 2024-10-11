namespace TreinTickets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Conducteur conducteur = new Conducteur(["Brussel-Zuid", "Brussel-Centraal", "Brussel-Noord"]);

            EnkelTicket enkel = new EnkelTicket(DateTime.Today, "Brussel-Zuid", "Brussel-Noord", "12345");
            Multipass multi = new Multipass("Brussel-Noord", "Brussel-Centraal", "1234");
            multi.VoegRitToe("Brussel-Centraal");

            Abonnement abonnement = new Abonnement(DateTime.Today.AddDays(-100), DateTime.Today.AddDays(100), "Gent", "Brugge", "123456");

            Console.WriteLine(conducteur.CheckKaart(enkel));
            Console.WriteLine(conducteur.CheckKaart(multi));
            Console.WriteLine(conducteur.CheckKaart(abonnement));

        }
    }
}
