using System;

namespace exercice.Class
{
    internal class GenerateurMot
    {
        private static Random rnd = new Random();

        private string[] _listeMots = {
            "chat", "chien", "maison", "voiture", "ordinateur",
            "livre", "arbre", "soleil", "lune", "étoile",
            "fleur", "montagne", "rivière", "plage", "forêt",
            "avion", "bateau", "train", "vélo", "ballon",
            "porte", "fenêtre", "chaise", "table", "stylo",
            "musique", "film", "jeu", "cuisine", "sport",
            "nuage", "pluie", "neige", "vent", "orage",
            "amour", "amitie", "joie", "colère", "tristesse"
        };

        private string _motAleatoire;

        public GenerateurMot(int longueurMinimum)
        {
            do{
                _motAleatoire = _listeMots[rnd.Next(_listeMots.Length)];
            } while (_motAleatoire.Length < longueurMinimum);
        }
        public GenerateurMot()
        {
            do{
                _motAleatoire = _listeMots[rnd.Next(_listeMots.Length)];
            } while (_motAleatoire.Length < 4);
        }


        public string MotAleatoire => _motAleatoire;
    }

}
