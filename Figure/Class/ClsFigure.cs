using Figure.Class.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Figure.Class
{
    internal abstract class ClsFigure : Ideplacable
    {
        protected Point origine;

        protected ClsFigure(Point origine)
        {
            this.origine = origine;
        }

        public virtual void Deplacement(double dx, double dy)
        {
 
            origine.PosX += dx;
            origine.PosY += dy;
        }

        public override string ToString()
        {
            return $"Origine : {origine}";
        }
    }
}
