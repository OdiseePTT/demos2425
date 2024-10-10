using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreinTickets
{
    internal class Abonnement
    {
        public Abonnement(DateTime geldigVan, DateTime geldigTot, string vanLocatie, string naarLocatie)
        {
            GeldigVan = geldigVan;
            GeldigTot = geldigTot;
            VanLocatie = vanLocatie;
            NaarLocatie = naarLocatie;
        }

        public DateTime GeldigVan { get; private set; }
        public DateTime GeldigTot { get; private set; }
        public string VanLocatie { get; private set; }
        public string NaarLocatie { get; private set; }
    }
}
