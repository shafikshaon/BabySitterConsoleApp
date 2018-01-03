using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Babysitter
{
    class BabySitter
    {
        public List<Employer> Employers = new List<Employer>();
        public void Init()
        {
            Employers.Add(new Employer
            {
                Name = "Shafik Shaon", PhoneNumber = "01615184686", Address = "Primary School Road, Kallyanpur, Mirpur, Dhaka - 1207",
                EmergencyContact = new EmergencyContact
                {
                    Name = "Shafikur Rahman", PhoneNumber = "01705184686", Relationship = "Brother"
                },
                Children = new List<Child>
                {
                    new Child {Name = "Children1", Age = 8, SpecialHealthInformation = "None", Interest = "Video Games"},
                    new Child {Name = "Children2", Age = 10, SpecialHealthInformation = "Sometimes feeling headche", Interest = "Nothing"}
                }
            });
        }

        public void ShowAllEmployees()
        {
            var i = 1;
            foreach (var employer in Employers)
            {
                Console.WriteLine("Serial No: " + i++);
                Console.WriteLine("Name: " + employer.Name);
                Console.WriteLine("Address: " + employer.Address);
                Console.WriteLine("Phone Number: " + employer.PhoneNumber);
                Console.WriteLine("Number of children: " + employer.Children.Count);
            }
        }
    }
}
