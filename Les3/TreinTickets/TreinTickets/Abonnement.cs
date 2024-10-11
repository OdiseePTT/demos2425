using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TreinTickets
{
    internal class Abonnement: IKaart
    {
        public Abonnement(DateTime geldigVan, DateTime geldigTot, string vanLocatie, string naarLocatie, string id)
        {
            GeldigVan = geldigVan;
            GeldigTot = geldigTot;
            VanLocatie = vanLocatie;
            NaarLocatie = naarLocatie;
            Id = id;
        }

        public DateTime GeldigVan { get; private set; }
        public DateTime GeldigTot { get; private set; }
        public string VanLocatie { get; private set; }
        public string NaarLocatie { get; private set; }

        public string Id { get; private set; }

        public bool ControleerGeldigheid(string[] route)
        {
            return route.Contains(VanLocatie) &&
               route.Contains(NaarLocatie) &&
               GeldigVan <= DateTime.Today &&
               GeldigTot >= DateTime.Today;
        }
    }
}
