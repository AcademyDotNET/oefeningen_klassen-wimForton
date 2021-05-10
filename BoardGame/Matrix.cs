using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGame
{
    class Matrix
    {
        protected Random rangen = new Random();
        protected int[] currentPlaces = new int[50];
        protected char[] currentChars = new char[50];
        //protected int colorIndex = 0;
        public Matrix()
        {
            for (int i = 0; i < currentPlaces.Length; i++)
            {
                currentPlaces[i] = 50;
            }
        }
        public void MatrixDraw()
        {
            
            //Console.ForegroundColor = ConsoleColor.Green;



            Random rangeColor = new Random();
            Random rangeTrigger = new Random();
            //colorIndex = rangeColor.Next(0, 14);
            char teken = '0';
            for (int lr = 0; lr < 40; lr++)
            {
                int cursorposX = lr;
                if (cursorposX > 30) cursorposX += 80;
                if (rangeTrigger.Next(0, 20) == 1)
                {

                    Console.SetCursorPosition(cursorposX, currentPlaces[lr] % 30);
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write(teken);
                    currentPlaces[lr] += 1;
                    //////////zwarte tekens
                    int blackposition = (currentPlaces[lr] % 30) - 8;
                    if (blackposition < 0) blackposition = 30 + blackposition;
                    Console.SetCursorPosition(cursorposX, blackposition);
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(" ");
                    ////end zwarte tekens, nieuw teken in magent
                    teken = Convert.ToChar(rangen.Next(62, 400));
                    currentChars[lr] = teken;
                    Console.SetCursorPosition(cursorposX, currentPlaces[lr] % 30);
                    Console.ForegroundColor = ConsoleColor.White;// (ConsoleColor)colorIndex; ConsoleColor.White;
                    Console.Write(teken);
                }
                else
                {
                    teken = currentChars[lr];
                    Console.SetCursorPosition(cursorposX, currentPlaces[lr] % 30);
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;// (ConsoleColor)colorIndex; ConsoleColor.White;
                    Console.Write(teken);
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            //System.Threading.Thread.Sleep(1);

        }
    }
}
