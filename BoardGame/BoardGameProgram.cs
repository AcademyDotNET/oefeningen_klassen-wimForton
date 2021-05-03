using System;

namespace BoardGame
{
    class BoardGameProgram
    {

        static void Main(string[] args)
        {
            PlayGame();         

            vector vecA = new vector(3,5);
            vector vecB = new vector(3,5);
            vecA = vecA + vecB;
            Console.WriteLine($"X = {vecA.X}, Y = {vecA.Y}");

            Console.WriteLine(test<int>(5));
            Console.WriteLine(test2<int>(5));
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
                    vector position = new vector(collumn, row);
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
                        vector position = new vector(collumn, row);
                        myPlayfield[collumn, row].DoGameLogic(position, myPlayfield, input);//gelukkig wordt de player hier getriggerd voor de destroyer(collumn links is eerst)
                        loopTeller++;
                    }
                }
                for (int collumn = 0; collumn < 20; collumn++)//collumns
                {
                    for (int row = 0; row < 20; row++)//rows
                    {
                        vector position = new vector(collumn, row);
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
