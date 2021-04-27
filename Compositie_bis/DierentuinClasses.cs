using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compositie_bis
{
    class Animal
    {
        private bool leeft { get; set; } = true;
        public virtual void ToonInfo()
        {
            Console.WriteLine($"dit ding leeft = {leeft}");
        }
        public override string ToString()
        {
            string myOutputString = "";
            myOutputString += GetType();
            string[] splitted = myOutputString.Split('.');
            if(splitted.Length > 1)return splitted[1];
            else return ("huh?!");
        }
    }
    class Mammal : Animal
    {
        public virtual string pelsKleur { get; set; } = "rood";
        public override void ToonInfo()
        {
            base.ToonInfo();
            Console.WriteLine($"kleur pels = {pelsKleur}");

        }
    }
    class Reptile : Animal
    {
        public virtual int aantalSchubben { get; set; } = 120;
        public override void ToonInfo()
        {
            base.ToonInfo();
            Console.WriteLine($"aantal schubben = {aantalSchubben}");
        }

    }

    class Snake : Reptile
    {
        public override int aantalSchubben { get; set; } = 300;
        public override void ToonInfo()
        {
            base.ToonInfo();
            Console.WriteLine($"aantal schubben = {aantalSchubben}");

        }
    }
    class Iguana : Reptile
    {
        public override int aantalSchubben { get; set; } = 150;
        public override void ToonInfo()
        {
            base.ToonInfo();
            Console.WriteLine($"aantal schubben = {aantalSchubben}");
        }
    }
    class Rabbit : Mammal
    {
        public override string pelsKleur { get; set; } = "bruingrijs";
        public override void ToonInfo()
        {
            base.ToonInfo();
            Console.WriteLine($"kleur pels = {pelsKleur}");
        }
        public void talk() {
            Console.WriteLine("Snif Snif");
        }
    }
    class Cow : Mammal
    {
        public override string pelsKleur { get; set; } = "Zwartwit gevlekt";
        public override void ToonInfo()
        {
            base.ToonInfo();
            Console.WriteLine($"kleur pels = {pelsKleur}");
        }
        public void talk()
        {
            Console.WriteLine("Mooh!");
        }
    }
}
