using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace ParticleSystem
{
    class ParticleProgram
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB");
            PlayParticles();
            //PlayParticleFactory();
        }

        private static void PlayParticleFactory()
        {
            /*
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            dictionary.Add(1, "ParticleEmitter");
            dictionary.Add(2, "ParticleTensionLine");
            dictionary.Add(3, "Motorbike");
            dictionary.Add(4, "Truck");
            dictionary.Add(5, "Bicycle");
            int chosenValue = 0;
            do
            {
                string UserInput = Console.ReadLine();
                chosenValue = Convert.ToInt32(UserInput);
            } while (chosenValue > 2 || chosenValue < 1);

            Console.WriteLine("Hoe wil je je emitter noemen?");
            string naam = Console.ReadLine();
            dictionary.TryGetValue(chosenValue, out string value);*/

            ParticleEmitter myParticleTemp = new ParticleEmitter(1);
            //var y = Type.GetType(myParticleTemp);
            var y = Type.GetType($"ParticleSystem.ParticleEmitter");
            Object[] args = { };//{ 50, Vector.setNew(1, 1, 1), 1.0, 1.0, 0.999 };
            //ParticleEmitter myParticle = (ParticleEmitter)Activator.CreateInstance(y);
            //ParticleEmitter myParticle = new ParticleEmitter();

            //Console.WriteLine($"You've build a {myParticle.GetType().Name}");
        }

        private static void PlayParticles()
        {
            Console.SetWindowSize(100, 50);
            int counter = 0;
            IParticleSystem myEmitter = new ParticleEmitter(50, Vector.setNew(20, 16, 5), 2, 0.01, 0.99, true);
            Console.CursorVisible = false;
            while (counter < 500)
            {
                counter++;
                Console.SetCursorPosition(0,0);
                Console.WriteLine(counter);

                Draw3DObject.DrawParticlesToConsole2D(myEmitter as ParticleEmitter);
                Save3DObject.SaveToCSV(myEmitter as ParticleEmitter, counter);
                myEmitter.UpdateParticles();

                if (counter % 4 == 0)
                {
                    System.Threading.Thread.Sleep(1);
                }
            }
        }
    }
}
