using System;
using System.Collections.Generic;

namespace List
{
    class Program
    {
        static void Main(string[] args)
        {
            //PrijzenMetForeach();
            //KaartenSpel();
            StudentOrganizer();
            //BookMark.OpenSite();
        }

        private static void StudentOrganizer()
        {

            bool keepRunning = true;

            List<Student> Studenten = new List<Student>();
            for (int i = 0; i < 5; i++)
            {
                Studenten.Add(new Student());
            }
            while (keepRunning)
            {
                Console.WriteLine("\n");
                Console.WriteLine("Wa wilde gij doen?");
                Console.WriteLine("1: geefStudentenIn");
                Console.WriteLine("2: verwijder student");
                Console.WriteLine("3: geef overzicht");
                Console.WriteLine("4: quit");
                int actie = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (actie)
                {
                    case 1:
                        geefStudentenIn(Studenten);
                        break;
                    case 2:
                        VerwijderStudent(Studenten);
                        break;
                    case 3:
                        foreach (var item in Studenten)
                        {
                            if(item.isIngevuld)
                            item.GeefOverzicht();
                        }
                        break;
                    case 4:
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Dit snap ik niet, ik ben maar een domme computer.");
                        break;
                }
                


            }
            
        }

        private static void VerwijderStudent(List<Student> Studenten)
        {
            //bool test = false;
            bool overschrijven = false;
            bool doInput = true;

            while (doInput)
            {
                Console.WriteLine("kies de student (1 tot 5):");
                int studentNummer = Math.Clamp(Convert.ToInt32(Console.ReadLine()) - 1, 0, 4);

                Console.WriteLine("zeker? y/n");
                if (Console.ReadLine() == "y")
                {
                    overschrijven = true;
                }
                else
                {
                    overschrijven = false;
                }

                if (overschrijven)
                {
                    Studenten[studentNummer] = new Student();
                }
                Console.WriteLine("nog eentje afvoeren? y/n");
                if (Console.ReadLine() == "y")
                {
                    doInput = true;
                }
                else
                {
                    doInput = false;
                }

            }
        }

        private static void geefStudentenIn(List<Student> Studenten) {
            bool test = false;
            bool overschrijven = false;
            bool doInput = true;

            while (doInput)
            {
                Console.WriteLine("kies de student (1 tot 5):");
                int studentNummer = Math.Clamp(Convert.ToInt32(Console.ReadLine()) - 1, 0, 4);
                if (Studenten[studentNummer].Naam != "undefined")
                {
                    Console.WriteLine("student bestaat, overschrijven? y/n");
                    if (Console.ReadLine() == "y")
                    {
                        overschrijven = true;
                    }
                    else
                    {
                        overschrijven = false;
                    }
                }
                else
                {
                    overschrijven = true;
                }
                if (overschrijven)
                {
                    Studenten[studentNummer].isIngevuld = true;
                    Console.WriteLine("kies de klas (EA1, EA2, EA3, EA4):");
                    Studenten[studentNummer].Klas = Student.Klassen.EA3;
                    var testje = Convert.ToString(Student.Klassen.EA2);
                    Student.Klassen inputKlas = Student.Klassen.undefined;
                    //Klassen inputKlas = Studenten[studentNummer].Klas;
                    //test = Enum.TryParse(Console.ReadLine(), out inputKlas);
                    if (test) Studenten[studentNummer].Klas = inputKlas;
                    Console.WriteLine("geef leeftijd:");
                    Studenten[studentNummer].Leeftijd = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("geef naam:");
                    Studenten[studentNummer].Naam = Console.ReadLine();
                    Console.WriteLine("geef punten communicatie:");
                    Studenten[studentNummer].PuntenCommunicatie = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("geef punten programming principles:");
                    Studenten[studentNummer].PuntenProgrammingPrinciples = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("geef punten web tech:");
                    Studenten[studentNummer].PuntenWebTech = Convert.ToInt32(Console.ReadLine());
                }
                Console.WriteLine("nog eentje invoeren? y/n");
                if (Console.ReadLine() == "y")
                {
                    doInput = true;
                }
                else
                {
                    doInput = false;
                }
                
            }
        }

        private static void KaartenSpel()
        {
            List<Speelkaart> SpeelKaarten = new List<Speelkaart>();
            for (int i = 0; i < 52; i++) {
                Symbool mySymbool = Symbool.undefined;
                int kleurIndex = i / 13;
                switch (kleurIndex)
                {
                    case 0:
                        mySymbool = Symbool.harten;
                        break;
                    case 1:
                        mySymbool = Symbool.klaveren;
                        break;
                    case 2:
                        mySymbool = Symbool.schoppen;
                        break;
                    case 3:
                        mySymbool = Symbool.ruiten;
                        break;
                    default:
                        mySymbool = Symbool.undefined;
                        break;
                }
                SpeelKaarten.Add(new Speelkaart(i%13 + 1, mySymbool));
                //Console.WriteLine("info" + SpeelKaarten[i].Getal + SpeelKaarten[i].Kleur);
            }
            while(SpeelKaarten.Count > 0)
            {
                Random myRandom = new Random();
                int speelKaartindex = myRandom.Next(0, SpeelKaarten.Count);
                Console.WriteLine($"random kaart is: {SpeelKaarten[speelKaartindex].Kleur} {SpeelKaarten[speelKaartindex].Getal} ");
                SpeelKaarten.RemoveAt(speelKaartindex);
            }
        }

        private static void PrijzenMetForeach()
        {
            double totaal = 0;
            double[] prijzen = new double[5];
            for (int i = 0; i < prijzen.Length; i++)
            {
                Console.WriteLine("geef een prijs");
                prijzen[i] = Convert.ToDouble(Console.ReadLine());
            }
            foreach (var item in prijzen)
            {
                if(item <= 5) { 
                    Console.WriteLine(item); 
                }
                totaal += item;
            }
            if(prijzen.Length != 0)
            {
                Console.WriteLine($"gemiddelde =  {totaal / prijzen.Length}");
            }
        }
    }
}
