using System;
using Machines;

namespace RobotInterpreter2
{
    /// <summary>
    /// Odpowiada konkretnej maszynie.
    /// </summary>
    public class Constant : Term 
    {
        protected Machine _machine;

        /// <summary>
        /// Konstrukcja terminu zawsze odwo�uj�cego si� do konkretnej maszyny.
        /// </summary>
        /// <param name="machine"></param>
        public Constant(Machine machine)
        {
            _machine = machine;
        }

        /// <summary>
        /// Zwraca true, je�li dostarczony obiekt jest r�wny bie��cemu.
        /// </summary>
        /// <param name="o">por�wnywany obiekt</param>
        /// <returns>true, je�li dostarczony obiekt jest r�wny bie��cemu</returns>
        public override bool Equals(Object o)
        {
            if (o == this)
            {
                return true;
            }
            Constant c = o as Constant;
            if (c == null) 
            {
                return false; 
            }
            return _machine.Equals(c._machine);
        }

        /// <summary>
        /// Zwraca klucz do obiektu.
        /// </summary>
        /// <returns>klucz dla obiektu</returns>
        public override int GetHashCode()
        {
            return _machine.GetHashCode();
        }

        /// <summary>
        /// Zwraca maszyn�, kt�rej odpowiada bie��cy obiekt.
        /// </summary>
        /// <returns>maszyn�, kt�rej odpowiada bie��cy obiekt</returns>
        public override Machine Eval()
        {
            return _machine;
        }
        /// <summary>
        /// Zwraca tekstowy opis sta�ej.
        /// </summary>
        /// <returns>tekstowy opis sta�ej</returns>
        public override String ToString()
        {
            return _machine.ToString();
        }
    }
}
