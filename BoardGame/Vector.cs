using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace BoardGame
{
    class Vector
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public int Dimensions { get; set; }
        public Vector(double inX, double inY, double inZ)
        {
            X = inX; Y = inY; Z = inZ;
            Dimensions = 3;
        }
        public Vector(double inX, double inY)
        {
            X = inX; Y = inY;
            Dimensions = 2;
        }

        public static Vector operator +(Vector d1, Vector d2)
        {
            //vector2D result = new vector2D();
            //T v1 = 0.0;
            Vector result = new Vector(0.0, 0.0);
            if (d1.Dimensions == 3 || d2.Dimensions == 3) 
            {
                result = new Vector(0.0, 0.0, 0.0);
                result.X = d1.X + d2.X;
                result.Y = d1.Y + d2.Y;
                result.Z = d1.Z + d2.Z;
            }
            else
            {
                result = new Vector(0.0, 0.0);
                result.X = d1.X + d2.X;
                result.Y = d1.Y + d2.Y;
            }

            return result;
        }
        public static Vector RotateEuler(Vector inVector, double angle)
        {
            Vector result;
            double resultX = inVector.X * Math.Cos(angle) - inVector.Y * Math.Sin(angle);
            double resultY = inVector.X * Math.Sin(angle) + inVector.Y * Math.Cos(angle);
            result = new Vector(resultX, resultY);
            return result;
        }
        public void RotateEuler(double angle)
        {
            double rad = angle * Math.PI / 180;
            double tempX = X;
            X = X * Math.Cos(rad) - Z * Math.Sin(rad);
            Z = tempX * Math.Sin(rad) + Z * Math.Cos(rad);
        }
        public static Vector RotateEuler(Vector inVector, double angleX, double angleY, double angleZ)
        {
            Vector result;
            double resultX = inVector.X * Math.Cos(angleX) - inVector.Y * Math.Sin(angleX);
            double resultY = inVector.X * Math.Sin(angleX) + inVector.Y * Math.Cos(angleX);
            result = new Vector(resultX, resultY);
            return result;
        }
        public bool TestRange(double minX, double maxX, double minY, double maxY)
        {
            bool result = false;
            if (X >= minX && X <= maxX && Y >= minY && Y <= maxY)
            {
                result = true;
            }
            return result;
        }

        public Vector Up()
        {
            Vector temp = new Vector(X, Y);
            temp.Y--;
            return temp;
        }
        public Vector Down()
        {
            Vector temp = new Vector(X, Y);
            temp.Y++;
            return temp;
        }
        public Vector Left()
        {
            Vector temp = new Vector(X, Y);
            temp.X--;
            return temp;
        }
        public Vector Right()
        {
            Vector temp = new Vector(X, Y);
            temp.X++;
            return temp;
        }
        public override bool Equals(object o)
        {
            bool gelijk = true;
            Console.WriteLine(o.GetType());
            if (GetType() != o.GetType())
            {
                gelijk = false;
            }
            else
            {
                Vector temp = o as Vector;
                if (X == temp.X && Y == temp.Y)
                    gelijk = true;
                else gelijk = false;
            }
            return gelijk;
        }
        public void draw(string c)
        {
            int x = (int)(X * ((Z + 5) * 0.03 + 1.0) * 2 + 35);
            int y = (int)(Y * ((Z + 5) * 0.03 + 1.0) + 15);
            Console.SetCursorPosition(x, y);
            Console.WriteLine(c);
        }
    }
}
