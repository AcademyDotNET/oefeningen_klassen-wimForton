using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapMaker
{
    class ZetelElement : FurnitureElement
    {
        public int price { get; set; }
        public ZetelElement(Point inLocation, int inUnitSize, char indrawchar = '.') : base()
        {
            price = 100;
            DrawChar = indrawchar;
            UnitSize = inUnitSize;
            Location = inLocation;
        }
        public override void Paint(Point inParentLocation)
        {
            Point paintLocation = new Point(Location.X + inParentLocation.X, Location.Y + inParentLocation.Y);
            for (int i = paintLocation.X; i < paintLocation.X + UnitSize; i++)
            {
                for (int j = paintLocation.Y; j < paintLocation.Y + UnitSize; j++)
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
