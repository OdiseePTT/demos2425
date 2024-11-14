using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.Repositories
{
    public interface IWoordRepository
    {
        string GetRandomWoord();
    }
}
