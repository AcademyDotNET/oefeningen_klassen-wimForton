using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compositie_bis
{
    class Land
    {
        private President president;
        Minister eersteMinister;
        List<Minister> Ministers;
        public void MaakRegering()
        {
            if (president != null)
            {
                Random myRandom = new Random();
                int hoeveelMinisters = myRandom.Next(1, 6);
                for (int i = 0; i < hoeveelMinisters; i++)
                {
                    Ministers.Add(new Minister());
                }
                eersteMinister = Ministers[0];
            }
        }
        public void JaarVerder()
        {
            if(president != null && president.Teller > 0)
            {
                president.JaarVerder();
            }
        }
    }
    class Minister
    {
        public string naam { get; set; }
    }
    class President
    {
        public string naam { get; set; }
        private int teller;
        public int Teller
        {
            get
            {
                return teller;
            }
            private set
            {
                teller = value;
            }
        }
        public void JaarVerder()
        {
            Teller++;
        }
    }
}
