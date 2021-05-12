using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ParticleSystem
{
    class Save3DObject
    {
        public static void SaveToCSV(ParticleEmitter inParticles, int frameNr)
        {
            writeCsvStreamWriter(inParticles, frameNr);
        }
        public static void writeCsvStreamWriter(ParticleEmitter inParticles, int frameNr)
        {
            using (StreamWriter streamWriter = new StreamWriter(@"H:\cursus_informatica\Oefening_classes\ParticleSequence\Particles" + Convert.ToString(frameNr) + ".csv"))
            {
                streamWriter.Write(inParticles);
            }
        }
    }
    
}
