namespace TreinTickets
{
    internal class Conducteur
    {
        private string[] route;

        public Conducteur(string[] route)
        {
            this.route = route;
        }

        public bool CheckTicket(EnkelTicket ticket)
        {
            return ticket.Datum == DateTime.Today && route.Contains(ticket.VanLocatie) && route.Contains(ticket.NaarLocatie);
        }

        public bool CheckTicket(Multipass ticket)
        {
            Rit laatsteRit = ticket.ritten.Last(rit => rit != null);

            return laatsteRit.Datum == DateTime.Today &&
                route.Contains(ticket.VanLocatie) &&
                route.Contains(ticket.NaarLocatie) &&
                (laatsteRit.Locatie == ticket.NaarLocatie || 
                laatsteRit.Locatie == ticket.VanLocatie);
        }


        public bool CheckTicket(Abonnement ticket)
        {
            return route.Contains(ticket.VanLocatie) &&
                route.Contains(ticket.NaarLocatie) && 
                ticket.GeldigVan <= DateTime.Today && 
                ticket.GeldigTot >= DateTime.Today;
        }



    }
}
