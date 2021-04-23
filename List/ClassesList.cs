using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace List
{
    enum Symbool {harten, klaveren, schoppen, ruiten, undefined };
    class Speelkaart
    {
        private int getal;
        private Symbool kleur;
        public Speelkaart(int inGetal, Symbool inKleur)
        {
            Getal = inGetal;
            Kleur = inKleur;
        }
        public int Getal
        {
            get
            {
                return getal;
            }
            set
            {
                getal = value;
            }
        }
        public Symbool Kleur
        {
            get
            {
                return (kleur);
            }
            set
            {
                kleur = value;
            }
        }

    }
    //enum Klassen { EA1, EA2, EA3, EA4, undefined }

    class Student
    {
        public enum Klassen { EA1, EA2, EA3, EA4, undefined }
        public bool isIngevuld { get; set; } = false;
        public string Naam { get; set; }
        public int Leeftijd { get; set; }
        public Klassen Klas { get; set; }

        public int PuntenCommunicatie { get; set; }
        public int PuntenProgrammingPrinciples { get; set; }
        public int PuntenWebTech { get; set; }

        public Student()//(string inNaam, int inLeeftijd, Klassen inKlas, int inPuntenCommunicatie, int PuntenProgrammingPrinciples, int PuntenWebTech)
        {
            Naam = "undefined";
            Leeftijd = 0;
            Klas = Klassen.undefined;
            PuntenCommunicatie = 0;
            PuntenProgrammingPrinciples = 0;
            PuntenWebTech = 0;
        }

        public double BerekenTotaalCijfer()
        {
            return (PuntenCommunicatie + PuntenProgrammingPrinciples + PuntenWebTech) / 3.0;
        }

        public void GeefOverzicht()
        {
            Console.WriteLine($"{Naam}, {Leeftijd} jaar");
            Console.WriteLine($"Klas: {Klas}");
            Console.WriteLine();
            Console.WriteLine("Cijferrapport");
            Console.WriteLine("*************");
            Console.WriteLine($"Communicatie:\t\t{PuntenCommunicatie}");
            Console.WriteLine($"Programming Principles:\t{PuntenProgrammingPrinciples}");
            Console.WriteLine($"Web Technology:\t\t{PuntenWebTech}");
            Console.WriteLine($"Gemiddelde:\t\t{BerekenTotaalCijfer():0.0}");
        }
    }
    class BookMark
    {

        public string Naam { get; set; }
        public string URL { get; set; }
        public static void OpenSite()
        {
            Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe", "vrt.be");  //Voeg bovenaan using System.Diagnostics; toe
        }
    }
}
