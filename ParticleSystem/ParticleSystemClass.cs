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
    class ParticleEmitter: IParticleSystem
    {
        public List<Particle> myParticles = new List<Particle>();
        private double Gravity { get; set; } = 0;
        private Vector EmitPos = new Vector(0, 0, 0);
        private bool RecycleParticles { get; set; } = false;
        private double Explosion { get; set; } = 0;
        private double Drag { get; set; } = 0;
        private Random myRandom = new Random();
        //private Vector color = new Vector(150, 255, 255);

        public ParticleEmitter(int inParticleMaxAmount, Vector inEmitPos, double inExplosion, double inGravity, double friction, bool recycle = false, double turbulenceStrength = 0, double turbulenceSize = 0)
        {
            Gravity = inGravity;
            EmitPos = inEmitPos;
            Explosion = inExplosion;
            Drag = friction;
            RecycleParticles = recycle;
            for (int i = 0; i < inParticleMaxAmount; i++)
            {
                myParticles.Add(new Particle());
                StartParticle(myParticles[i]);
            }
        }
        public void StartParticle(Particle inparticle) {
            double velocityX = (myRandom.NextDouble() - 0.5) * Explosion;
            double velocityY = (myRandom.NextDouble() - 0.5) * Explosion;
            double velocityZ = (myRandom.NextDouble() - 0.5) * Explosion;
            inparticle.ParticleInstance = myRandom.Next(33, 122);
            inparticle.Pos = EmitPos;
            inparticle.Vel = new Vector(velocityX, velocityY, velocityZ);
            inparticle.Age = 0.0;
            inparticle.ParticleInstance = myRandom.Next(33, 122);
            inparticle.RGB = new Vector((int)(myRandom.NextDouble() * 255), (int)(myRandom.NextDouble() * 20), (int)(myRandom.NextDouble() * 255));
            inparticle.Lifespan =  2 + myRandom.NextDouble();
        }
        public void UpdateParticles()
        {
            for (int i = 0; i < myParticles.Count; i++)
            {
                if (i < myParticles.Count)
                {
                    myParticles[i].PrevPos = myParticles[i].Pos;
                    myParticles[i].Age += 0.01;

                    if (myParticles[i].Age >= myParticles[i].Lifespan || Vector.length(myParticles[i].Vel) < 0.03)
                    {
                        if (RecycleParticles)
                        {
                            StartParticle(myParticles[i]);
                        }
                        else
                        {
                            myParticles.RemoveAt(i);
                            break;
                        }

                    }

                    CollideEdges(myParticles[i]);
                    myParticles[i].Vel *= myParticles[i].Drag;
                    myParticles[i].Vel.Y += myParticles[i].Mass * Gravity;

                    myParticles[i].Pos += myParticles[i].Vel;
                }
            }
        }
        public static void CollideEdges(Particle inParticle)
        {
            if (inParticle.Pos.X >= Console.WindowWidth * 0.5 -2 || inParticle.Pos.X <= 1) inParticle.Vel.X *= -1;
            if (inParticle.Pos.Y >= Console.WindowHeight - 4) inParticle.Vel.Y *= -1;
        }

    }
    class ParticleTensionLine: IParticleSystem
    {
        public ParticleTensionLine()
        {

        }
        public void StartParticle(Particle inparticle) 
        { 
        }
        public void UpdateParticles() 
        { 
        }
    }
}
