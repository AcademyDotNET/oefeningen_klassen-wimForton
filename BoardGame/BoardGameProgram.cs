using System;
using System.Collections;
using System.Collections.Generic;
//using Microsoft.Xna.Framework.Input;

namespace BoardGame
{
    class BoardGameProgram
    {

        static void Main(string[] args)
        {
            PlayGame();         

            //Vector vecA = new Vector(3,5);
            //Vector vecB = new Vector(3,5);

            //Console.WriteLine("vergelijking 1");
            //Console.WriteLine(vecA.Equals(vecB));
            //Console.WriteLine(vecA == vecB);
            //Console.WriteLine("------------------------");
            //Console.WriteLine("optelling");
            //vecA = vecA + vecB;
            //Console.WriteLine($"X = {vecA.X}, Y = {vecA.Y}");
            //Console.WriteLine("------------------------");
            //Console.WriteLine("vergelijking 2");
            //Console.WriteLine(vecA.Equals(vecB));
            //Console.WriteLine(vecA == vecB);
            //Console.WriteLine("------------------------");

            //Console.WriteLine(test<int>(5));
            //Console.WriteLine(test2<string>("5"));
            //Console.WriteLine("any key to start anim");
            //Console.ReadLine();
            //PlayAnim();
        }

        private static void PlayAnim()
        {
            int counter = 0;
            double rotation = 0;
            Console.Clear();
            Console.CursorVisible = false;
            List<Vector> myPointCloud = new List<Vector>();
            Matrix myMatrix = new Matrix();
            ConsoleColor tempColor = ConsoleColor.White;
           
            myPointCloud.Add(new Vector(-5.0, 5.0, 5.0));
            myPointCloud.Add(new Vector(5.0, 5.0, 5.0));
            myPointCloud.Add(new Vector(-5.0, -5.0, 5.0));
            myPointCloud.Add(new Vector(5.0, -5.0, 5.0));
            myPointCloud.Add(new Vector(-5.0, 5.0, -5.0));
            myPointCloud.Add(new Vector(5.0, 5.0, -5.0));
            myPointCloud.Add(new Vector(-5.0, -5.0, -5.0));
            myPointCloud.Add(new Vector(5.0, -5.0, -5.0));
            while (true)
            {
                Console.CursorVisible = false;
                if (counter == 1999)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Clear();
                }
                if (counter > 2000) myMatrix.MatrixDraw();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.SetCursorPosition(0, 0);
                Console.WriteLine(counter);
                Console.SetCursorPosition(0, 20);
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                //if (counter % 2 == 1) System.Threading.Thread.Sleep(1);
                for (int i = 0; i < myPointCloud.Count; i++)
                {
                    Vector temp = Vector.GetEulerRotation(myPointCloud[i], rotation * 0.333, rotation * 0.5, rotation, "zxy");
                    temp.draw(" ", tempColor);
                }
                counter++;
                if (counter % 500 < 250)
                {
                    rotation += 0.08;
                }
                else
                {
                    rotation += 0.01;
                }
                for (int i = 0; i < myPointCloud.Count; i++)
                {
                    Vector temp = Vector.GetEulerRotation(myPointCloud[i], rotation * 0.333, rotation * 0.5, rotation, "zxy");
                    if(temp.Z < 0)
                    {
                        if (counter % 500 < 250)
                        {
                            //Console.ForegroundColor = ConsoleColor.DarkCyan;
                            temp.draw(".", ConsoleColor.DarkCyan);
                        }
                        else
                        {
                            //Console.ForegroundColor = ConsoleColor.DarkYellow;
                            temp.draw("*", ConsoleColor.DarkYellow);
                        }
                        //Console.ForegroundColor = ConsoleColor.DarkCyan;
                        
                        if (counter % 500 < 250)
                        {
                            tempColor = ConsoleColor.Cyan;
                        }
                        else
                        {
                            tempColor = ConsoleColor.Yellow;
                        }
                    }
                    else {
                        if (counter % 500 < 250)
                        {
                            temp.draw("o", tempColor);
                        }
                        else if(counter % 20 < 10)
                        {
                            temp.draw("X", tempColor);
                        }
                        else
                        {
                            temp.draw(".", tempColor);
                        } 
                    }

                }
                if(counter%2 == 1) System.Threading.Thread.Sleep(1);
            //Console.ReadLine();
            }
        }

        public static T test<T>(T p)
        {
            T bla = p;
            return bla;
        }
        
        public static datatype test2<datatype>(datatype p)
        {
            datatype bla  = p;
            return bla;
        }

        private static void PlayGame()
        {
            Console.CursorVisible = false;
            GameElement[,] myPlayfield = new GameElement[20,20];
            Random myRandom = new Random();
            int loopTeller = 0;

            for(int i = 0; i < 20; i++)//collumns
            {
                for (int j = 0; j < 20; j++)//rows
                {
                    int randInt = myRandom.Next(0, 400);
                    if(i == 0 && j == 10)
                    {
                        myPlayfield[i, j] = new Player();
                    }
                    else if(i > 2)
                    {
                        if (randInt < 20)
                        {
                            myPlayfield[i, j] = new Rock();
                        }
                        else if (randInt < 50)
                        {
                            myPlayfield[i, j] = new RockDestroyer();
                        }
                        else if (randInt < 100)
                        {
                            myPlayfield[i, j] = new Monster();
                        }
                        else
                        {
                            myPlayfield[i, j] = new EmptyTile();
                        }
                    }
                    else
                    {
                        myPlayfield[i, j] = new EmptyTile();
                    }

                }
            }

            for (int collumn = 0; collumn < 20; collumn++)//collumns
            {
                for (int row = 0; row < 20; row++)//rows
                {
                    Vector position = new Vector(collumn, row);
                    myPlayfield[collumn, row].Draw(position);
                }
            }
            //Player myPlayer = new Player(1,10);
            //myPlayer.Draw();
            string input = "";
            while(true)
            {
                GameElement.playerNeedsUpdate = true;
                input = Console.ReadKey().Key.ToString();
                //string test = Console.Read().ToString();
                for (int collumn = 0; collumn < 20; collumn++)//collumns
                {
                    for (int row = 0; row < 20; row++)//rows
                    {
                        Vector position = new Vector(collumn, row);
                        myPlayfield[collumn, row].DoGameLogic(position, myPlayfield, input);//gelukkig wordt de player hier getriggerd voor de destroyer(collumn links is eerst)
                        loopTeller++;
                    }
                }
                for (int collumn = 0; collumn < 20; collumn++)//collumns
                {
                    for (int row = 0; row < 20; row++)//rows
                    {
                        Vector position = new Vector(collumn, row);
                        myPlayfield[collumn, row].Draw(position);
                    }
                }

                //myPlayer.Update(input);
                //myPlayer.Draw();
                //myPlayfield[myPlayer.position.X, myPlayer.position.Y] = new EmptyTile(myPlayer.position.X, myPlayer.position.Y);
                //loopTeller++;
                Console.SetCursorPosition(22, 0);
                Console.WriteLine(loopTeller);
                Console.SetCursorPosition(22, 1);
                Console.WriteLine(input);
            } 
        }
        
    }
}
