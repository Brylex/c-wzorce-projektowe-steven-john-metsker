using System;
using Machines;

namespace RobotInterpreter2
{
    /// <summary>
    /// Odpowiada por�wnaniu dw�ch termin�w.
    /// </summary>
    public class Equals : Term 
    {
        protected Term _term1;
        protected Term _term2;
              
        /// <summary>
        /// Konstrukcja terminu pozwalaj�cego por�wna� dwa dostarczone terminy.
        /// </summary>
        /// <param name="term1">pierwszy termin do por�wnania</param>
        /// <param name="term2">drugi termin do por�wnania</param>
        public Equals(Term term1, Term term2)
        {
            this._term1 = term1;
            this._term2 = term2;
        }

        /// <summary>
        /// Zwraca null je�li terminy potomne odwo�uj� si� do r�nych maszyn.
        /// </summary>
        /// <returns>null je�li terminy potomne odwo�uj� si� do r�nych 
        /// maszyn. W przeciwnym razie zwraca maszyn�.</returns>
        public override Machine Eval()
        {
            Machine m1 = _term1.Eval();
            Machine m2 = _term2.Eval();
            bool b = m1.Equals(m2);
            return b ? m1 : null;
        }
    }
}
