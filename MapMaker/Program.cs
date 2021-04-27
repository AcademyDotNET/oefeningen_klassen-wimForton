using System;

namespace MapMaker
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayMapmaker();
        }

        private static void PlayMapmaker()
        {
            FurnitureElement myFurnitureElement = new FurnitureElement(10);
            myFurnitureElement.Paint();
        }
    }
}
