﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yahtzee
{
    public interface IRandomProvider
    {
        int Next(int minvalue, int maxvalue);
    }

    internal class RandomProvider : IRandomProvider
    {
        public int Next(int minvalue, int maxvalue)
        {
            return new Random().Next(minvalue, maxvalue);
        }
    }
}
