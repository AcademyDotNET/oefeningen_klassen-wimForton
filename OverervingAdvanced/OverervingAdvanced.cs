using System;

namespace OverervingAdvanced
{
    class OverervingAdvanced
    {
        static void Main(string[] args)
        {
            //HiddenBookmark myBookmark = new HiddenBookmark();
            //Console.WriteLine(myBookmark);
            //myBookmark.OpenSite();
            //RunBook();
            RunGeo();
        }

        private static void RunBook()
        {
            Book myRodeRidder = new Book("de rode ridder", 600, "schrijver", 123456);
            CoffeeTableBook mySuskeWiske = new CoffeeTableBook("susenwis", 200, "schrijver", 456789);
            TextBook bijbel = new TextBook("sprookjes van vroeger", 5, "petrus", 345678);
            Book myOmnibus = Book.TelOp(bijbel, mySuskeWiske);
            Console.WriteLine(mySuskeWiske);
            Console.WriteLine(myOmnibus);
            Console.WriteLine(myRodeRidder.Equals(myRodeRidder));

        }
        private static void RunGeo()
        {
            Driehoek myDriehoek = new Driehoek(20, 30);
            Vierkant myVierkant = new Vierkant(100, 30);
            RechtHoek myRechthoek = new RechtHoek(50, 30);
            Console.WriteLine(myDriehoek.BerekenOppervlakte());
            Console.WriteLine(myVierkant.BerekenOppervlakte());
            Console.WriteLine(myRechthoek.BerekenOppervlakte());

        }
    }
}
