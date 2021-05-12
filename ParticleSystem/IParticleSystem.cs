using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystem
{
    interface IParticleSystem
    {
        public void StartParticle(Particle inparticle);
        public void UpdateParticles();
    }
}
