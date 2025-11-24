using System;
using System.Collections.Generic;
using System.Text;

namespace exercice.Class
{   
    internal class Pendu
    {
        private int _nbEssais;
        private GenerateurMot _mot;
        private char[] _listMotTrouver;
 
        public Pendu()
        {
            _nbEssais = 10;
            _mot = new GenerateurMot();

            _listMotTrouver = new char[_mot.MotAleatoire.Length];
            for (int i = 0; i < _mot.MotAleatoire.Length; i++)
            {
                _listMotTrouver[i] = '*';
            }
        }
        public Pendu(int nbEssais, int longueurMinimum)
        {
            _nbEssais = nbEssais;
            _mot = new GenerateurMot(longueurMinimum);
        }

        public void testChar(string saisi)
        {
            if(saisi == null){
                Console.WriteLine("La saisi ne doit pas être vide");
            }

            if (testWin(saisi)){
                Console.WriteLine("Le mot etait bien " + _mot.MotAleatoire + " il vous rester " + _nbEssais + " tentative");
            }
            else
            {

            }
        }

        public void genererMasque(string saisi)
        {
            
        }

        public bool testWin(string saisie)
        {
            return _mot.Equals(saisie);
        }
    }
}
