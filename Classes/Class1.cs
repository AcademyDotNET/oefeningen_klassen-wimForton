using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    public enum Klassen { EA1, EA2, EA3, EB1, EB2 }
    public enum basketbalNiveaus { amateurs, derde, tweede, eerste }
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

        public double Getal1 { get; set; } = 0;
        public double Getal2 { get; set; } = 0;
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
    class Student {
        private string naam;
        private int leeftijd;
        public Klassen WelkeKlas { get; set; }
        private double puntenCommunicatie;
        private double puntenProgrammingPrinciples;
        private double puntenWebTech;
        public string Naam
        {
            set
            {
                naam = value;
            }
        }
        public int Leeftijd {
            set {
                leeftijd = value;
            }
        }
        public double PuntenCommunicatie
        {
            set
            {
                puntenCommunicatie = value;
            }
        }
        public double PuntenProgrammingPrinciples
        {
            set
            {
                puntenProgrammingPrinciples = value;
            }
        }
        public double PuntenWebTech
        {
            set
            {
                puntenWebTech = value;
            }
        }
        public void GeefOverzicht()
        {/*
                    private string naam;
        private int leeftijd;
        public Klassen WelkeKlas { get; set; }
        private double puntenCommunicatie;
        private double puntenProgrammingPrinciples;
        private double puntenWebTech;*/
        Console.WriteLine($"naam: {naam}\nleeftijd: {leeftijd}\nklas: {WelkeKlas}\npuntenCommunicatie: {puntenCommunicatie}\npuntenProgrammingPrinciples: {puntenProgrammingPrinciples}\npuntenWebTech: {puntenWebTech}\n");
        }
    }
    class Pizza
    {
        private string[] toppingsArray = {"ananas", "banaan", "citroen", "margarita" };
        private string toppings = "margarita";
        private int diameter = 15;
        private double price = 5;
        public string Toppings
        {
            get
            {
                return toppings;
            }
            set
            {
                toppings = value;
                if (Array.IndexOf(toppingsArray, toppings) == -1)
                {
                    toppings = "margarita";
                }
                
            }
        }
        public int Diameter
        {
            get
            {
                return diameter;
            }
            set 
            {
                diameter = value;
                if (diameter < 15) { diameter = 15; }
                if (diameter > 40) { diameter = 40; }
            }
        }
        public double Price
        {
            get {
                return price;
            }
            set
            {
                price = value;
                if (price < 5) { price = 5; }
            }
        }
    }
    class Basketballer
    {
        private string naam = "";
        private int rugNummer = 0;
        private bool doelMan = false;
        private bool reserve = false;
        private basketbalNiveaus niveau = basketbalNiveaus.amateurs;

        public void StelIn(string inNaam, int inRugNummer, bool inDoelman, bool inReserve, basketbalNiveaus inNiveau)
        {
            naam = inNaam;
            rugNummer = inRugNummer;
            doelMan = inDoelman;
            reserve = inReserve;
            niveau = inNiveau;
        }
        public void StelUEensVoor() {
            string stelVoorDoelman =  $"ik ben {(doelMan ? "een": "geen")} doelman";
            string stelVoorReserve = $"ik ben {(reserve ? "een" : "geen")} reserve";
            Console.WriteLine($"ik ben {naam}, mijn rugnummer is {rugNummer}, {stelVoorDoelman}, {stelVoorReserve}, ik speel in {niveau}");
        }

        public void Shot()
        {
            Random shotrandom = new Random();
            int shotResult = shotrandom.Next(0, 3);
            switch(shotResult)
            {
                case 0:
                    Console.WriteLine($"{naam} gooit er naast");
                    break;
                case 1:
                    Console.WriteLine($"{naam} gooit op de ring");
                    break;
                case 2:
                    Console.WriteLine($"{naam} maakt een goal!!!");
                    break;
                default:
                    break;
            }
        }
    }
    class BankAccount {
        private bool geldig = true;
        private double rekeningStand = 0;
        public bool KlantStatus
        {
            get {
                return geldig;
            }
            set
            {
                geldig = value;
            }
        }
        public double Stort
        {
            set {
                rekeningStand += value;
            }
        }
        public double HaalAf
        {
            set
            {
                rekeningStand -= value;
            }
        }
        public double CheckRekening
        {
            get
            {
                return rekeningStand;
            }
        }
        public void SchrijfOver(double amount, BankAccount to)
        {
            rekeningStand -= amount;
            to.Stort = amount;
        }

    }
}
