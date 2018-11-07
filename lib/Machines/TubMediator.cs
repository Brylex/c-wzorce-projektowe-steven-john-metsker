using System;
using System.Collections;

namespace Machines
{
    /// <summary>
    /// Klasa zarz�dzaj�ca relacj� pojemnik�w i maszyn.
    /// </summary>
    public class TubMediator 
    {        
        public static readonly TubMediator SINGLETON = new TubMediator();

        private Hashtable _tubMachine = new Hashtable();
        /// <summary>
        /// Zwraca maszyn�, przy kt�rej znajduje si� zadany pojemnik.
        /// </summary>
        /// <param name="t">pojemnik</param>
        /// <returns>maszyn�, przy kt�rej znajduje si� pojemnik</returns>
        public Machine GetMachine(Tub t)
        {
            return (Machine) _tubMachine[t];
        }
        /// <summary>
        /// Zwraca list� pojemnik�w przy maszynie.
        /// </summary>
        /// <param name="m">maszyna</param>
        /// <returns>lista pojemnik�w przy maszynie</returns>
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
        /// Ustawia podan� maszyn� jako lokalizacj� podanego pojemnika.
        /// </summary>
        /// <param name="t">pojemnik</param>
        /// <param name="m">maszyna</param>
        public void Set(Tub t, Machine m)
        {
            _tubMachine[t] = m;
        }
    }
}
	 