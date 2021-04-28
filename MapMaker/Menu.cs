using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapMaker
{
    class Menu
    {
        public Menu()
        { }

        public void ShowMenu()
        {
            //Tekenen
            TekenBalk(1);
            TekenOpties(2);
            TekenBalk(5);
        }
        private void TekenBalk(int hoogte)
        {
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.SetCursorPosition(i, hoogte);
                Console.Write('*');
            }
        }
        private void TekenOpties(int hoogte)
        {
            Console.SetCursorPosition(5, hoogte);
            Console.Write("A) Voeg zetel toe op willekeurige locatie");
            Console.SetCursorPosition(5, hoogte + 1);
            Console.Write("B) Beweeg kaart naar beneden");
            Console.SetCursorPosition(5, hoogte + 2);
            Console.Write("Wat wilt u doen?...");
        }
        public void GetInput(List<MapObject> list)
        {
            var input = Console.ReadKey().Key.ToString();
            Console.WriteLine(input);
            if (input == "A" || input == "a")
            {
                Random myRand = new Random();
                int pointX = myRand.Next(0, 50);
                int pointY = myRand.Next(8, 20);
                list.Add(new ZetelElement(new Point(pointX, pointY), 3));
            }
            if (input == "DownArrow")
            {
                for (int i = 0; i < list.Count; i++)
                {
                    list[i].Location = new Point(list[i].Location.X, list[i].Location.Y + 1);
                }
            }
            if (input == "UpArrow")
            {
                for (int i = 0; i < list.Count; i++)
                {
                    list[i].Location = new Point(list[i].Location.X, list[i].Location.Y - 1);
                }
            }
            if (input == "LeftArrow")
            {
                for (int i = 0; i < list.Count; i++)
                {
                    list[i].Location = new Point(list[i].Location.X - 1, list[i].Location.Y);
                }
            }
            if (input == "RightArrow")
            {
                for (int i = 0; i < list.Count; i++)
                {
                    list[i].Location = new Point(list[i].Location.X + 1, list[i].Location.Y);
                }
            }
            if (input == "S" || input == "s")
            {
                Random myRand = new Random();
                int pointX = myRand.Next(8, 50);
                int pointY = myRand.Next(15, 20);
                list.Add(new SalonElement(new Point(pointX, pointY)));
            }
        }

    }
}
