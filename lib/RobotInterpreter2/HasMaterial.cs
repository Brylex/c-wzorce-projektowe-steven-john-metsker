using System;
using Machines;

namespace RobotInterpreter2
{
    /// <summary>
    /// Reprezentuje stan, w kt�rym na maszynie (dost�pnej za po�rednictwem
    /// terminu) znajduje si� materia�.
    /// </summary>
    public class HasMaterial : Term 
    {
        protected Term _term;

        /// <summary>
        /// Konstrukcja terminu reprezentuj�cego funkcj� boolowsk� okre�laj�c�,
        /// czy termin odwo�uje si� do maszyny posiadaj�cej materia�.
        /// </summary>
        /// <param name="term">termin do sprawdzenia (na og� zmienna lub maszyna)</param>
        public HasMaterial(Term term)
        {
            _term = term;
        }

        /// <summary>
        /// Zwraca null je�li termin potomny dotyczy maszyny nieposiadaj�cej
        /// materia�u.
        /// </summary>
        /// <returns>null je�li termin potomny dotyczy maszyny nieposiadaj�cej
        /// materia�u. W przeciwnym razie zwraca maszyn�.</returns>
        public override Machine Eval()
        {
            Machine m = _term.Eval();
            return m.HasMaterial() ? m : null;
        }
    }
}
