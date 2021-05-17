using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace ClassenOvererving
{
    class ProgramOvererving
    {
        static void Main(string[] args)
        {
            //HetDierenrijk();
            //ZiekenHuis();
            BalSpel();
            //BalSpelInteractief();
        }

        private static void BalSpel()
        {
            Console.CursorVisible = false;
            Console.WindowHeight = 40;
            Console.WindowWidth = 60;
            List<Ball> myBalletjes = new List<Ball>();
            Random myRandom = new Random();
            myBalletjes.Add(new PlayerBall(20, 20, 0, 0, 0));
            int drawTrigger = 0;

            for (int i = 0; i < 40; i++)
            {
                int x = myRandom.Next(2, Console.WindowWidth);
                int y = myRandom.Next(2, Console.WindowHeight);
                int vx = myRandom.Next(1, 1);
                int vy = myRandom.Next(1, 2);
                if (i % 2 == 0) {
                    vx *= -1;
                }
                myBalletjes.Add(new Ball(x, y, vx, vy, i+1));
            }

            while (true)
            {
                drawTrigger++;
                Ball.collide(myBalletjes);
                foreach (var item in myBalletjes)
                {
                    item.Update();
                    if (drawTrigger % 10 == 0)
                        item.Draw();
                }

                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey();
                    myBalletjes[0].ChangeVelocity(key);

                }

                if (drawTrigger%10 == 0) System.Threading.Thread.Sleep(10);
                Console.SetCursorPosition(0, 0);
                Console.WriteLine(Ball.score);
            }
        }
  

        private static void ZiekenHuis()
        {
            Patient myPatient = new Patient();
            VerzekerdePatient myVerzekerdePatient = new VerzekerdePatient();
            myPatient.aantalUur = 12.45;
            myVerzekerdePatient.aantalUur = 12.45;
            Console.WriteLine($"kost 1: {myPatient.berekenKost()}");
            Console.WriteLine($"kost 2: {myVerzekerdePatient.berekenKost()}");

        }

        private static void HetDierenrijk()
        {
            List<Animal> myAnimals = new List<Animal>();
            for (int i = 0; i<20; i++) {
                if(i < 10)myAnimals.Add(new Reptile());
                else myAnimals.Add(new Mammal());
            }
            foreach (var item in myAnimals)
            {
                item.ToonInfo();
            }

        }
    }
}
