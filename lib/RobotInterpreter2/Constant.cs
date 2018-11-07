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
        /// Konstrukcja terminu zawsze odwo³uj¹cego siê do konkretnej maszyny.
        /// </summary>
        /// <param name="machine"></param>
        public Constant(Machine machine)
        {
            _machine = machine;
        }

        /// <summary>
        /// Zwraca true, jeœli dostarczony obiekt jest równy bie¿¹cemu.
        /// </summary>
        /// <param name="o">porównywany obiekt</param>
        /// <returns>true, jeœli dostarczony obiekt jest równy bie¿¹cemu</returns>
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
        /// Zwraca maszynê, której odpowiada bie¿¹cy obiekt.
        /// </summary>
        /// <returns>maszynê, której odpowiada bie¿¹cy obiekt</returns>
        public override Machine Eval()
        {
            return _machine;
        }
        /// <summary>
        /// Zwraca tekstowy opis sta³ej.
        /// </summary>
        /// <returns>tekstowy opis sta³ej</returns>
        public override String ToString()
        {
            return _machine.ToString();
        }
    }
}
