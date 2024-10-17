using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonAgeValidator.Tests.TestDoubles
{
    internal class TrueAgeValidatorTestDouble : IAgeValidator
    {
        public bool IsValidAge(int age)
        {
            return true;
        }
    }
}
