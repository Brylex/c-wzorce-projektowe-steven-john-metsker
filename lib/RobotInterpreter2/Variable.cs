using System;
using Machines;

namespace RobotInterpreter2
{
    /// <summary>
    /// Zapisuje nazwê zmiennej, do której mo¿na przypisaæ wykorzystywan¹ 
    /// póŸniej maszynê.
    /// </summary>
    public class Variable : Term 
    {
        protected String _name;
        protected Term _value;

        /// <summary>
        /// Konstrukcja zmiennej o dostarczonej nazwie.
        /// </summary>
        /// <param name="name">nazwa zmiennej</param>
        public Variable(String name)
        {
            this._name = name;
        }

        /// <summary>
        /// Zwraca nazwê zmiennej.
        /// </summary>
        /// <returns>nazwa tej zmiennej</returns>
        public String Name
        {
            get
            {
                return _name;
            }
        }

        /// <summary>
        /// Ustawia wartoœæ tej zmiennej.
        /// </summary>
        /// <param name="value">wartoœæ tej zmiennej</param>
        public void Assign(Term value)
        {
            _value = value;
        }

        /// <summary>
        /// Zwraca true jeœli dostarczony obiekt jest równy bie¿¹cemu.
        /// </summary>
        /// <param name="o">porównywany obiekt</param>
        /// <returns>true jeœli dostarczony obiekt jest równy bie¿¹cemu</returns>
        public override bool Equals(Object o)
        {
            if (o == this) 
            {
                return true;
            }
            Variable v = o as Variable;
            if (v == null) 
            {
                return false;
            }
            return _name.Equals(v._name);
        }

        /// <summary>
        /// Zwraca klucz dla tego obiektu. 
        /// </summary>
        /// <returns>klucz dla tego obiektu</returns>
        public override int GetHashCode()
        {
            return _name.GetHashCode();
        }

        /// <summary>
        /// Zwraca maszynê, do której odnosi siê zmienna w dostarczonym 
        /// kontekœcie.
        /// </summary>
        /// <returns>maszynê, do której odnosi siê zmienna w dostarczonym 
        /// kontekœcie</returns>
        public override Machine Eval()
        {
            return _value.Eval();
        }
        /// <summary>
        /// Zwraca tekstowy opis zmiennej.
        /// </summary>
        /// <returns>tekstowy opis zmiennej</returns>
        public override String ToString()
        {
            return _name + ": " + _value;
        }
    }
}
