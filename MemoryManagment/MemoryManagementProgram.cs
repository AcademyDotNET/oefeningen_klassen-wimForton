using System;

namespace MemoryManagment
{
    class MemoryManagementProgram
    {
        static void Main(string[] args)
        {
            Pokemon Bulbasaur = new Pokemon();
            Bulbasaur.Nummer = 1;
            Bulbasaur.Naam = "Bulbasaur";
            Bulbasaur.HP_Base = 45;
            Bulbasaur.Attack_Base = 49;
            Bulbasaur.Defense_Base = 49;
            Bulbasaur.SpecialAttack_Base = 65;
            Bulbasaur.SpecialDefense_Base = 65;
            Bulbasaur.Speed_Base = 45;

            Pokemon Ivysaur = new Pokemon();
            Ivysaur.Nummer = 1;
            Ivysaur.Naam = "Ivysaur";
            Ivysaur.HP_Base = 45;
            Ivysaur.Attack_Base = 49;
            Ivysaur.Defense_Base = 49;
            Ivysaur.SpecialAttack_Base = 65;
            Ivysaur.SpecialDefense_Base = 65;
            Ivysaur.Speed_Base = 45;

            Console.WriteLine($"Naam = {Bulbasaur.Naam}\nAverage = {Bulbasaur.Average}\nTotal = {Bulbasaur.Total}");
            for(int i = 0; i < 100; i++)
            {
                Bulbasaur.VerhoogLevel();
                Bulbasaur.ShowInfo();

            }
        }
    }
}
