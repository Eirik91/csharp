using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondDegreeCalc
{
    class Program
    {   
        //Metode for å gjøre koden ryddigere og man slipper å gjenta NotValid teksten for hver gang.
        private const string NotValid = "Ikke gyldig verdi. Du må skrive ett tall!";

        static void Main(string[] args)
        {
            Console.WriteLine("Her må du føre inn en likning tall for tall av formen : ax^2+bx+c");
            Console.Write("Skriv inn en verdi for a: ");
            
            // Tar in userinput, sjekker om det er ett tall eller -, hvis ikke blir det printet ut ikke gyldig verdi og
            //går ut av main som avslutter programmet. konverter så til tall.
            string a1 = Console.ReadLine();
            if (!StringIsNumber(a1)) {
                Console.WriteLine(NotValid);
                return;
            }
            double a = double.Parse(a1);
            
            Console.Write("Skriv inn en verdi for b: ");
            string b1 = Console.ReadLine();
            if (!StringIsNumber(b1))
            {
                Console.WriteLine(NotValid);
                return;
            }
            double b = double.Parse(b1);

            Console.Write("Skriv inn en verdi for c: ");
            string c1 = Console.ReadLine();
            if (!StringIsNumber(c1))
            {
                Console.WriteLine(NotValid);
                return;
            }
            double c = double.Parse(c1);
           
            quadratic(a,b,c);
           }
        public static void quadratic(double a, double b, double c) {
           //Tar kvadratroten av formelen b^2 -4*a*c
            double root = Math.Sqrt(b * b - 4 * a * c);

        

            if (root >= 0)
            {
                //tar -b +/- kvadratroten og deler på 2*a. Printer så ut de to svarene. oppgir også hele likningen.
                double x1 = (-b + root) / (2 * a);
                double x2 = (-b - root) / (2 * a);
                Console.WriteLine($"{a}x^2+{b}x+{c}=0 Har to løsninger: ");
                Console.WriteLine("x1= " + x1);
                Console.WriteLine("x2= " + x2);
            }
            else
            {
                Console.WriteLine("Ingen gyldig løsning på likningen");
            }
            }
            private static bool StringIsNumber(string s)
            {
                //sjekker om string er number eller -. Continue hvis det er - så du fortsetter i loopen, return dersom du har funnet at det er ett tall.
                // hvis ikke noe slår til return true.
                foreach (char c in s)
                {
                if (c == '-')
                {
                    continue;
                }
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
                return true;
        }
    }
}
