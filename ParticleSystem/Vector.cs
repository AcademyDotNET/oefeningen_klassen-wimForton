using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ParticleSystem
{
    /*interface Vector
    {
        public void draw(string c, ConsoleColor colr);
    }*/
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
        public void Set(double inX, double inY, double inZ)
        {
            X = inX; Y = inY; Z = inZ;
            Dimensions = 3;
        }
        public static Vector setNew(double inX, double inY, double inZ)
        {
            return new Vector(inX, inY, inZ);
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
        public static Vector operator *(Vector d1, Vector d2)
        {
            //vector2D result = new vector2D();
            //T v1 = 0.0;
            Vector result = new Vector(0.0, 0.0);
            if (d1.Dimensions == 3 || d2.Dimensions == 3)
            {
                result = new Vector(0.0, 0.0, 0.0);
                result.X = d1.X * d2.X;
                result.Y = d1.Y * d2.Y;
                result.Z = d1.Z * d2.Z;
            }
            else
            {
                result = new Vector(0.0, 0.0);
                result.X = d1.X * d2.X;
                result.Y = d1.Y * d2.Y;
            }

            return result;
        }
        public static Vector operator *(Vector d1, double d2)
        {
            //vector2D result = new vector2D();
            //T v1 = 0.0;
            Vector result = new Vector(0.0, 0.0);
            if (d1.Dimensions == 3)
            {
                result = new Vector(0.0, 0.0, 0.0);
                result.X = d1.X * d2;
                result.Y = d1.Y * d2;
                result.Z = d1.Z * d2;
            }
            else
            {
                result = new Vector(0.0, 0.0);
                result.X = d1.X * d2;
                result.Y = d1.Y * d2;
            }

            return result;
        }
        //public bool CompareTo(object obj)
        //{
        //    Vector temp = (Vector)obj; //Zetten de parameter om naar land
        //    bool result = false; 
        //    if (length(this) > length(temp)) return false;
        //    //if (Oppervlakte < temp.Oppervlakte) return -1;
        //    //if (this.Inwoners > temp.Inwoners) return 1;
        //    //if (this.Inwoners < temp.Inwoners) return -1;

        //    return result;
        //}
        public static double length(Vector v1)
        {
            double result = Math.Sqrt(Math.Pow(v1.X, 2.0) + Math.Pow(v1.Y, 2.0) + Math.Pow(v1.Z, 2.0));
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
        public static Vector GetEulerRotation(Vector inVector, double angleX, double angleY, double angleZ, string rotationOrder)
        {
            Vector result;
            double resultX = inVector.X;
            double resultY = inVector.Y;
            double resultZ = inVector.Z;
            for (int i = 0; i < 3; i++) {
                char axis = rotationOrder[i];
                double calcX = 0.0;
                double calcY = 0.0;
                double calcAngle = 0.0;

                if (axis == 'x') { calcX = resultY; calcY = resultZ; calcAngle = angleX; }
                if (axis == 'y') { calcX = resultX; calcY = resultZ; calcAngle = angleY; }
                if (axis == 'z') { calcX = resultX; calcY = resultY; calcAngle = angleZ; }

                if (axis == 'x')
                {
                    resultY = calcX * Math.Cos(calcAngle) - calcY * Math.Sin(calcAngle);
                    resultZ = calcX * Math.Sin(calcAngle) + calcY * Math.Cos(calcAngle);
                }
                if (axis == 'y')
                {
                    resultX = calcX * Math.Cos(calcAngle) - calcY * Math.Sin(calcAngle);
                    resultZ = calcX * Math.Sin(calcAngle) + calcY * Math.Cos(calcAngle);
                }
                if (axis == 'z')
                {
                    resultX = calcX * Math.Cos(calcAngle) - calcY * Math.Sin(calcAngle);
                    resultY = calcX * Math.Sin(calcAngle) + calcY * Math.Cos(calcAngle);
                }

            }
            result = new Vector(resultX, resultY, resultZ);
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
        public override string ToString()
        {
            string vector = $"{X},{Y},{Z}";
            return vector;
        }
    }
}
