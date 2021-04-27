using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compositie_bis
{
    class Moederbord
    {
        List<RamGeheugen> slotsA = new List<RamGeheugen>(4);
        public VideoKaart myVideoKaart;
        public Cpu myCpu;
        public void AddRam(RamGeheugen latje)
        {
            if (slotsA.Count < 5)
            {
                slotsA.Add(latje);
            }
            else
            {
                Console.WriteLine("slots zijn vol");
            }
        }
        public VideoKaart VideoKaart
        {
            set
            {
                myVideoKaart = value;
            }
        }
        public Cpu CPU
        {
            set
            {
                myCpu = value;
            }
        }
        public override string ToString()
        {
            string returnstring = "";
            returnstring += myVideoKaart.merk + "\n";
            returnstring += myCpu.merk + "\n";
            for(int i = 0; i < 4; i++)
            {
                if (slotsA[i] != null) returnstring += slotsA[i].merk + "\n";
                else returnstring += "null";
            }
            return returnstring;
        }
    }
    class RamGeheugen
    {
        public string merk;
        public RamGeheugen(string inMerk)
        {
            merk = inMerk;
        }
    }
    class VideoKaart
    {
        public string merk;
        public VideoKaart(string inMerk)
        {
            merk = inMerk;
        }
    }
    class Cpu
    {
        public string merk;
        public Cpu(string inMerk)
        {
            merk = inMerk;
        }
    }
}
