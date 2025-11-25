using System;
using System.Collections.Generic;
using System.Text;

namespace tpPile.Class.Generique
{
    internal class Pile<T>
    {
        private List<T> _elements = new List<T>();

        public void Empiler(T item)
        {
            _elements.Add(item);
        }

        public T Depiler()
        {
            if (_elements.Count == 0)
                throw new InvalidOperationException("La pile est vide.");

            T item = _elements[_elements.Count - 1];
            _elements.RemoveAt(_elements.Count - 1);
            return item;
        }

        public T RetirerParIndex(int index)
        {
            if (index < 0 || index >= _elements.Count)
                throw new IndexOutOfRangeException("Index invalide.");

            T item = _elements[index];
            _elements.RemoveAt(index);
            return item;
        }

        public void Afficher()
        {
            Console.WriteLine("Contenu de la pile :");
            for (int i = _elements.Count - 1; i >= 0; i--)
                Console.WriteLine($"[{i}] => {_elements[i]}");
        }
    }

}
