using System;
using System.Collections.Generic;
using System.Text;

namespace exercice.Class
{
    internal class Chaise
    {
        private int _nbPied;
        private string _materieaux;
        private string _couleur;

        public Chaise(int  nbPied, string materieaux, string couleur)
        {
            _nbPied = nbPied;
            _materieaux = materieaux;
           _couleur = couleur;
        }

        public Chaise()
        {
            _nbPied = 4;
            _materieaux = "Bois";
            _couleur = "Marron";
        }

        public void afficher()
        {
            Console.WriteLine("Je suis une Chaise, avec "+_nbPied+" pieds en "+_materieaux+" et de couleur "+_couleur);
        }
    }
}
