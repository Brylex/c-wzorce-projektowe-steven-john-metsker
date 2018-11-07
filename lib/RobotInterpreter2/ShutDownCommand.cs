using System;
using Machines;

namespace RobotInterpreter2
{
    /// <summary>
    /// Klasa reprezentuje polecenie wy³¹czaj¹ce urz¹dzenie wskazywane
    /// przez dostarczony termin.
    /// </summary>
    public class ShutDownCommand : Command 
    {
        protected Term _term;

        /// <summary>
        /// Konstrukcja polecenia wy³¹czaj¹cego urz¹dzenie wskazywane
        /// przez dostarczony termin.
        /// </summary>
        /// <param name="term">termin sprawdzany w wyniku wykonania polecenia;
        /// wskazywana przez przez niego maszyna zostanie wy³¹czona</param>
        public ShutDownCommand(Term term)
        {
            _term = term;
        }

        /// <summary>
        /// Okreœla maszynê wskazywan¹ przez termin i wy³¹cza j¹.
        /// </summary>
        public override void Execute()
        {
            Machine m = _term.Eval();
            m.ShutDown();
        }
    }
}
