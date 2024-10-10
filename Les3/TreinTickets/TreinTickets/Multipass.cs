using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreinTickets
{
    internal class Multipass
    {
        public string VanLocatie { get; private set; }
        public string NaarLocatie { get; private set; }
        public Rit[] ritten { get; private set; } = new Rit[10];

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
