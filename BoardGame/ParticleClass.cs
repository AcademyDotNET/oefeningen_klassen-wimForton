using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGame
{
    interface IParticle
    {

    }
    class Particle: IParticle
    {
        private Vector particlePosition { get; set; }
        private Vector particleRotation { get; set; }
        private Vector particleVelocity;
        private ConsoleColor particleColor { get; set; }
        private double particleAge { get; set; }
        public Particle(double inPosX, double inPosY, double inPosZ, double inRotX, double inRotY, double inRotZ, ConsoleColor inColor)
        {
            particlePosition = new Vector(inPosX, inPosY, inPosZ);
            particleRotation = new Vector(inRotX, inRotY, inRotZ);
            Vel = new Vector(0,0,0);
            particleColor = inColor;
            particleAge = 0.0;
        }
        public Vector Vel
        {
            get
            {
                return particleVelocity;
            }
            set
            {
                particleVelocity = value;
            }
        }


    }
}
