using System;
using System.Collections.Generic;
using System.Text;

namespace Figure.Class
{
    internal class Triangle : ClsFigure
    {
        private int _baseTr;
        private int _hauteur;

        public Triangle(double x, double y, int baseTr, int hauteur) : base(new Point(x, y))
        {
            _baseTr = baseTr;
            _hauteur = hauteur;
        }

        public override void Deplacement(double dx, double dy)
        {
            base.Deplacement(dx, dy);
        }
        public int BaseTr
        {
            get { return _baseTr; }
            set { _baseTr = value; }
        }

        public int Hauteur
        {
            get { return _hauteur; }
            set { _hauteur = value; }
        }

        public override string ToString()
        {
            return base.ToString() + $", Triangle [Base : {_baseTr}, Hauteur : {_hauteur}]";
        }
    }
}
