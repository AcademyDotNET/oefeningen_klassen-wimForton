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
    class vector2D
    {
        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;
        public vector2D(int inX, int inY)
        {
            X = inX; Y = inY;
        }
        public vector2D Up()
        {
            vector2D temp = new vector2D(X,Y);
            temp.Y--;
            return temp;
        }
        public vector2D Down()
        {
            vector2D temp = new vector2D(X, Y);
            temp.Y++;
            return temp;
        }
        public vector2D Left()
        {
            vector2D temp = new vector2D(X, Y);
            temp.X--;
            return temp;
        }
        public vector2D Right()
        {
            vector2D temp = new vector2D(X, Y);
            temp.X++;
            return temp;
        }
    }

    abstract class GameElement
    {
        public static vector2D worldPos = new vector2D(0,0);
        public static bool playerNeedsUpdate = true;
        public vector2D position = new vector2D(0, 0);
        protected ConsoleColor backGround = ConsoleColor.Black;
        protected ConsoleColor foreGround = ConsoleColor.White;
        protected ConsoleColor backGroundPlayField = ConsoleColor.DarkGray;
        protected ConsoleColor foreGroundPlayField = ConsoleColor.DarkCyan;
        protected string drawChar = " ";
        public static void MoveIn2DArray(GameElement[,] myPlayfield, vector2D source, vector2D dest)
        {
            GameElement temp = myPlayfield[source.X, source.Y];
            myPlayfield[dest.X, dest.Y] = temp;
            myPlayfield[source.X, source.Y] = new EmptyTile(source.X, source.Y);
        }
        public GameElement(int inX, int inY)
        {
            position.X = inX;
            position.Y = inY;
        }
        public virtual void Draw()
        {
            Console.BackgroundColor = backGround;
            Console.ForegroundColor = foreGround;
            Console.SetCursorPosition(position.X, position.Y);
            Console.Write(drawChar);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
        public virtual void move(GameElement[,] myPlayfield, int input)
        {
            if (input == 0)
            {
                if (position.Y > 0)
                {
                    //vector2D temp
                    GameElement.MoveIn2DArray(myPlayfield, position, new vector2D(position.X, position.Y--));
                }

            }
            if (input == 1)
            {
                if (position.Y < 19)
                {
                    GameElement.MoveIn2DArray(myPlayfield, position, position.Down());
                }
            }
            if (input == 2)
            {
                if (position.X > 0)
                {
                    GameElement.MoveIn2DArray(myPlayfield, position, position.Left());
                }
            }
            if (input == 3)
            {
                if (position.X < 19)
                {
                    GameElement.MoveIn2DArray(myPlayfield, position, position.Right());
                }
            }
        }
        public virtual void DoGameLogic(GameElement[,] myPlayfield, string input = "")
        {

        }
    }

    class Monster : GameElement, IMoveable
    {
        public Monster(int inX, int inY) : base(inX, inY)
        {
            backGround = ConsoleColor.DarkYellow;
            foreGround = ConsoleColor.Black;
            position.X = inX;
            position.Y = inY;
            drawChar = "M";
        }
        public void Move() 
        { 
        }
    }
    class RockDestroyer : Monster
    {
        public RockDestroyer(int inX, int inY) : base(inX, inY)
        {
            backGround = ConsoleColor.Blue;
            foreGround = ConsoleColor.Black;
            position.X = inX;
            position.Y = inY;
            drawChar = "D";
        }
        public override void DoGameLogic(GameElement[,] myPlayfield, string input)
        {
            if (myPlayfield[position.X - 1, position.Y] is Player)
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
        public Player(int inX, int inY) : base(inX, inY)
        {
            backGround = ConsoleColor.Red;
            foreGround = ConsoleColor.Yellow;
            position.X = inX;
            position.Y = inY;
            drawChar = "X";
        }
        public override void DoGameLogic(GameElement[,] myPlayfield, string input)
        {
            if (playerNeedsUpdate) {
                if (input == "UpArrow")
                {
                    if (position.Y > 0)
                    {
                        //move(myPlayfield, 0);
                        //Console.WriteLine("upupupupupupupupupupupupupupupupupupupupupupupupupupupup");
                        myPlayfield[position.X, position.Y] = new EmptyTile(position.X, position.Y);
                        myPlayfield[position.X, position.Y - 1] = new Player(position.X, position.Y - 1);
                    }

                }
                if (input == "DownArrow")
                {
                    if (position.Y < 19)
                    {
                        //move(myPlayfield, 1);
                        myPlayfield[position.X, position.Y] = new EmptyTile(position.X, position.Y);
                        myPlayfield[position.X, position.Y + 1] = new Player(position.X, position.Y + 1);
                    }
                }

                if (input == "LeftArrow")
                {
                    if (position.X > 0)
                    {
                        //move(myPlayfield, 2);
                        myPlayfield[position.X, position.Y] = new EmptyTile(position.X, position.Y);
                        myPlayfield[position.X - 1, position.Y] = new Player(position.X - 1, position.Y);
                    }
                }
                if (input == "RightArrow")
                {
                    if (position.X < 19)
                    {
                        //move(myPlayfield, 3);
                        myPlayfield[position.X, position.Y] = new EmptyTile(position.X, position.Y);
                        myPlayfield[position.X + 1, position.Y] = new Player(position.X + 1, position.Y);
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
        public Rock(int inX, int inY) : base(inX, inY)
        {
            backGround = ConsoleColor.Cyan;
            foreGround = ConsoleColor.Black;
            position.X = inX;
            position.Y = inY;
            drawChar = "O";
        }

    }
    class EmptyTile : GameElement
    {
        public EmptyTile(int inX, int inY) : base(inX, inY)
        {
            backGround = ConsoleColor.DarkGray;
            foreGround = ConsoleColor.White;
            drawChar = " ";
            position.X = inX;
            position.Y = inY;
        }

    }
}
