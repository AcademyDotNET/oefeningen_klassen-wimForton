using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapMaker
{
    class SalonElement : MapObject
    {
        private List<MapObject> elementen = new List<MapObject>();

        public SalonElement(Point salonLoc)
        {
            Point tmpZetel1 = new Point(0, 0);
            Point tmpZetel2 = new Point(15, 0);
            elementen.Add(new ZetelElement(tmpZetel1, 3, '@'));
            elementen.Add(new ZetelElement(tmpZetel2, 3, '$'));

            Location = salonLoc;
        }

        public override void Paint(Point inParentLocation)
        {
            for (int i = 0; i < elementen.Count; i++)
            {
                //elementen[i].Location = Location;
                elementen[i].Paint(Location);
            }
        }
    }
}
