using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics; //Voeg bovenaan using System.Diagnostics; toe

namespace OverervingAdvanced
{
    class BookMark
    {

        public string Naam { get; set; }
        public string URL { get; set; } = "www.vrt.be";
        public BookMark()
        {

        }
        public override string ToString() {
            return Naam + URL;
        }
        public virtual void OpenSite()
        {
            Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe", URL);  //"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe"
        }
    }
    class HiddenBookmark : BookMark {
        public override string ToString()
        {
            string returnString = base.ToString();
            returnString += "---HIDDEN---";
            return returnString;
        }
        public override void OpenSite()
        {
            Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe", "-incognito " + URL);  //"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe"
        }
    }
    class Book
    {
        public int isbn { get; set; } = 0;
        public string title { get; set; } = "undefined";
        public string author { get; set; } = "undefined";
        private double price;

        public Book(string inTitle, double inPrice, string inAuthor, int inIsbn) {
            title = inTitle;
            Price = inPrice;
            author = inAuthor;
            isbn = inIsbn;
        }


        public virtual double Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
            }
        }
        public static Book TelOp(Book boek1, Book boek2) {
            
            string myTitle = "Omnibus: " + boek1.title + ", " + boek2.title;
            double myPrice = boek1.price + boek2.price / 2;
            Book myOmnibus = new Book(myTitle, myPrice, boek1.author, boek1.isbn);
            return myOmnibus;
        }
        public override string ToString()
        {
            return $"titel {title}, prijs {Price}";
        }
        public override bool Equals(Object o)
        {
            bool gelijk;
            if (GetType() != o.GetType())
                gelijk = false;
            else
            {
                Book temp = (Book)o; //Zie opmerking na code!
                if (isbn == temp.isbn)
                    gelijk = true;
                else gelijk = false;
            }
            return gelijk;
        }

    }
    class TextBook : Book
    {
        public TextBook(string inTitle, double inPrice, string inAuthor, int inIsbn) :base(inTitle, inPrice, inAuthor, inIsbn)
        {

        }
        public int GradeLevel { get; set; }
        public override double Price { 
            get => Math.Clamp(base.Price, 20, 80); 
            set => base.Price = value; 
        }



    }
    class CoffeeTableBook : Book
    {
        public CoffeeTableBook(string inTitle, double inPrice, string inAuthor, int inIsbn) : base(inTitle, inPrice, inAuthor, inIsbn)//zo omdat er een constructor is
        {

        }
        public override double Price
        {
            get => Math.Clamp(base.Price, 35, 100);
            set => base.Price = value;
        }
    }
    //////////////////////////////////////////////////////////////////////////////////GeometricFigure
    abstract class GeometricFigure
    {
        public int hoogte { get; set; }
        public int breedte { get; set; }
        public abstract int BerekenOppervlakte();

    }
    class RechtHoek : GeometricFigure
    {
        public RechtHoek(int inHoogte, int inBreedte)
        {
            hoogte = inHoogte;
            breedte = inBreedte;
        }
        public override int BerekenOppervlakte()
        {
            return hoogte * breedte;
        }
    }
    class Vierkant : GeometricFigure
    {
        public Vierkant(int inHoogte, int inBreedte)
        {
            hoogte = inHoogte;
            breedte = inBreedte;
            if (hoogte > breedte)
            {
                breedte = hoogte;
            }
            else
            {
                
                hoogte = breedte;
            }
        }
        public override int BerekenOppervlakte()
        {
            return hoogte * breedte;
        }
    }
    class Driehoek : GeometricFigure
    {
        public Driehoek(int inHoogte, int inBreedte)
        {
            hoogte = inHoogte;
            breedte = inBreedte;
        }
        public override int BerekenOppervlakte()
        {
            return hoogte * breedte / 2;
        }
    }
    //////////////////////////////////////////////////////////////////////Dier
    abstract class Dier
    {

    }
}
