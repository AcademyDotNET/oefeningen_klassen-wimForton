using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryManagment
{
    /*class Meetlat
    {
        private double LengteInM;
        private double LengteInCm;
        private double LengteInKm;
        private double LengteInVoet;
        public double SetLengte
        {
            set 
            {
                LengteInM = value;
            }
        }
        public double GetLengteInCm
        {
            get
            {
                return LengteInM / 100;
            }
        }
        public double GetLengteInKm
        {
            get
            {
                    return LengteInM * 0.001;
            }
        }
        public double GetLengteInVoet
        {
            get
            {
                return LengteInM * 3.2808;
            }
        }
    }*/
    class Pokemon
    {

        private int hP_Base;
        private int attack_Base;
        private int defense_Base;
        private int specialAttack_Base;
        private int specialDefense_Base;
        private int speed_Base;
        public string Naam { get; set; }
        public int Nummer { get; set; }
        private int level;
        /*
        private int average;
        private int total;
        private int hP_Full;
        private int attack_Full;
        private int defense_Full;
        private int specialAttack_Full;
        private int specialDefense_Full;
        private int speed_Full;
        */

        public void InitPokemon(String naam, int health, int attack, int defense, int specialAttack, int specialDefense,int speed)
        {
            Naam = naam;
            HP_Base = health;
            Attack_Base = attack;
            Defense_Base = defense;
            SpecialAttack_Base = specialAttack;
            SpecialDefense_Base = specialDefense;
            Speed_Base = speed;
        }

        public int HP_Base
        {
            get { return hP_Base; }
            set { hP_Base = value; }
        }
        public int Attack_Base
        {
            get { return attack_Base; }
            set { attack_Base = value; }
        }
        public int Defense_Base
        {
            get { return defense_Base; }
            set { defense_Base = value; }
        }
        public int SpecialAttack_Base
        {
            get { return specialAttack_Base; }
            set { specialAttack_Base = value; }
        }
        public int SpecialDefense_Base
        {
            get { return specialDefense_Base; }
            set { specialDefense_Base = value; }
        }
        public int Speed_Base
        {
            get { return speed_Base; }
            set { speed_Base = value; }
        }
        public int Level
        {
            get { return level; }
            private set { level = value; }
        }
        public int HP_Full
        {
            get { 
                return (((HP_Base + 50) * Level) / 50) + 10; 
            }
        }
        public int Attack_Full
        {
            get
            {
                return ((attack_Base * Level) / 50) + 5;
            }
        }
        public int Defense_Full
        {
            get
            {
                return ((defense_Base * Level) / 50) + 5;
            }
        }
        public int SpecialAttack_Full
        {
            get
            {
                return ((specialAttack_Base * Level) / 50) + 5;
            }
        }
        public int SpecialDefense_Full
        {
            get
            {
                return ((specialDefense_Base * Level) / 50) + 5;
            }
        }
        public int Speed_Full
        {
            get
            {
                return ((speed_Base * Level) / 50) + 5;
            }
        }
        public void VerhoogLevel()
        {
            Level++;
        }
        public int Average
        {
            get
            {//waarom property en niet method?
                //average = (HP_Base + Attack_Base + Defense_Base + SpecialAttack_Base + SpecialDefense_Base + Speed_Base) / 6;
                return (HP_Base + Attack_Base + Defense_Base + SpecialAttack_Base + SpecialDefense_Base + Speed_Base) / 6; //average;
            }
        }
        public int Total
        {
            get
            {
                //total = HP_Base + Attack_Base + Defense_Base + SpecialAttack_Base + SpecialDefense_Base + Speed_Base;
                return HP_Base + Attack_Base + Defense_Base + SpecialAttack_Base + SpecialDefense_Base + Speed_Base; //Total;
            }
        }
        public void ShowInfo()
        {
            Console.WriteLine($"{Naam} (level {Level})");
            Console.WriteLine($"Base stats:");
            Console.WriteLine($"\thealth {hP_Base})");
            Console.WriteLine($"\tattack {attack_Base})");
            Console.WriteLine($"\tdefense {defense_Base})");
            Console.WriteLine($"\tspecialAttack {specialAttack_Base})");
            Console.WriteLine($"\tspecialDefense {specialDefense_Base})");
            Console.WriteLine($"\tspeed {speed_Base})");

            Console.WriteLine($"Full stats:");
            Console.WriteLine($"\thealth {HP_Full})");
            Console.WriteLine($"\tattack {Attack_Full})");
            Console.WriteLine($"\tdefense {Defense_Full})");
            Console.WriteLine($"\tspecialAttack {SpecialAttack_Full})");
            Console.WriteLine($"\tspecialDefense {SpecialDefense_Full})");
            Console.WriteLine($"\tspeed {Speed_Full})");

            /*         private int attack_Base;
         private int defense_Base;
         private int specialAttack_Base;
         private int specialDefense_Base;
         private int speed_Base;*/
        }

    }
}
