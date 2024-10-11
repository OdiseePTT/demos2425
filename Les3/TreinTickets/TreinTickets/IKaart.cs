using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreinTickets
{
    internal interface IKaart
    {
        //string Id { get; }
        bool ControleerGeldigheid(string[] route);
    }
}
