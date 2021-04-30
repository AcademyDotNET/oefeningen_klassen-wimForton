using System;

namespace BoardGame
{
    class BoardGameProgram
    {
        static void Main(string[] args)
        {
            PlayGame();
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
                        myPlayfield[i, j] = new Player(i, j);
                    }
                    else if(i > 2)
                    {
                        if (randInt < 20)
                        {
                            myPlayfield[i, j] = new Rock(i, j);
                        }
                        else if (randInt < 50)
                        {
                            myPlayfield[i, j] = new RockDestroyer(i, j);
                        }
                        else if (randInt < 100)
                        {
                            myPlayfield[i, j] = new Monster(i, j);
                        }
                        else
                        {
                            myPlayfield[i, j] = new EmptyTile(i, j);
                        }
                    }
                    else
                    {
                        myPlayfield[i, j] = new EmptyTile(i, j);
                    }

                }
            }
            
            for (int i = 0; i < 20; i++)//collumns
            {
                for (int j = 0; j < 20; j++)//rows
                {
                    myPlayfield[i, j].Draw();
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
                for (int i = 0; i < 20; i++)//collumns
                {
                    for (int j = 0; j < 20; j++)//rows
                    {
                        myPlayfield[i, j].DoGameLogic(myPlayfield, input);//gelukkig wordt de player hier getriggerd voor de destroyer(collumn links is eerst)
                        loopTeller++;
                    }
                }
                for (int i = 0; i < 20; i++)//collumns
                {
                    for (int j = 0; j < 20; j++)//rows
                    {
                        myPlayfield[i, j].Draw();
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
