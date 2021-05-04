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
            //PlayGame();         

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
            PlayAnim();
        }

        private static void PlayAnim()
        {
            int counter = 0;
            Console.Clear();
            Console.CursorVisible = false;
            List<Vector> myPointCloud = new List<Vector>();
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
                counter++;
                Console.CursorVisible = false;
                Console.SetCursorPosition(0, 0);
                Console.WriteLine(counter);
            for (int i = 0; i < myPointCloud.Count; i++)
                {
                    myPointCloud[i].draw(" ");
                    myPointCloud[i].RotateEuler(5);
                    if(myPointCloud[i].Z < 0)
                    {
                        myPointCloud[i].draw(".");
                    }
                    else { 
                        myPointCloud[i].draw("o"); 
                    }
                    
                }
                System.Threading.Thread.Sleep(1);
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
