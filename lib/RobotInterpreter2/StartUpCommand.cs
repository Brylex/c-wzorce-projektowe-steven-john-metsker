using System;
using Machines;

namespace RobotInterpreter2
{
    /// <summary>
    /// Klasa reprezentuje polecenie w��czaj�ce urz�dzenie wskazywane
    /// przez dostarczony termin.
    /// </summary>
    public class StartUpCommand : Command 
    {
        protected Term _term;

        /// <summary>
        /// Konstrukcja polecenia w��czaj�cego urz�dzenie wskazywane
        /// przez dostarczony termin.
        /// </summary>
        /// <param name="term">termin sprawdzany w wyniku wykonania polecenia;
        /// wskazywana przez przez niego maszyna zostanie w��czona</param>
        public StartUpCommand(Term term)
        {
            _term = term;
        }

        /// <summary>
        /// Okre�la maszyn� wskazywan� przez termin i w��cza j�.
        /// </summary>
        public override void Execute()
        {
            Machine m = _term.Eval();
            m.StartUp();
        }
    }
}
