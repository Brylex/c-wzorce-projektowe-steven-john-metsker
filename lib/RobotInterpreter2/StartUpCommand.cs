using System;
using Machines;

namespace RobotInterpreter2
{
    /// <summary>
    /// Klasa reprezentuje polecenie w³¹czaj¹ce urz¹dzenie wskazywane
    /// przez dostarczony termin.
    /// </summary>
    public class StartUpCommand : Command 
    {
        protected Term _term;

        /// <summary>
        /// Konstrukcja polecenia w³¹czaj¹cego urz¹dzenie wskazywane
        /// przez dostarczony termin.
        /// </summary>
        /// <param name="term">termin sprawdzany w wyniku wykonania polecenia;
        /// wskazywana przez przez niego maszyna zostanie w³¹czona</param>
        public StartUpCommand(Term term)
        {
            _term = term;
        }

        /// <summary>
        /// Okreœla maszynê wskazywan¹ przez termin i w³¹cza j¹.
        /// </summary>
        public override void Execute()
        {
            Machine m = _term.Eval();
            m.StartUp();
        }
    }
}
