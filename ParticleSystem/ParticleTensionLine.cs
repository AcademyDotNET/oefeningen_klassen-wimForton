using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystem
{
    
    class ParticleTensionLine : IParticleSystem
    {
        public List<Particle> myParticles = new List<Particle>();
        private double Drag { get; set; } = 0.999;
        private double Gravity { get; set; } = 0;
        public ParticleTensionLine(int inParticleMaxAmount, Vector inEmitPos, double inExplosion, double inGravity, double friction, bool recycle = false, double turbulenceStrength = 0, double turbulenceSize = 0)
        {
            for(int i = 0; i < inParticleMaxAmount; i++)
            {

            }
        }
        public void StartParticle(Particle inparticle)
        {
        }
        public void UpdateParticles()
        {
        }
    }
}
