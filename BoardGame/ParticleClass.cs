using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGame
{
    interface I3DObject
    {
        //public Vector Pos;
    }
    class Particle<T>
    {
        private T particleObject;
        private Vector particlePosition;
        private Vector particlePrevPosition;
        private Vector particleRotation;
        private Vector particleVelocity;
        private Vector particleRGBColor;
        private double particleSize;
        private double particleMass;
        private Vector particleDrag;
        private double particleAge;
        private double particleLifeSpan;
        private bool particleAlive;
        public Particle(T inObject, Vector inPos, Vector inRot = null, Vector inVel = null, Vector inRGB = null, double inSize = 1.0, double inMass = 1.0, double inDrag = 0.99, double inSpan = 2.0)
        {
            particleObject = inObject;
            Pos = inPos;
            PrevPos = inPos;
            //Rot = inRot;
            Rot = inRot != null ? inRot : new Vector(0, 0, 0);
            Vel = inVel != null ? inVel : new Vector(0, 0, 0);
            RGB = inRGB != null ? inRGB : new Vector(1, 1, 1);
            Size = inSize;
            Mass = inMass;
            Drag = new Vector(inDrag, inDrag, inDrag);
            Age = 0.0;
            Lifespan = inSpan;
        }
        public T Object
        {
            get
            {
                return particleObject;
            }
            set
            {
                particleObject = value;
            }
        }
        public Vector PrevPos
        {
            get
            {
                return particlePrevPosition;
            }
            set
            {
                particlePrevPosition = value;
            }
        }
        public Vector Pos
        {
            get
            {
                return particlePosition;
            }
            set
            {
                particlePosition = value;
            }
        }
        public Vector Rot
        {
            get
            {
                return particleRotation;
            }
            set
            {
                particleRotation = value;
            }
        }
        public Vector Vel
        {
            get
            {
                return particleVelocity;
            }
            set
            {
                particleVelocity = value;
            }
        }
        public Vector RGB
        {
            get
            {
                return particleRGBColor;
            }
            set
            {
                particleRGBColor = value;
            }
        }
        public Vector Drag
        {
            get
            {
                return particleDrag;
            }
            set
            {
                particleDrag = value;
            }
        }
        public double Mass
        {
            get
            {
                return particleMass;
            }
            set
            {
                particleMass = value;
            }
        }
        public double Size
        {
            get
            {
                return particleSize;
            }
            set
            {
                particleSize = value;
            }
        }
        public double Age
        {
            get
            {
                return particleAge;
            }
            set
            {
                particleAge = value;
            }
        }
        public double Lifespan
        {
            get
            {
                return particleLifeSpan;
            }
            set
            {
                particleLifeSpan = value;
            }
        }
    }
}
