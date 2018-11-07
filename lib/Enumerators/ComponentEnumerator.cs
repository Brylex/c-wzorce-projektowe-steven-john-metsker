using System;
using System.Collections;
using Utilities;
namespace Enumerators
{
    /// <summary>
    /// Abstrakcyjna nadklasa dla enumerator�w, definiuj�ca metody do 
    /// przechodzenia po li�ciach i kompozytach w ramach drzewa kompozyt�w.
    /// </summary>
    public abstract class ComponentEnumerator : IEnumerator
    {
        protected Object _head;
        protected Set _visited;
        protected Object _current;
        protected bool _returnInterior = true;

        /// <summary>
        /// Zwraca bie��cy w�ze�.
        /// </summary>
        public Object Current 
        {
            get
            {
                return _current;
            }
        }

        /// <summary>
        /// Okre�la, czy wewn�trzne w�z�y powinny wyst�powa� iteracyjnie.
        /// </summary>
        public bool ReturnInterior
        {
            get
            {
                return _returnInterior;
            }
            set 
            {
                _returnInterior = value;
            }
        }
        /// <summary>
        /// Tworzy enumerator nad w�z�em w ramach kompozytu.
        /// </summary>
        /// <param name="node">w�ze� do przechodzenia</param>
        /// <param name="visited">zbi�r do zapisywania odwiedzonych w�z��w</param>
        public ComponentEnumerator(Object head, Set visited)
        {
            _head = head;
            _visited = visited;
        }

        /// <summary>
        /// Zwraca bie��c� g��boko�� iteracji.
        /// </summary>
        /// <returns>bie��c� g��boko�� iteracji (tzn. ilo�� w�z��w nad bie��cym)</returns>
        public abstract int Depth();

        /// <summary>
        /// Przesuni�cie enumeratora.
        /// </summary>
        /// <returns>true je�li dost�pny jest kolejny w�ze�</returns>
        public abstract bool MoveNext();

        /// <summary>
        /// Operacja nieobs�ugiwana.
        /// </summary>
        public void Reset() 
        { 
            throw new InvalidOperationException("Funkcja Reset() nie jest jeszcze obs�ugiwana!"); 
        }
    }
}
