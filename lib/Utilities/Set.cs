using System;
using System.Collections;
namespace Utilities
{
    /// <summary>
    /// Implementuje zbi�r, czyli zestaw niepowtarzalnych obiekt�w.
    /// </summary>
    public class Set
    {
        private Hashtable h = new Hashtable();
        /// <summary>
        /// Zwraca enumerator dla zbioru.
        /// </summary>
        /// <returns>enumerator dla tego zbioru</returns>
        public IEnumerator GetEnumerator()
        {
            return h.Keys.GetEnumerator();
        }
        /// <summary>
        /// Dodaje wskazany obiekt do zbioru.
        /// </summary>
        /// <param name="o">dodawany obiekt</param>
        public void Add(Object o)
        {
            h[o] = null;
        }
        /// <summary>
        /// Zwraca true je�li zbi�r zawiera zadany obiekt.
        /// </summary>
        /// <param name="o">szukany obiekt</param>
        /// <returns>true je�li zbi�r zawiera zadany obiekt</returns>
        public bool Contains(Object o)
        {
            return h.Contains(o);
        }
    }
}
