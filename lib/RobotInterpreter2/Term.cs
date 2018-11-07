using System;
using Machines;

namespace RobotInterpreter2
{
    /// <summary>
    /// Klasa reprezentuj�ca termin - na og� maszyn� lub zmienn� wskazuj�c�
    /// na maszyn�.
    /// </summary>
    public abstract class Term 
    {
        /// <summary>
        /// Sprawdzenie terminu.
        /// </summary>
        /// <returns>sprawdzenie tego terminu</returns>
        public abstract Machine Eval();
    }
}
