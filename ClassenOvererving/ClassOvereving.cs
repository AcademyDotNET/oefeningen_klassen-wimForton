using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassenOvererving
{
    class Mammal : Animal
    {
        public string pelsKleur { get; set; } = "rood";
        public override void ToonInfo()
        {
            base.ToonInfo();
            Console.WriteLine($"kleur pels = {pelsKleur}");

        }
    }
    class Reptile : Animal
    {
        public int aantalSchubben { get; set; } = 120;
        public override void ToonInfo()
        {
            base.ToonInfo();
            Console.WriteLine($"aantal schubben = {aantalSchubben}");
   
        }
    }

    class Animal
    {
        private bool leeft { get; set; } = true;
        public virtual void ToonInfo()
        {
            Console.WriteLine($"dit ding leeft = {leeft}");
        }
    }
    class Patient 
    {
        public double aantalUur { get; set; } = 3;
        protected double kostPrijs = 3;
        virtual public double berekenKost()
        {
            kostPrijs = 50 + aantalUur * 20;
            return kostPrijs;
        }

        
    }
    class VerzekerdePatient : Patient {
        public override double berekenKost()
        {
            base.berekenKost();
            kostPrijs *= 0.9;
            return kostPrijs;
        }
    }
    /// <summary>
    /// ///////////////////////////////////////////////////////////////////////////////////////////////////ball
    /// </summary>
    class Ball
    {
        public double X { get { return x; } }
        public double Y { get { return y; } }
        protected static int ballCount = 0;
        protected int id = 0;
        public int collidedInvisibleTime = 0;

        private double lastx = 0;
        private double lasty = 0;
        public double x = 0;
        public double y = 0;
        public double vx = 0;
        public double vy = 0;
        public char drawChar = 'O';
        protected ConsoleColor drawColor = ConsoleColor.White;

        public Ball(int xin, int yin, int vxin, int vyin, int idin)
        {
            ballCount++;
            x = xin;
            lastx = xin;
            y = yin;
            lasty = yin;
            vx = vxin * 0.5;
            vy = vyin * 0.5;
            id = idin;
        }
        public virtual void ChangeVelocity(ConsoleKeyInfo richting)
        {
        }
        public static void collide(List<Ball> balletjes)
        {
            Random myDoubleRandom = new Random();
            for (int i = 0; i < balletjes.Count; i++) {
                for (int j = 0; j < balletjes.Count; j++)
                {
                    if (balletjes[i].collidedInvisibleTime == 0)
                    {
                        if ((int)balletjes[i].x == (int)balletjes[j].x && (int)balletjes[i].y == (int)balletjes[j].y && i != j)
                        {
                            double ran1 = myDoubleRandom.NextDouble();
                            double ran2 = myDoubleRandom.NextDouble();
                            balletjes[i].vx = (ran1 - 0.5) * 2;//balletjes[i].vx * 0.7 + balletjes[j].vx * 0.3;
                            balletjes[i].vy = (ran2 - 0.5) * 4;// = balletjes[i].vy * 0.7 + balletjes[j].vy * 0.3;
                            balletjes[i].collidedInvisibleTime = 100;
                        }
                    }
                    else
                    {
                        if (balletjes[i].collidedInvisibleTime > 0) balletjes[i].collidedInvisibleTime--;
                    }
                    balletjes[i].drawChar = Convert.ToChar(balletjes[i].collidedInvisibleTime%10 + 48);
                }
            }
        }

            public void Update()
        {
            Console.SetCursorPosition((int)x, (int)y);
            Console.Write(" ");
            vy *= 0.99;
            vy += 0.02;
            vx *= 0.995;
            x += vx;
            y += vy;
            if (x >= Console.WindowWidth || x < 0)
            {
                vx *= -1;
                x += vx;
            }
            if (y >= Console.WindowHeight || y < 0)
            {
                vy *= -1;
                y += vy;
            }
        }
        public void Draw()
        {   /*
            Console.SetCursorPosition(lastx, lasty);
            Console.Write(drawChar);
            lastx = x;
            lasty = y;
            */
            Console.SetCursorPosition((int)x, (int)y);
            Console.ForegroundColor = drawColor;
            Console.Write(drawChar);
            Console.ResetColor();

        }

        static public bool CheckHit(Ball ball1, Ball ball2)
        {

            if (ball1.X == ball2.X && ball1.Y == ball2.Y)
                return true;

            return false;
        }
    }
    class PlayerBall : Ball
    {
        public PlayerBall(int xin, int yin, int vxin, int vyin, int idin) : base(xin, yin, vxin, vyin, idin)
        {
            drawChar = 'X';
            drawColor = ConsoleColor.Blue;
            id = idin;
        }

        public override void ChangeVelocity(ConsoleKeyInfo richting)
        {
            switch (richting.Key)
            {
                case ConsoleKey.UpArrow:
                    vy--;
                    break;
                case ConsoleKey.DownArrow:
                    vy++;
                    break;
                case ConsoleKey.LeftArrow:
                    vx--;
                    break;
                case ConsoleKey.RightArrow:
                    vx++;
                    break;
                default:
                    break;
            }
        }
    }
}
