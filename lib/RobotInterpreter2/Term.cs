using System;
using Machines;

namespace RobotInterpreter2
{
    /// <summary>
    /// Klasa reprezentuj¹ca termin - na ogó³ maszynê lub zmienn¹ wskazuj¹c¹
    /// na maszynê.
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
