using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGame
{
    class Draw3DObject
    {
        public void DrawParticleToConsole(string c, Particle<string> inParticle)
        {
            string drawString = "";
            Console.ForegroundColor = ColorConvert.RgbToConsole(inParticle.RGB);
            int prevx = (int)(inParticle.PrevPos.X * (inParticle.PrevPos.Z + 5) * 0.03 + 1.0) * 2;
            int prevy = (int)(inParticle.PrevPos.Y * (inParticle.PrevPos.Z + 5) * 0.03 + 1.0);
            int x = (int)(inParticle.Pos.X * (inParticle.Pos.Z + 5) * 0.03 + 1.0) * 2;
            int y = (int)(inParticle.Pos.Y * (inParticle.Pos.Z + 5) * 0.03 + 1.0);
            if (x < Console.WindowWidth && x > 0 && y < Console.WindowHeight && y > 0)
            {
                Console.SetCursorPosition(prevx, prevy);
                Console.WriteLine(drawString);
                Console.SetCursorPosition(x, y);
                Console.WriteLine(drawString);
            }
        }
    }
}
