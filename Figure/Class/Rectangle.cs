using System;
using System.Collections.Generic;
using System.Text;

namespace Figure.Class
{
    internal class Rectangle : ClsFigure
    {
        private int _largeur;
        private int _longueur;
    
        public Rectangle(double x, double y, int largeur, int longueur) : base(new Point(x, y))
        {
            _largeur = largeur;
            _longueur = longueur;
        }
  
        public override void Deplacement(double dx, double dy)
        {
            base.Deplacement(dx, dy);
        }

        public int Largeur
        {
            get { return _largeur; }
            set { _largeur = value; }
        }

        public int Longueur
        {
            get { return _longueur; }
            set { _longueur = value; }
        }

        public override string ToString()
        {
            return base.ToString() + $", Retangle [Largeur : {_largeur}, Longueur : {_longueur}]";
        }
    }
}
