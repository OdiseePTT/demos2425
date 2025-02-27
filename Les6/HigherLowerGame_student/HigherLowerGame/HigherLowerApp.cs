﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigherLowerGame
{

    public enum Result
    {
        Correct, Lower, Higher
    }

    public class HigherLowerApp
    {
        int _number;
        public int NumberOfGuesses { get; private set; } = 0;

        IRandom _random; 
        internal HigherLowerApp(int max):this(new RandomProvider(),max)
        {
        }

        public HigherLowerApp(IRandom random, int max)
        {
            _random = random;
            _number = _random.Next(max);
        }

        public Result GuessNumber(int guess)
        {
            NumberOfGuesses++;

            if( _number == guess)
            {
                return Result.Correct;
            }

            if (_number < guess)
            {
                return Result.Lower;
            }

            return Result.Higher;
        }
    }
}
