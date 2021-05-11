using System;

namespace ParticleSystem
{
    class ParticleProgram
    {
        static void Main(string[] args)
        {
            PlayParticles();
        }

        private static void PlayParticles()
        {
            Console.SetWindowSize(100, 50);
            int counter = 0;
            ParticleEmitter myEmitter = new ParticleEmitter(10, Vector.setNew(20, 16, 5), 2, 0.01, 0.99, true);
            //public ParticleEmitter(MaxAmount, EmitPos, Explosion, Gravity, Drag, bool recycle, double turbulenceStrength = 0, double turbulenceSize = 0)
            Console.CursorVisible = false;
            while (true)
            {
                counter++;
                Console.SetCursorPosition(0,0);
                Console.WriteLine(counter);
                
                Draw3DObject.DrawParticlesToConsole2D(myEmitter);
                myEmitter.UpdateParticles();

                if (counter % 4 == 0)
                {
                    System.Threading.Thread.Sleep(1);
                }
            }
        }
    }
}
