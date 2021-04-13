using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    class RapportModule
    {
        public double percentage = 0;
        public void PrintGraad()
        {
            if (percentage < 50 && percentage >= 0) { 
                Console.WriteLine("Niet geslaagd"); 
            }
            else if (percentage < 68)
            {
                Console.WriteLine("voldoende");
            }
            else if (percentage < 75)
            {
                Console.WriteLine("onderscheiding");
            }
            else if (percentage < 85)
            {
                Console.WriteLine("grote onderscheiding");
            }
            else if (percentage < 100)
            {
                Console.WriteLine("grootste onderscheiding");
            }
        }
    }
    class Nummers
    {

        public double Getal1;
        public double Getal2;
        public double Som()
        {
            return Getal1 + Getal2;
        }
        public double Verschil()
        {
            return Getal1 - Getal2;
        }
        public double Product()
        {
            return Getal1 * Getal2;
        }
        public double Quotient()
        {
            return Getal1 / Getal2;
        }
    }
}
