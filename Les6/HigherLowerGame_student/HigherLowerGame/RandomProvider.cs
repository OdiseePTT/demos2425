using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigherLowerGame
{
    public interface IRandom
    {
        int Next(int value);
    }

    internal class RandomProvider : IRandom
    {
        public int Next(int value)
        {
            return new Random().Next(value);
        }
    }
}
