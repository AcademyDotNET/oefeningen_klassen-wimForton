using System;

namespace Compositie_bis
{
    class CompProgram
    {
        static void Main(string[] args)
        {
            //PlayMoederbord();
            //PlaySnake();
            PlayHuis();
        }

        private static void PlayHuis()
        {
            Huis myHouse = new Huis();
            myHouse.VoegKamerToe("Badkamer", 10);
            myHouse.VoegKamerToe("Gang", 15);
            myHouse.VoegKamerToe("Salon", 15, true);
            myHouse.VoegKamerToe("Salon", 3, false);
            myHouse.VoegKamerToe("Salon", 6, false);
            myHouse.VoegKamerToe("Salon", 4, false);
            Console.WriteLine(myHouse.BerekenPrijs());
        }

        private static void PlaySnake()
        {
            Snake adder = new Snake();
            Cow Koe = new Cow();
            if (adder is Reptile) Console.WriteLine("ik ben reptiel");
            if (adder is Animal) Console.WriteLine("ik ben ook een dier");
            if (adder is Snake) Console.WriteLine("ik ben ook een slang");
            Console.WriteLine(adder);
            Console.WriteLine(Koe);
            if (adder.ToString() == "Snake") { Console.WriteLine("I am a Snake"); }
        }
        private static void PlayMoederbord()
        {
            Moederbord Z390E_GAMING = new Moederbord();
            Z390E_GAMING.myVideoKaart = new VideoKaart("GeForceRTX2080");
            Z390E_GAMING.CPU = new Cpu("IntelCorei9_9900K");
            Z390E_GAMING.AddRam(new RamGeheugen("Corsair"));
            Z390E_GAMING.AddRam(new RamGeheugen("Kingston"));
            Console.WriteLine(Z390E_GAMING);
        }
    }
}
