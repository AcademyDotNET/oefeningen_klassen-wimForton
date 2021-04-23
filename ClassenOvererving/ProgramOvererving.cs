using System;
using System.Collections.Generic;

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

            for (int i = 0; i < 10; i++)
            {
                int x = myRandom.Next(2, Console.WindowWidth);
                int y = myRandom.Next(2, Console.WindowHeight);
                int vx = myRandom.Next(1, 3);
                int vy = myRandom.Next(1, 6);
                if (i % 2 == 0) {
                    vx *= -1;
                }
                myBalletjes.Add(new Ball(x, y, vx, vy, i+1));
            }

            while (true)
            {
                Ball.collide(myBalletjes);
                foreach (var item in myBalletjes)
                {

                    item.Update();
                    item.Draw();
                }

                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey();
                    myBalletjes[0].ChangeVelocity(key);

                }

                System.Threading.Thread.Sleep(1);
            }
        }
        private static void BalSpelInteractief()
        {
            Console.CursorVisible = false;
            Console.WindowHeight = 20;
            Console.WindowWidth = 30;
            Ball b1 = new Ball(4, 4, 1, 0, 0);
            PlayerBall player = new PlayerBall(10, 10, 0, 0, 1);
            while (true)
            {

                Console.Clear();

                //Ball
                b1.Update();
                b1.Draw();

                //SpelerBall
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey();
                    player.ChangeVelocity(key);
                }

                player.Update();
                player.Draw();

                //Check collisions
                if (Ball.CheckHit(b1, player))
                {
                    Console.Clear();
                    Console.WriteLine("Gewonnen!");
                    Console.ReadLine();
                }
                System.Threading.Thread.Sleep(100);
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
