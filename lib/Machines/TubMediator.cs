using System;
using System.Collections;

namespace Machines
{
    /// <summary>
    /// Klasa zarz¹dzaj¹ca relacj¹ pojemników i maszyn.
    /// </summary>
    public class TubMediator 
    {        
        public static readonly TubMediator SINGLETON = new TubMediator();

        private Hashtable _tubMachine = new Hashtable();
        /// <summary>
        /// Zwraca maszynê, przy której znajduje siê zadany pojemnik.
        /// </summary>
        /// <param name="t">pojemnik</param>
        /// <returns>maszynê, przy której znajduje siê pojemnik</returns>
        public Machine GetMachine(Tub t)
        {
            return (Machine) _tubMachine[t];
        }
        /// <summary>
        /// Zwraca listê pojemników przy maszynie.
        /// </summary>
        /// <param name="m">maszyna</param>
        /// <returns>lista pojemników przy maszynie</returns>
        public IList GetTubs(Machine m)
        {
            ArrayList al = new ArrayList();
            IDictionaryEnumerator e = _tubMachine.GetEnumerator();
            while (e.MoveNext()) 
            {
                if (e.Value.Equals(m))
                {
                    al.Add(e.Key);
                }
            }
            return al;
        }
        /// <summary>
        /// Ustawia podan¹ maszynê jako lokalizacjê podanego pojemnika.
        /// </summary>
        /// <param name="t">pojemnik</param>
        /// <param name="m">maszyna</param>
        public void Set(Tub t, Machine m)
        {
            _tubMachine[t] = m;
        }
    }
}
	 