using System;
using PokemonClasses;

namespace PokemonTester
{
    //public enum PokemonName { Bulbasaur, Ivysaur, Venusaur, MegaVenusaur, Charmander } //geen strings
    class PokemonTesterProgram
    {
        static void Main(string[] args)
        {
            //PlayPokemon();
            Pokemon myPokemon1 = Pokemon.GeneratorPokemon();
            Pokemon myPokemon2 = Pokemon.GeneratorPokemon();
            Console.WriteLine(myPokemon1.Equals(myPokemon2));
            Console.WriteLine(myPokemon1.Equals(myPokemon1));
        }

        private static void PlayPokemon()
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
                if (i < 5) { myPokemons[i].NoLevelingAllowed = true; }
            }
            for (int i = 0; i < 15; i++)
            {
                Console.Clear();
                Random myRandom = new Random();
                int pokeIndex1 = myRandom.Next(0, 10);
                int pokeIndex2 = myRandom.Next(0, 10);
                //int result = myPokemons[pokeIndex1].Battle(myPokemons[pokeIndex2]);
                int result = Pokemon.Battle(myPokemons[pokeIndex1], myPokemons[pokeIndex2]);
                if (result == 1)
                {
                    myPokemons[pokeIndex1].VerhoogLevel();
                }
                if (result == 2)
                {
                    myPokemons[pokeIndex2].VerhoogLevel();
                }
                System.Threading.Thread.Sleep(700);

            }
        }
    }
}
