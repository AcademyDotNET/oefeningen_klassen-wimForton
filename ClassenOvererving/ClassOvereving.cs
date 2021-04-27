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
        public static int score = 0;
        protected static int WindowWidth = Console.WindowWidth;
        protected static int WindowHeight = Console.WindowHeight;
        protected int id = 0;
        public int collidedInvisibleTime = 0;
        public int drawTrigger = 0;

        private int lastx = 0;
        private int lasty = 0;
        public double x = 0;
        public double y = 0;
        public double vx = 0;
        public double vy = 0;
        public char drawChar = 'O';
        protected ConsoleColor drawColor = ConsoleColor.DarkCyan;

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
                for (int j = balletjes.Count - 1; j >= 0; j--)
                {
                    if (balletjes[i].collidedInvisibleTime == 0)
                    {
                        if ((int)balletjes[i].x == (int)balletjes[j].x && (int)balletjes[i].y == (int)balletjes[j].y)
                        {
                            double ran1 = myDoubleRandom.NextDouble() - 0.5;
                            double ran2 = myDoubleRandom.NextDouble() - 0.5;

                            double influence_a_b = 0.5;
                            if (i == 0)
                            {
                                influence_a_b = 0.02;
                                ran1 *= 0.0;
                                ran2 *= 0.0;                           
                            }
                            else if (j == 0) {
                                influence_a_b = 0.95;
                                ran1 *= 0.2;
                                ran2 *= 0.2;
                                balletjes[i].collidedInvisibleTime = 10;
                                balletjes[i].vx = Lerp(balletjes[i].vx, balletjes[j].vx, influence_a_b) + ran1;
                                balletjes[i].vy = Lerp(balletjes[i].vy, balletjes[j].vy, influence_a_b) + ran2;
                            }
                            else
                            {
                                ran1 *= 0.0;
                                ran2 *= 0.0;
                            }
                            //balletjes[i].vx += ran1;
                            //balletjes[i].vy += ran2;


                            //balletjes[j].vx = Lerp(balletjes[i].vx, balletjes[j].vx, 1 - influence_a_b);
                            //balletjes[j].vy = Lerp(balletjes[i].vy, balletjes[j].vy, 1 - influence_a_b);

                            /*
                            balletjes[i].vx *= -1;//
                            balletjes[j].vx *= -1;//
                            balletjes[i].vy *= -1;//
                            balletjes[j].vy *= -1;//
                            */
                            //balletjes[i].collidedInvisibleTime = 10;
                            //balletjes[j].collidedInvisibleTime = 20;
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
        private static double Lerp(double a, double b, double weight) {
            double result = a * (1 - weight) + b * weight;

            return result;
        }
            public void Update()
        {
            drawTrigger++;

            if (y < 6)
            {
                score++;
            }
            vy *= 0.998;
            vy += 0.004;
            vx *= 0.998;
            x += vx;
            y += vy;
            if (x >= WindowWidth || x < 0)
            {
                vx *= -1;
                x += vx;
            }
            if (y >= WindowHeight || y < 2)
            {
                vy *= -1;
                y += vy;
            }
        }
        public void Draw()
        {
            //if (drawTrigger % 10 == 0)
            //{
                Console.SetCursorPosition(lastx, lasty);
                Console.Write(" ");
                lastx = (int)x;
                lasty = (int)y;
                Console.SetCursorPosition((int)x, (int)y);
                Console.ForegroundColor = drawColor;
                Console.Write(drawChar);
                Console.ResetColor();
            //}
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
            drawColor = ConsoleColor.White;
            id = idin;
        }

        public override void ChangeVelocity(ConsoleKeyInfo richting)
        {
            switch (richting.Key)
            {
                case ConsoleKey.UpArrow:
                    vy -= 0.3;
                    break;
                case ConsoleKey.DownArrow:
                    vy += 0.3;
                    break;
                case ConsoleKey.LeftArrow:
                    vx -= 0.3;
                    break;
                case ConsoleKey.RightArrow:
                    vx += 0.3;
                    break;
                default:
                    break;
            }
        }
    }
}
