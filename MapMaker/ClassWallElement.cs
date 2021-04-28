using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapMaker
{
    class WallElement : MapObject
    {
        private int unitSize;
        public int UnitSize
        {
            get { return unitSize; }
            set { if (value > 0) unitSize = value; }
        }

        public WallElement(Point tempLoc, char inDrawChar, int inUnitSize)
        {
            UnitSize = inUnitSize;
            DrawChar = inDrawChar;
            Location = tempLoc;
        }
        public override void Paint(Point inParentLocation)
        {
            Console.SetCursorPosition(Location.X, Location.Y);
            Console.Write(drawChar);
        }
    }
}
