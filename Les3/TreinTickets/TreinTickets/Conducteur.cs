namespace TreinTickets
{
    internal class Conducteur
    {
        private string[] route;

        public Conducteur(string[] route)
        {
            this.route = route;
        }

        public bool CheckKaart(IKaart kaart)
        {
            return kaart.ControleerGeldigheid(route);
        }
    }
}
