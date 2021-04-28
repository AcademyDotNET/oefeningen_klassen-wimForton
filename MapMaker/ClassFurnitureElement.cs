using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapMaker
{
    class FurnitureElement : MapObject
    {
        private int unitSize;
        Point temp = new Point(0, 0);
        public int UnitSize
        {
            get { return unitSize; }
            set { if (value > 0) unitSize = value; }
        }
        public FurnitureElement()
        {
            // UnitSize = inUnitSize;
        }
        public FurnitureElement(int inUnitSize)
        {
            UnitSize = inUnitSize;
        }

        public override void Paint(Point inParentLocation)
        {
            for (int i = Location.X; i < Location.X + UnitSize; i++)
            {
                for (int j = Location.Y; j < Location.Y + UnitSize; j++)
                {
                    if (i < Console.WindowWidth && j < Console.WindowHeight)
                    {
                        Console.SetCursorPosition(i, j);
                        Console.Write(DrawChar);
                    }
                }
            }
        }
    }
}

