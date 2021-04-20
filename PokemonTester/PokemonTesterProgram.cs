using System;
using PokemonClasses;

namespace PokemonTester
{
    //public enum PokemonName { Bulbasaur, Ivysaur, Venusaur, MegaVenusaur, Charmander } //geen strings
    class PokemonTesterProgram
    {
        static void Main(string[] args)
        {
            Pokemon myPokemon1 = Pokemon.GeneratorPokemon();
            Pokemon myPokemon2 = new Pokemon();
            myPokemon1.NoLevelingAllowed = true;

            Pokemon[] myPokemons = new Pokemon[10];
            Array.Resize(ref myPokemons, 15);
            myPokemons[1] = Pokemon.GeneratorPokemon();
         
            for (int i = 0; i < 15; i++)
            {
                myPokemons[i] = Pokemon.GeneratorPokemon();
                if(i < 5) { myPokemons[i].NoLevelingAllowed = true; }
            }
                for (int i = 0; i < 15; i++)
            {
                Console.Clear();
                Random myRandom = new Random();
                int pokeIndex1 = myRandom.Next(0, 10);
                int pokeIndex2 = myRandom.Next(0, 10);
                //int result = myPokemons[pokeIndex1].Battle(myPokemons[pokeIndex2]);
                int result = Pokemon.Battle(myPokemons[pokeIndex1], myPokemons[pokeIndex2]);
                if (result == 1) {
                    myPokemons[pokeIndex1].VerhoogLevel();
                }
                if (result == 2)
                {
                    myPokemons[pokeIndex2].VerhoogLevel();
                }
                System.Threading.Thread.Sleep(700);
                
            }
        }
        /*
        private static Pokemon GeneratorPokemon()
        {
            string[] PokemonNames = { "Bulbasaur", "Ivysaur", "Kinkysaur", "MegaVenusaur", "Charmander", "Charmeleon", "Charizard", "Squirtle", "Wartortle", "Blastoise" };
            Random myRandom = new Random();
            string naam = PokemonNames[myRandom.Next(0,10)];
            int health = myRandom.Next(20, 60);
            int attack = myRandom.Next(20, 60);
            int defense = myRandom.Next(20, 60);
            int specialAttack = myRandom.Next(20, 60);
            int specialDefense = myRandom.Next(20, 60);
            int speed = myRandom.Next(20, 60);
            int levelUpCount = myRandom.Next(0, 6);

            Pokemon myPokemon = new Pokemon(naam, health, attack, defense, specialAttack, specialDefense, speed);
            for (int i = 0; i < levelUpCount; i++)
            {
                myPokemon.VerhoogLevel();
            }
            //myPokemon.ShowInfo();
            return myPokemon;

        }*/
        /*
        static int Battle(Pokemon poke1, Pokemon poke2)
        {
            int sleep = 400;
            int winNum = 0;
            if (poke1 != null && poke1 != null)
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
            else if (poke1 == null && poke2 == null) { 
                winNum = 0;
                System.Threading.Thread.Sleep(sleep);
                Console.WriteLine("Nobody there? Pokemon DRAW!!!");
            }
            else if (poke2 == null) { 
                winNum = 1;
                System.Threading.Thread.Sleep(sleep);
                Console.WriteLine($"{poke2.Naam} not there? {poke1.Naam} WINS!!!");
            }
            else { 
                winNum = 2;
                System.Threading.Thread.Sleep(sleep);
                Console.WriteLine($"{poke1.Naam} not there? {poke2.Naam} WINS!!!");
            }
            
            return winNum;
        }*/
    }
}
