using System;
using System.Collections.Generic;
using System.Text;

namespace Figure.Class
{
    internal class Carre : ClsFigure
    {
        private int _cote;

        public Carre(double x, double y, int cote) : base(new Point(x, y))
        {
            _cote = cote;
        }

        public override void Deplacement(double dx, double dy)
        {
            base.Deplacement(dx, dy);
        }

        public int Cote
        {
            get { return _cote; }
            set { _cote = value; }
        }

        public override string ToString()
        {
            return base.ToString() + $", Carrée [Côté : {_cote}]";
        }
    }
}
