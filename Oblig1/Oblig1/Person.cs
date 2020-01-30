using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblig1
{
    class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int BirthYear { get; set; }
        public Person Father { get; set; }
        public Person Mother { get; set; }

        public void Show() 
        {
            if (FirstName != null)
            {
                Console.WriteLine("Firstname: " + FirstName);
            }
            if (LastName != null)
            {
                Console.WriteLine("Lastname: " + LastName);
            }
            if (BirthYear != 0) 
            {
            Console.WriteLine("Birthyear: " + BirthYear);
            }
            if (Mother != null)
            {
                Console.WriteLine("Mother: " + Mother.FirstName);
            } 
            if (Father != null)
            {
                Console.WriteLine("Father: " + Father.FirstName);
            }
            if (Id != 0)
            {
                Console.WriteLine("Id: " + Id);
            }
        }
    }
}
