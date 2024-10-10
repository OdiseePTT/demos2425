namespace TreinTickets
{
    public class Rit
    {
        public string Locatie { get; private set; }
        public DateTime Datum { get; private set; }

        public Rit(string locatie, DateTime datum)
        {
            Locatie = locatie;
            Datum = datum;
        }
    }
}