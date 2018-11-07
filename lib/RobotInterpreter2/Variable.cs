using System;
using Machines;

namespace RobotInterpreter2
{
    /// <summary>
    /// Zapisuje nazw� zmiennej, do kt�rej mo�na przypisa� wykorzystywan� 
    /// p�niej maszyn�.
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
        /// Zwraca nazw� zmiennej.
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
        /// Ustawia warto�� tej zmiennej.
        /// </summary>
        /// <param name="value">warto�� tej zmiennej</param>
        public void Assign(Term value)
        {
            _value = value;
        }

        /// <summary>
        /// Zwraca true je�li dostarczony obiekt jest r�wny bie��cemu.
        /// </summary>
        /// <param name="o">por�wnywany obiekt</param>
        /// <returns>true je�li dostarczony obiekt jest r�wny bie��cemu</returns>
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
        /// Zwraca maszyn�, do kt�rej odnosi si� zmienna w dostarczonym 
        /// kontek�cie.
        /// </summary>
        /// <returns>maszyn�, do kt�rej odnosi si� zmienna w dostarczonym 
        /// kontek�cie</returns>
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
