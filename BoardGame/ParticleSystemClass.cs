using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGame
{
    class ParticleEmitter
    {
        private List<Particle<string>> myParticles = new List<Particle<string>>();
        private double Gravity { get; set; } = 0;

        public ParticleEmitter(int inParticleMaxAmount, Vector inEmitPos, Vector inExplosion, double inGravity, double turbulenceStrength, double turbulenceSize)
        {
            Random myRandom = new Random();
            string particleDrawObject = "0";
            Vector startPos = inEmitPos;
            Vector velocity = new Vector(0,0,0);
            for (int i = 0; i < myParticles.Count; i++)
            {
                double velocityX = myRandom.NextDouble() - 0.5;
                double velocityY = myRandom.NextDouble() - 0.5;
                double velocityZ = myRandom.NextDouble() - 0.5;
                velocity = new Vector(velocityX, velocityY, velocityZ);
                myParticles.Add(new Particle<string>(particleDrawObject, startPos, null, velocity));
            }
        }
        public void UpdateParticles()
        {
            for (int i = 0; i < myParticles.Count; i++)
            {
                myParticles[i].Vel.Y += myParticles[i].Mass * Gravity;
                myParticles[i].Vel += myParticles[i].Drag;
                myParticles[i].Pos += myParticles[i].Vel;
            }
        }

    }
}
