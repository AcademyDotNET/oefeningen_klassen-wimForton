using System;

namespace compositie
{
    class CompositieProgram
    {
        static void Main(string[] args)
        {
            Boat mySpeedboat = new Boat(8, 4);
            Boat mySailboat = new Boat(0, 0);
            mySpeedboat.myEngines[1].myPistons[2].Turn();
        }
    }
}
