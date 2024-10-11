using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TreinTickets
{
    internal class EnkelTicket : IKaart
    {
        public EnkelTicket(DateTime datum, string vanLocatie, string naarLocatie, String id)
        {
            Datum = datum;
            VanLocatie = vanLocatie;
            NaarLocatie = naarLocatie;
        }

        public DateTime Datum { get; private set; }
        public string VanLocatie { get; private set; }
        public string NaarLocatie { get; private set; }

        public string Id {get; private set;}

        public bool ControleerGeldigheid(string[] route)
        {
            return Datum == DateTime.Today && route.Contains(VanLocatie) && route.Contains(NaarLocatie);
        }
    }
}
