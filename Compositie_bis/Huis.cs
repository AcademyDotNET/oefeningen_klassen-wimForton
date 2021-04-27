using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compositie_bis
{
    class Huis
    {
        private Kamer[] kamers = new Kamer[5];
        private int aantalKamers = 0;
        public Huis()
        {

        }
        public void VoegKamerToe(string inType, double inOppervlakte, bool inSchouw = false)
        {
            if(aantalKamers < kamers.Length)
            {
                switch (inType)
                {
                    case "Badkamer":
                        kamers[aantalKamers] = new Badkamer(inOppervlakte);
                        break;
                    case "Salon":
                        kamers[aantalKamers] = new Salon(inOppervlakte, inSchouw);
                        break;
                    case "Gang":
                        kamers[aantalKamers] = new Gang(inOppervlakte);
                        break;
                    default:
                        Console.WriteLine("Wrong Type");
                        break;
                }
            }
            else
            {
                Console.WriteLine($"Max rooms is {kamers.Length}");
            }
            aantalKamers++;
        }
        public double BerekenPrijs()
        {
            double myPrijs = 0;
            foreach (var item in kamers)
            {
                if(item != null) myPrijs += item.Prijs;
            }
            return myPrijs;
        }
    }
    class Kamer
    {
        public virtual double oppervlakte { get; set; } = 5;
        public virtual bool schouw { get; set; } = false;
        private double prijs;
        public double Prijs
        {
            get { return prijs; }
            set { prijs = value; }
        }
    }
    class Badkamer : Kamer
    {
        public Badkamer(double inOppervlakte)
        {
            Prijs = 500;
        }
    }
    class Salon : Kamer
    {
        public Salon(double inOppervlakte, bool inSchouw)
        {
            if (inSchouw) Prijs = 500;
            else Prijs = 300;
        }
    }
    class Gang : Kamer
    {
        public Gang(double inOppervlakte)
        {
            Prijs = oppervlakte * 10;
        }
    }
}
