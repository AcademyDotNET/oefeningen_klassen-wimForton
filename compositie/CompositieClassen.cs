using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compositie
{
    class Car {
        //Wheel[] myWielen = new Wheel[];
        List<Wheel> myWielen = new List<Wheel>();
        public Engine myEngine;
        public Car(int inAantalWielen, int inAantalCylinders)
        {
            for (int i = 0; i < inAantalWielen; i++)
            {
                myWielen.Add(new Wheel());
            }
            myEngine = new Engine(inAantalCylinders);
        }
        
    }
    class Boat
    {
        //public Engine myEngine;
        public List<Engine> myEngines = new List<Engine>();
        public List<Propeller> myPropellers = new List<Propeller>();
        public Boat(int inAantalCylinders, int inAantalPropellers)
        {
            if (inAantalPropellers > 4) {
                Console.WriteLine("Boat too expensive");
                inAantalPropellers = 4;
            }
            for (int i = 0; i < inAantalPropellers; i++)
            {
                myPropellers.Add(new Propeller());
                myEngines.Add(new Engine(inAantalCylinders));
            }
        }
    }
    class Engine
    {
        public List<Piston> myPistons = new List<Piston>();
        public List<Crankshaft> myCrankshafts = new List<Crankshaft>();

        public Engine(int inAantalCylinders)
        {
            for (int i = 0; i < inAantalCylinders; i++)
            {
                myPistons.Add(new Piston());
            }
            for (int i = 0; i < inAantalCylinders; i++)
            {
                myCrankshafts.Add(new Crankshaft());
            }
        }
    }
    class Wheel
    {
        public void Turn()
        {
            Console.WriteLine("Screech!");
        }
    }
    class Crankshaft
    {
        public void Turn()
        {
            Console.WriteLine("Clanc!");
        }
    }
    class Piston
    {
        public void Turn()
        {
            Console.WriteLine("Bang!");
        }
    }
    class Propeller
    {
        public void Turn(){
            Console.WriteLine("Blub!");
        }
    }
}
