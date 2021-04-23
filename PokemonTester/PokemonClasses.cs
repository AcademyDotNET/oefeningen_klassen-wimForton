using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonClasses
{
    class Pokemon
    {

        private int hP_Base { get; set; }
        private int attack_Base { get; set; }
        private int defense_Base { get; set; }
        private int specialAttack_Base { get; set; }
        private int specialDefense_Base { get; set; }
        public bool NoLevelingAllowed { get; set; } = false;
        private int speed_Base { get; set; }
        static public int randomPokemonsCount = 0;
        private int levelUps { get; set; }
        static public int TotalBattlesFought = 0;
        public string Naam { get; set; }
        public int Nummer { get; set; }
        private int level = 0;
        private int average;
        private int total;
        private int hP_Full;
        private int attack_Full;
        private int defense_Full;
        private int specialAttack_Full;
        private int specialDefense_Full;
        private int speed_Full;
        public Pokemon() {
            Naam = "unnamed";
            HP_Base = 10;
            Attack_Base = 10;
            Defense_Base = 10;
            SpecialAttack_Base = 10;
            SpecialDefense_Base = 10;
            Speed_Base = 10;

        }
        public Pokemon(String naam, int health, int attack, int defense, int specialAttack, int specialDefense, int speed)
        {
            Naam = naam;
            HP_Base = health;
            Attack_Base = attack;
            Defense_Base = defense;
            SpecialAttack_Base = specialAttack;
            SpecialDefense_Base = specialDefense;
            Speed_Base = speed;
        }
        public override string ToString()
        {
            string myOutputString = "";
            myOutputString += base.ToString() + "\n\n";
            myOutputString += $"{Naam} level {Level}\n";
            myOutputString += $"Base stats:\n";
            myOutputString += $"\thealth {hP_Base}\n";
            myOutputString += $"\tattack {attack_Base}\n";
            
            myOutputString += $"\tdefense {defense_Base}\n";
            myOutputString += $"\tspecialAttack {specialAttack_Base}\n";
            myOutputString += $"\tspecialDefense {specialDefense_Base}\n";
            myOutputString += $"\tspeed {speed_Base})\n";
            myOutputString += $"\trandomPokemonsCount {randomPokemonsCount}";
            myOutputString += $"\t\t\tTotalBattlesFought {TotalBattlesFought}\n";

            myOutputString += $"Full stats:\n";
            myOutputString += $"\thealth {HP_Full}\n";
            myOutputString += $"\tattack {Attack_Full}\n";
            myOutputString += $"\tdefense {Defense_Full}\n";
            myOutputString += $"\tspecialAttack {SpecialAttack_Full}\n";
            myOutputString += $"\tspecialDefense {SpecialDefense_Full}\n";
            myOutputString += $"\tspeed {Speed_Full}\n";
            return myOutputString;

        }
        public static Pokemon GeneratorPokemon() {
            Pokemon myPokemon = new Pokemon();
            string[] PokemonNames = { "Bulbasaur", "Ivysaur", "Kinkysaur", "MegaVenusaur", "Charmander", "Charmeleon", "Charizard", "Squirtle", "Wartortle", "Blastoise" };
            Random myRandom = new Random();
            string naam = PokemonNames[myRandom.Next(0, 10)];
            int health = myRandom.Next(20, 60);
            int attack = myRandom.Next(20, 60);
            int defense = myRandom.Next(20, 60);
            int specialAttack = myRandom.Next(20, 60);
            int specialDefense = myRandom.Next(20, 60);
            int speed = myRandom.Next(20, 60);
            int levelUpCount = myRandom.Next(0, 6);

            myPokemon.Naam = naam;
            myPokemon.HP_Base = health;
            myPokemon.Attack_Base = attack;
            myPokemon.Defense_Base = defense;
            myPokemon.SpecialAttack_Base = specialAttack;
            myPokemon.SpecialDefense_Base = specialDefense;
            myPokemon.Speed_Base = speed;
            for (int i = 0; i < levelUpCount; i++)
            {
                myPokemon.VerhoogLevel();
            }
            randomPokemonsCount++;
            return myPokemon;
        }
        //public int Battle(Pokemon poke2)
        public static int Battle(Pokemon poke1, Pokemon poke2)
        {
            //Pokemon poke1 = this;
            TotalBattlesFought++;
            int sleep = 400;
            int winNum = 0;
            if (poke1 != null && poke2 != null)
            {
                if (poke1.HP_Full == poke2.HP_Full)
                {
                    winNum = 0;
                    poke1.ShowInfo();
                    System.Threading.Thread.Sleep(sleep);
                    poke2.ShowInfo();
                    System.Threading.Thread.Sleep(sleep);
                    Console.WriteLine("Pokemon DRAW!!!");
                }
                else if (poke1.HP_Full > poke2.HP_Full)
                {
                    winNum = 1;
                    poke1.ShowInfo();
                    System.Threading.Thread.Sleep(sleep);
                    poke2.ShowInfo();
                    System.Threading.Thread.Sleep(sleep);
                    Console.WriteLine($"{poke1.Naam} WINS!!!");
                }
                else
                {
                    winNum = 2;
                    poke1.ShowInfo();
                    System.Threading.Thread.Sleep(sleep);
                    poke2.ShowInfo();
                    System.Threading.Thread.Sleep(sleep);
                    Console.WriteLine($"{poke2.Naam} WINS!!!");
                }
            }
            else if (poke1 == null && poke2 == null)
            {
                winNum = 0;
                System.Threading.Thread.Sleep(sleep);
                Console.WriteLine("Nobody there? Pokemon DRAW!!!");
            }
            else if (poke2 == null)
            {
                winNum = 1;
                System.Threading.Thread.Sleep(sleep);
                Console.WriteLine($"{poke2.Naam} not there? {poke1.Naam} WINS!!!");
            }
            else
            {
                winNum = 2;
                System.Threading.Thread.Sleep(sleep);
                Console.WriteLine($"{poke1.Naam} not there? {poke2.Naam} WINS!!!");
            }
            return winNum;
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
            if (NoLevelingAllowed)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"{Naam} has no leveling allowed!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Level++;
            }
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
            Console.WriteLine(this);
        }

    }
}
