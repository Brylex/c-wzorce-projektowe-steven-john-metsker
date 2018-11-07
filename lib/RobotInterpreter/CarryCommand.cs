using System;
using Machines;
namespace RobotInterpreter
{
    /// <summary>
    /// Obs�uga przeniesienia pojemnika z jednej maszyny do drugiej,
    /// z mo�liwo�ci� odwo�ywania si� do maszyn wed�ug nazw.
    /// </summary>
    public class CarryCommand : Command 
    {
        protected Machine _fromMachine;
        protected Machine _toMachine;

        /// <summary>
        /// Konstrukcja polecenia przeniesienia pojemnika z jednej
        /// maszyny do drugiej.
        /// </summary>
        /// <param name="fromMachine">maszyna, przy kt�rej obecnie stoi pojemnik</param>
        /// <param name="toMachine">maszyna docelowa dla pojemnika</param>
        public CarryCommand(Machine fromMachine, Machine toMachine)
        {
            _fromMachine = fromMachine;
            _toMachine = toMachine;
        }

        /// <summary>
        /// Przekszta�ca odwo�ania na konkretne maszyny i przenosi
        /// pojemnik mi�dzy odpowiednimi maszynami.
        /// </summary>
        public override void Execute()
        {
            Robot.singleton.Carry(_fromMachine, _toMachine);
        }
    }
}
