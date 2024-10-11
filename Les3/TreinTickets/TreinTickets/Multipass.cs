using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TreinTickets
{
    internal class Multipass: IKaart
    {
        public Multipass(string vanLocatie, string naarLocatie, string id)
        {
            VanLocatie = vanLocatie;
            NaarLocatie = naarLocatie;
            Id = id;
        }

        public string VanLocatie { get; private set; }
        public string NaarLocatie { get; private set; }
        public Rit[] ritten { get; private set; } = new Rit[10];

        public string Id { get; private set; }

        public bool ControleerGeldigheid(string[] route)
        {
            Rit laatsteRit = ritten.Last(rit => rit != null);

            return laatsteRit.Datum == DateTime.Today &&
                route.Contains(VanLocatie) &&
                route.Contains(NaarLocatie) &&
                (laatsteRit.Locatie == NaarLocatie ||
                laatsteRit.Locatie == VanLocatie);
        }

        public bool VoegRitToe(string locatie)
        {
            int index = 0;
            if(ritten.Last()!= null)
            {
                return false;
            }

            while (ritten[index] != null)
            {
                index++;
            }

            ritten[index] = new Rit(locatie, DateTime.Today);
            return true;
        }
    }
}
