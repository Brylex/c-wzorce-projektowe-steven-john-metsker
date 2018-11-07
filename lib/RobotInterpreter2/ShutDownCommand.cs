using System;
using Machines;

namespace RobotInterpreter2
{
    /// <summary>
    /// Klasa reprezentuje polecenie wy��czaj�ce urz�dzenie wskazywane
    /// przez dostarczony termin.
    /// </summary>
    public class ShutDownCommand : Command 
    {
        protected Term _term;

        /// <summary>
        /// Konstrukcja polecenia wy��czaj�cego urz�dzenie wskazywane
        /// przez dostarczony termin.
        /// </summary>
        /// <param name="term">termin sprawdzany w wyniku wykonania polecenia;
        /// wskazywana przez przez niego maszyna zostanie wy��czona</param>
        public ShutDownCommand(Term term)
        {
            _term = term;
        }

        /// <summary>
        /// Okre�la maszyn� wskazywan� przez termin i wy��cza j�.
        /// </summary>
        public override void Execute()
        {
            Machine m = _term.Eval();
            m.ShutDown();
        }
    }
}
