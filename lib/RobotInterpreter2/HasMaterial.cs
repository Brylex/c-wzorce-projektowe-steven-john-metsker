using System;
using Machines;

namespace RobotInterpreter2
{
    /// <summary>
    /// Reprezentuje stan, w którym na maszynie (dostêpnej za poœrednictwem
    /// terminu) znajduje siê materia³.
    /// </summary>
    public class HasMaterial : Term 
    {
        protected Term _term;

        /// <summary>
        /// Konstrukcja terminu reprezentuj¹cego funkcjê boolowsk¹ okreœlaj¹c¹,
        /// czy termin odwo³uje siê do maszyny posiadaj¹cej materia³.
        /// </summary>
        /// <param name="term">termin do sprawdzenia (na ogó³ zmienna lub maszyna)</param>
        public HasMaterial(Term term)
        {
            _term = term;
        }

        /// <summary>
        /// Zwraca null jeœli termin potomny dotyczy maszyny nieposiadaj¹cej
        /// materia³u.
        /// </summary>
        /// <returns>null jeœli termin potomny dotyczy maszyny nieposiadaj¹cej
        /// materia³u. W przeciwnym razie zwraca maszynê.</returns>
        public override Machine Eval()
        {
            Machine m = _term.Eval();
            return m.HasMaterial() ? m : null;
        }
    }
}
