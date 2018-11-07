using System;
using Machines;
namespace RobotInterpreter2
{
    /// <summary>
    /// Obs³uga przeniesienia pojemnika z jednej maszyny do drugiej,
    /// z mo¿liwoœci¹ odwo³ywania siê do maszyn wed³ug terminów.
    /// </summary>    
    public class CarryCommand : Command 
    {
        protected Term _from;
        protected Term _to;

        /// <summary>
        /// Konstrukcja polecenia przeniesienia pojemnika z jednej
        /// maszyny do drugiej.
        /// </summary>
        /// <param name="fromTerm">zmienna lub sta³a wskazuj¹ca maszynê,
        /// z której ma byæ odebrany pojemnik</param>
        /// <param name="toTerm">zmienna lub sta³a wskazuj¹ca maszynê,
        /// przy której ma byæ postawiony pojemnik</param>
        public CarryCommand(Term fromTerm, Term toTerm)
        {
            _from = fromTerm;
            _to = toTerm;
        }

        /// <summary>
        /// Przekszta³ca terminy na konkretne maszyny i przenosi
        /// pojemnik miêdzy odpowiednimi maszynami.
        /// </summary>
        public override void Execute()
        {
            Robot.singleton.Carry(_from.Eval(), _to.Eval());
        }
    }
}
