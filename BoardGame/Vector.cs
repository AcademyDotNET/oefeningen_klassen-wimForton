using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGame
{
    class vector
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public int Dimensions { get; set; }
        public vector(double inX, double inY, double inZ)
        {
            X = inX; Y = inY; Z = inZ;
            Dimensions = 3;
        }
        public vector(double inX, double inY)
        {
            X = inX; Y = inY;
            Dimensions = 2;
        }

        public static vector operator +(vector d1, vector d2)
        {
            //vector2D result = new vector2D();
            //T v1 = 0.0;
            vector result = new vector(0.0, 0.0);
            if (d1.Dimensions == 3 || d2.Dimensions == 3) 
            {
                result = new vector(0.0, 0.0, 0.0);
                result.X = d1.X + d2.X;
                result.Y = d1.Y + d2.Y;
                result.Z = d1.Z + d2.Z;
            }
            else
            {
                result = new vector(0.0, 0.0);
                result.X = d1.X + d2.X;
                result.Y = d1.Y + d2.Y;
            }

            return result;
        }
        public static vector RotateEuler(vector inVector, double angle)
        {
            vector result;
            double resultX = inVector.X * Math.Cos(angle) - inVector.Y * Math.Sin(angle);
            double resultY = inVector.X * Math.Sin(angle) + inVector.Y * Math.Cos(angle);
            result = new vector(resultX, resultY);
            return result;
        } 
        public static vector RotateEuler(vector inVector, double angleX, double angleY, double angleZ)
        {
            vector result;
            double resultX = inVector.X * Math.Cos(angleX) - inVector.Y * Math.Sin(angleX);
            double resultY = inVector.X * Math.Sin(angleX) + inVector.Y * Math.Cos(angleX);
            result = new vector(resultX, resultY);
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
        public vector Up()
        {
            vector temp = new vector(X, Y);
            temp.Y--;
            return temp;
        }
        public vector Down()
        {
            vector temp = new vector(X, Y);
            temp.Y++;
            return temp;
        }
        public vector Left()
        {
            vector temp = new vector(X, Y);
            temp.X--;
            return temp;
        }
        public vector Right()
        {
            vector temp = new vector(X, Y);
            temp.X++;
            return temp;
        }
    }
}
