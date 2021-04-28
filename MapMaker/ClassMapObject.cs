using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapMaker
{
    abstract class MapObject
    {
        public Point Location;
        private double price;
        protected char drawChar;
        public MapObject()
        {
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
        public abstract void Paint(Point inParentLocation);
    }
}
