using System;
using MemoryManagment;

namespace PokemonTester
{
    class PokemonTesterProgram
    {
        static void Main(string[] args)
        {
            CreatePokemon();
        }

        private static void CreatePokemon()
        {
            Console.WriteLine("Naam?");
            string naam = Console.ReadLine();
            Console.WriteLine("Health?");
            int health = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("attack?");
            int attack = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("defense?");
            int defense = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("specialAttack?");
            int specialAttack = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("specialDefense?");
            int specialDefense = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("speed?");
            int speed = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("hoeveel level up?");
            int levelUpCount = Convert.ToInt32(Console.ReadLine());

            pokemon myPokemon = new pokemon();
            myPokemon.InitPokemon("Bulbasaur", 45, 49, 49, 65, 65, 45);
            for (int i = 0; i < levelUpCount; i++)
            {
                myPokemon.VerhoogLevel();
            }
            myPokemon.ShowInfo();

        }
    }
}
