using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Babysitter
{
    class Child : Person
    {
        public int Age { get; set; }
        public string SpecialHealthInformation { get; set; }
        public string Interest { get; set; }
    }
}
