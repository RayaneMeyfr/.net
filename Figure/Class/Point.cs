using System;
using System.Collections.Generic;
using System.Text;

namespace Figure.Class
{
    internal class Point
    {
        private double posX;
        private double posY;

        public Point(double posX, double posY)
        {
            this.posX = posX;
            this.posY = posY;
        }

        public double PosX
        {
            get { return posX; }
            set { posX = value; }
        }

        public double PosY
        {
            get { return posY; }
            set { posY = value; }
        }

        public override string ToString()
        {
            return $"Point [X = {PosX}, Y = {PosY}]";
        }
    }
}
