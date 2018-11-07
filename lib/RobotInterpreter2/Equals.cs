using System;
using Machines;

namespace RobotInterpreter2
{
    /// <summary>
    /// Odpowiada porównaniu dwóch terminów.
    /// </summary>
    public class Equals : Term 
    {
        protected Term _term1;
        protected Term _term2;
              
        /// <summary>
        /// Konstrukcja terminu pozwalaj¹cego porównaæ dwa dostarczone terminy.
        /// </summary>
        /// <param name="term1">pierwszy termin do porównania</param>
        /// <param name="term2">drugi termin do porównania</param>
        public Equals(Term term1, Term term2)
        {
            this._term1 = term1;
            this._term2 = term2;
        }

        /// <summary>
        /// Zwraca null jeœli terminy potomne odwo³uj¹ siê do ró¿nych maszyn.
        /// </summary>
        /// <returns>null jeœli terminy potomne odwo³uj¹ siê do ró¿nych 
        /// maszyn. W przeciwnym razie zwraca maszynê.</returns>
        public override Machine Eval()
        {
            Machine m1 = _term1.Eval();
            Machine m2 = _term2.Eval();
            bool b = m1.Equals(m2);
            return b ? m1 : null;
        }
    }
}
