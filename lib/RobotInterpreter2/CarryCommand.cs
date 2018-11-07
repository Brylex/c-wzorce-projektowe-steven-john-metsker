using System;
using Machines;
namespace RobotInterpreter2
{
    /// <summary>
    /// Obs�uga przeniesienia pojemnika z jednej maszyny do drugiej,
    /// z mo�liwo�ci� odwo�ywania si� do maszyn wed�ug termin�w.
    /// </summary>    
    public class CarryCommand : Command 
    {
        protected Term _from;
        protected Term _to;

        /// <summary>
        /// Konstrukcja polecenia przeniesienia pojemnika z jednej
        /// maszyny do drugiej.
        /// </summary>
        /// <param name="fromTerm">zmienna lub sta�a wskazuj�ca maszyn�,
        /// z kt�rej ma by� odebrany pojemnik</param>
        /// <param name="toTerm">zmienna lub sta�a wskazuj�ca maszyn�,
        /// przy kt�rej ma by� postawiony pojemnik</param>
        public CarryCommand(Term fromTerm, Term toTerm)
        {
            _from = fromTerm;
            _to = toTerm;
        }

        /// <summary>
        /// Przekszta�ca terminy na konkretne maszyny i przenosi
        /// pojemnik mi�dzy odpowiednimi maszynami.
        /// </summary>
        public override void Execute()
        {
            Robot.singleton.Carry(_from.Eval(), _to.Eval());
        }
    }
}
