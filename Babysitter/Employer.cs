using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Babysitter
{
    class Employer : AdultPerson
    {
        public string Address { get; set; }
        public EmergencyContact EmergencyContact;
        public List<Child> Children;

        public Employer()
        {
            Children = new List<Child>();
        }
    }
}
