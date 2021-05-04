using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGame
{
    interface IMoveable
    {
        void Move();
    }


    abstract class GameElement
    {
        public static Vector worldPos = new Vector(0, 0);
        public static bool playerNeedsUpdate = true;
        //public vector2D position = new vector2D(0, 0);
        protected ConsoleColor backGround = ConsoleColor.Black;
        protected ConsoleColor foreGround = ConsoleColor.White;
        protected ConsoleColor backGroundPlayField = ConsoleColor.DarkGray;
        protected ConsoleColor foreGroundPlayField = ConsoleColor.DarkCyan;
        protected string drawChar = " ";

        public GameElement()
        {
            //position.X = inX;
            //position.Y = inY;
        }
        public virtual void Draw(Vector position)
        {
            Console.BackgroundColor = backGround;
            Console.ForegroundColor = foreGround;
            Console.SetCursorPosition((int)position.X, (int)position.Y);
            Console.Write(drawChar);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void MoveIn2DArray(GameElement[,] myPlayfield, Vector source, Vector dest)
        {
            if (dest.TestRange(0, 19, 0, 19))
            {
                GameElement temp = myPlayfield[(int)source.X, (int)source.Y];
                myPlayfield[(int)dest.X, (int)dest.Y] = temp;
                myPlayfield[(int)source.X, (int)source.Y] = new EmptyTile();
            }
        }
        public virtual void move(Vector position, GameElement[,] myPlayfield, int input)
        {
            switch (input) 
            {
                case 0:
                    GameElement.MoveIn2DArray(myPlayfield, position, position.Up());
                    break;
                case 1:
                    GameElement.MoveIn2DArray(myPlayfield, position, position.Down());
                    break;
                case 2:
                    GameElement.MoveIn2DArray(myPlayfield, position, position.Left());
                    break;
                case 3:
                    GameElement.MoveIn2DArray(myPlayfield, position, position.Right());
                    break;
            }
        }
        public virtual void DoGameLogic(Vector position, GameElement[,] myPlayfield, string input = "")
        {

        }
    }

    class Monster : GameElement, IMoveable
    {
        public Monster() : base()
        {
            backGround = ConsoleColor.DarkYellow;
            foreGround = ConsoleColor.Black;
            drawChar = "M";
        }
        public void Move()
        {
        }
    }
    class RockDestroyer : Monster
    {
        public RockDestroyer() : base()
        {
            backGround = ConsoleColor.Blue;
            foreGround = ConsoleColor.Black;
            drawChar = "D";
        }
        public override void DoGameLogic(Vector position, GameElement[,] myPlayfield, string input)
        {
            if (myPlayfield[(int)position.X - 1, (int)position.Y] is Player)
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
                Console.WriteLine("HITHITHITHIT");
            }
        }

    }
    class Player : GameElement, IMoveable
    {
        public Player() : base()
        {
            backGround = ConsoleColor.Red;
            foreGround = ConsoleColor.Yellow;
            drawChar = "X";
        }
        public override void DoGameLogic(Vector position, GameElement[,] myPlayfield, string input)
        {
            if (playerNeedsUpdate)
            {
                if (input == "UpArrow")
                {
                    if (position.Y > 0)
                    {
                        move(position, myPlayfield, 0);
                        //GameElement temp = myPlayfield[position.X, position.Y];
                        //myPlayfield[position.X, position.Y - 1] = temp;
                        //myPlayfield[position.X, position.Y] = new EmptyTile();
                        //Console.WriteLine("upupupupupupupupupupupupupupupupupupupupupupupupupupupup");
                        //myPlayfield[position.X, position.Y] = new EmptyTile(position.X, position.Y);
                        //myPlayfield[position.X, position.Y - 1] = new Player(position.X, position.Y - 1);
                    }

                }
                if (input == "DownArrow")
                {
                    if (position.Y < 19)
                    {
                        //move(myPlayfield, 1);
                        myPlayfield[(int)position.X, (int)position.Y] = new EmptyTile();
                        myPlayfield[(int)position.X, (int)position.Y + 1] = new Player();
                    }
                }

                if (input == "LeftArrow")
                {
                    if ((int)position.X > 0)
                    {
                        //move(myPlayfield, 2);
                        myPlayfield[(int)position.X, (int)position.Y] = new EmptyTile();
                        myPlayfield[(int)position.X - 1, (int)position.Y] = new Player();
                    }
                }
                if (input == "RightArrow")
                {
                    if (position.X < 19)
                    {
                        //move(myPlayfield, 3);
                        myPlayfield[(int)position.X, (int)position.Y] = new EmptyTile();
                        myPlayfield[(int)position.X + 1, (int)position.Y] = new Player();
                    }
                }
            }
            playerNeedsUpdate = false;
        }
        public void Move()
        {
        }
    }
    class Rock : GameElement
    {
        public Rock() : base()
        {
            backGround = ConsoleColor.Cyan;
            foreGround = ConsoleColor.Black;
            drawChar = "O";
        }

    }
    class EmptyTile : GameElement
    {
        public EmptyTile() : base()
        {
            backGround = ConsoleColor.DarkGray;
            foreGround = ConsoleColor.White;
            drawChar = " ";
        }

    }
}
