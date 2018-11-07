using System;
using Machines;
namespace RobotInterpreter
{
    /// <summary>
    /// Obs³uga przeniesienia pojemnika z jednej maszyny do drugiej,
    /// z mo¿liwoœci¹ odwo³ywania siê do maszyn wed³ug nazw.
    /// </summary>
    public class CarryCommand : Command 
    {
        protected Machine _fromMachine;
        protected Machine _toMachine;

        /// <summary>
        /// Konstrukcja polecenia przeniesienia pojemnika z jednej
        /// maszyny do drugiej.
        /// </summary>
        /// <param name="fromMachine">maszyna, przy której obecnie stoi pojemnik</param>
        /// <param name="toMachine">maszyna docelowa dla pojemnika</param>
        public CarryCommand(Machine fromMachine, Machine toMachine)
        {
            _fromMachine = fromMachine;
            _toMachine = toMachine;
        }

        /// <summary>
        /// Przekszta³ca odwo³ania na konkretne maszyny i przenosi
        /// pojemnik miêdzy odpowiednimi maszynami.
        /// </summary>
        public override void Execute()
        {
            Robot.singleton.Carry(_fromMachine, _toMachine);
        }
    }
}
