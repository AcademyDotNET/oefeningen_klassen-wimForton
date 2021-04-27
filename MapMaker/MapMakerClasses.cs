using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapMaker
{
    class Point
    {
        private int x;
        private int y;
        public Point(int inx, int iny)
        {
            X = inx;
            Y = iny;
        }
        public int X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }
        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }

    }
    abstract class MapObject
    {
        protected Point Location;
        private double price;
        protected char drawChar;
        public MapObject() {
            Location = new Point(1, 1);
            DrawChar = '*';
        }
        protected char DrawChar
        {
            get
            {
                return drawChar;
            }
            set
            {
                drawChar = value;
            }
        }

        //Teken object in de console
        public abstract void Paint();
    }
    class WallElement : MapObject
    {
        private Point Location;
        private char drawChar = '*';

        public WallElement()
        {
            Location = new Point(0, 0);
        }
        public override void Paint()
        {
            Console.SetCursorPosition(Location.X, Location.Y);
            Console.Write(drawChar);
        }
    }
    class FurnitureElement : MapObject
    {
        private int unitSize;
        public int UnitSize
        {
            get { return unitSize; }
            set { if (value > 0) unitSize = value; }
        }
        public FurnitureElement(int inUnitSize)
        {
            UnitSize = inUnitSize;
        }
        public override void Paint()
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
