using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Babysitter
{
    enum MenuOperationChoice
    {
        ShowAllEmployers = 1,
        AddEmployerAndEmergencyContactWithChild = 2,
        AddChild = 3,
        RemoveEmployer = 4,
        RemoveChild = 5,
        EmployerDetails = 6
    }
    class BabySitter
    {
        public List<Employer> Employers = new List<Employer>();

        public string MenuPrompt = @"
------------------------Menu Operation------------------------
1. Show All Employers 
2. Add Employer and Emergency Contact With Child
3. Add Child
4. Remove Employer
5. Remove Child
6. Show an Employer Details";
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
            Console.WriteLine("======All Employers=====");
            foreach (var employer in Employers)
            {
                Console.WriteLine("Serial No: " + i++);
                Console.WriteLine("Name: " + employer.Name);
                Console.WriteLine("Address: " + employer.Address);
                Console.WriteLine("Phone Number: " + employer.PhoneNumber);
                Console.WriteLine("Number of children: " + employer.Children.Count);
            }
        }

        public void Start()
        {
            while (true)
            {
                Console.WriteLine(MenuPrompt);
                var choice = TakeUserInput("Enter your choice", "Wong choice! Try again");
                switch (choice)
                {
                    case (int) MenuOperationChoice.ShowAllEmployers:
                        ShowAllEmployees();
                        continue;
                    case (int) MenuOperationChoice.AddEmployerAndEmergencyContactWithChild:
                        AddEmployerAndEmergencyContactWithChild();
                        continue;
                    case (int) MenuOperationChoice.AddChild:
                        ShowAllEmployees();
                        AddChild();
                        continue;
                    case (int) MenuOperationChoice.RemoveEmployer:
                        ShowAllEmployees();
                        RemoveEmployer();
                        continue;
                    case (int) MenuOperationChoice.RemoveChild:
                        ShowAllEmployees();
                        RemoveChild();
                        continue;
                    case (int) MenuOperationChoice.EmployerDetails:
                        ShowAllEmployees();
                        EmployerDetails();
                        continue;
                    default:
                        Console.WriteLine("Wrong choice! Please select right choice");
                        continue;
                }
            }
        }

        private void EmployerDetails()
        {
            var employerId = TakeUserInput("Select employer to see details", "Wrong choice! Please try again");
            var i = 1;
            Console.WriteLine("\n---Employer---");
            Console.WriteLine("Name: " + Employers[employerId - 1].Name);
            Console.WriteLine("Address: " + Employers[employerId - 1].Address);
            Console.WriteLine("Phone Number: " + Employers[employerId - 1].PhoneNumber);
            Console.WriteLine("\n---Emergency Contact---");
            Console.WriteLine("Name: " + Employers[employerId - 1].EmergencyContact.Name);
            Console.WriteLine("Relationship: " + Employers[employerId - 1].EmergencyContact.Relationship);
            Console.WriteLine("Phone Number: " + Employers[employerId - 1].EmergencyContact.PhoneNumber);
            Console.WriteLine("\nChildren(s)");
            foreach (var child in Employers[employerId - 1].Children)
            {
                Console.WriteLine(i++ + " " + child.Name + "\t" + child.Age + "\t" + child.SpecialHealthInformation + "\t" +
                                  child.Interest);
            }
            Console.WriteLine("=============================================================================================================");
        }

        private void RemoveChild()
        {
            var employerId = TakeUserInput("Select employer to remove child", "Wrong choice! Please try again");
            var i = 1;
            Console.WriteLine("---------Child List-----------");
            foreach (var child in Employers[employerId-1].Children)
            {
                Console.WriteLine(i++ + child.Name + "\t" + child.Age + "\t" + child.SpecialHealthInformation + "\t" +
                                  child.Interest);
            }
            var childId = TakeUserInput("Select child to remove", "Wrong choice! Please try again");
            Employers[employerId - 1].Children.RemoveAt(childId - 1);
            Console.WriteLine("Child deleted successfully");
        }

        private void RemoveEmployer()
        {
            var employerId = TakeUserInput("Select employer to remove", "Wrong choice! Please try again");
            Employers.RemoveAt(employerId - 1);
            Console.WriteLine("Employer deleted successfully");
        }

        private void AddChild()
        {
            var employerId = TakeUserInput("Select employer to add child", "Wrong choice! Please try again");
            Console.WriteLine("Enter child name");
            var employerChildName = Console.ReadLine();
            var employerAge = TakeUserInput("Enter child age", "Wrong input! Try again");
            Console.WriteLine("Enter child special health information");
            var employerChildEmployerHealthInformation = Console.ReadLine();
            Console.WriteLine("Enter child interest");
            var employerChildInterest = Console.ReadLine();
            Employers[employerId - 1].Children.Add(new Child { Name = employerChildName, Age = employerAge, SpecialHealthInformation = employerChildEmployerHealthInformation, Interest = employerChildInterest });
            Console.WriteLine("Child added successfully");
        }

        private void AddEmployerAndEmergencyContactWithChild()
        {
            Console.WriteLine("Enter employer name");
            var employerName = Console.ReadLine();
            Console.WriteLine("Enter employer address");
            var employerAddress= Console.ReadLine();
            Console.WriteLine("Enter employer phone number");
            var employerPhoneNumber = Console.ReadLine();
            Console.WriteLine("Enter emergency contact person name");
            var emergencyContactPersonName = Console.ReadLine();
            Console.WriteLine("Enter emergency contact person phone number");
            var emergencyContactPersonPhoneNumber = Console.ReadLine();
            Console.WriteLine("Enter relationship with employer");
            var relationshipWithEmployer = Console.ReadLine();
            Console.WriteLine("Enter child name");
            var employerChildName = Console.ReadLine();
            var employerAge = TakeUserInput("Enter child age", "Wrong input! Try again");
            Console.WriteLine("Enter child special health information");
            var employerChildEmployerHealthInformation = Console.ReadLine();
            Console.WriteLine("Enter child interest");
            var employerChildInterest = Console.ReadLine();

            Employers.Add(new Employer
            {
                Name = employerName, Address = employerAddress, PhoneNumber = employerPhoneNumber,
                EmergencyContact = new EmergencyContact
                {
                    Name = emergencyContactPersonName, PhoneNumber = emergencyContactPersonPhoneNumber, Relationship = relationshipWithEmployer
                },
                Children = new List<Child>
                {
                    new Child
                    {
                        Name = employerChildName, Age = employerAge, SpecialHealthInformation = employerChildEmployerHealthInformation, Interest = employerChildInterest
                    }
                }
            });
        }

        private int TakeUserInput(string inputPrompt, string errorMessage)
        {
            Console.WriteLine(inputPrompt);
            var input = Console.ReadLine();
            try
            {
                return Convert.ToInt32(input);
            }
            catch (Exception)
            {
                Console.WriteLine(errorMessage);
                return TakeUserInput(inputPrompt, errorMessage);
            }
        }
    }
}
