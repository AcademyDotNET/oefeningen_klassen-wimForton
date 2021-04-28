using System;
using System.Collections.Generic;

namespace MapMaker
{
    class MapMakerProgram
    {
        static void Main(string[] args)
        {
            PlayMapmaker();
        }

        private static void PlayMapmaker()
        {
            List<MapObject> allObjects = new List<MapObject>(); //lang leve polymorfisme
            int loopTeller = 0;
            Menu menu = new Menu();
            do
            {
                Console.Clear();
                Console.SetCursorPosition(0,10);
                loopTeller++;
                Console.WriteLine(loopTeller);
                menu.ShowMenu();
                
                

                //Teken alle objecten
                for (int i = 0; i < allObjects.Count; i++)
                {
                    allObjects[i].Paint(new Point(0,0));
                }
                if (Console.KeyAvailable)
                {
                    menu.ShowMenu();
                    //menu.GetInput(allObjects);
                }
                menu.GetInput(allObjects);

            } while (true);
        }

    }
}
