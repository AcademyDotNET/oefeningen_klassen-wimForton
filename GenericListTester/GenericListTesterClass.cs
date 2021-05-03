using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericListTester
{
    class GenericListTesterClass
    {
        //System.Collections.ArrayList myArrayList = new ArrayList();
        //List<string> myList = new List<string>();
        //Queue<string> myQueue = new Queue<string>();
        Dictionary<string, studentje> myDictionary = new Dictionary<string, studentje>();
        public GenericListTesterClass()
        {
            /*
            myArrayList.Add("dit is een string");
            myArrayList.Add(5);

            myQueue.Enqueue("first");
            myQueue.Enqueue("second");
            myQueue.Enqueue("third");

            Console.WriteLine(myQueue.Dequeue());
            Console.WriteLine(myQueue.Dequeue());
            */
        }
        public void VraagNaamEnLeeftijd()
        {
            
            Console.WriteLine("Geef naam in");
            string naam = Console.ReadLine();
            if (myDictionary.ContainsKey(naam))
            {
                Console.WriteLine("Naam is in gebruik");
            }
            else
            {
                Console.WriteLine("Geef leeftijd in");
                int leeftijd = Convert.ToInt32(Console.ReadLine());
                studentje myStudent = new studentje(naam, leeftijd);
                myDictionary.Add(naam, myStudent);
            }
        }
        public void NaamEnLeeftijd(string naam, int leeftijd)
        {
            studentje myStudent = new studentje(naam, leeftijd);
            myDictionary.Add(naam, myStudent);
        }

        public void ZoekOpNaam()
        {
            Console.WriteLine("Geef naam in(zoek op naam)");
            Console.WriteLine($"leeftijd is: {myDictionary[Console.ReadLine()].Leeftijd}");
        }
        public void VerwijderStudent(string naam)
        {
            myDictionary.Remove(naam);
        }
        public void ToonAlles()
        {
            //Console.WriteLine(myDictionary.);
            /*
            foreach (KeyValuePair<string, studentje> author in myDictionary)
            {
                Console.WriteLine("Key: {0}, Value: {1}",
                author.Key, author.Value);
            }*/
            foreach (var item in myDictionary)
            {
                Console.WriteLine($"naam: {item.Key} Leeftijd {item.Value.Leeftijd}");
                
            }

        }

    }
    class studentje
    {
        public string Naam { get; set; }
        public int Leeftijd { get; set; }
        public studentje(string naam, int leeftijd)
        {
            Naam = naam;
            Leeftijd = leeftijd;
        }
    }
    class KaartSpel
    {
        private List<Kaart> myKaartSpelOnGeschud = new List<Kaart>();
        private Stack<Kaart> myKaartSpelGeschud = new Stack<Kaart>();
        public KaartSpel()
        {
            string beeldje = "";
            string symbool = "";
            Random myRandom = new Random();

            for( int i = 0; i < 52; i++)
            {
                int myModulo = i % 13;
                int kleurNummer = (int)Math.Ceiling(((double)i + 1) / 13);
                if (kleurNummer == 1) { symbool = "harten"; }
                if (kleurNummer == 2) { symbool = "klaveren"; }
                if (kleurNummer == 3) { symbool = "ruiten"; }
                if (kleurNummer == 4) { symbool = "schoppen"; }
                if (myModulo <= 9) {
                    beeldje = Convert.ToString(myModulo + 1);
                }
                else if(myModulo == 10)
                {
                    beeldje = "Boer";
                }
                else if (myModulo == 11)
                {
                    beeldje = "Dame";
                }
                else if (myModulo == 12)
                {
                    beeldje = "Heer";
                }
                
                myKaartSpelOnGeschud.Add(new Kaart(beeldje, symbool) );
            }
            for (int i = 0; i < 52; i++)
            {
                int index = myRandom.Next(0, myKaartSpelOnGeschud.Count);
                myKaartSpelGeschud.Push(myKaartSpelOnGeschud[index]);
                myKaartSpelOnGeschud.RemoveAt(index);
            }
                foreach (var item in myKaartSpelGeschud)
            {
                Console.WriteLine($"beeldje: {item.Beeldje} symbool {item.Symbool}");
            }
        }

    }
    class Kaart
    {
        public string Beeldje { get; set; }
        public string Symbool { get; set; }
        public Kaart(string beeldje, string symbool)
        {
            Beeldje = beeldje;
            Symbool = symbool;
        }
    }
}
