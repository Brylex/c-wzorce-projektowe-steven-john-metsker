using System;
namespace Functions
{
    /// <summary>
    /// Dostarcza "funkcj�" ignoruj�c� parametr czasu t i zawsze zwracaj�c�
    /// sta�� warto��.
    /// </summary>
    public class Constant : Frapper 
    {
        protected double _constant;
        /// <summary>
        /// Konstrukcja "funkcji" ignoruj�cej parametr czasu t i zawsze 
        /// zwracaj�cej sta�� warto��.
        /// </summary>
        /// <param name="constant">sta��</param>
        public Constant(double constant) : base (new Frapper[]{})
        {
            _constant = constant;
        }
        /// <summary>
        /// Zwraca sta�� warto�� tego obiektu.
        /// </summary>
        /// <param name="t">czas, ignorowany</param>
        /// <returns>sta�� warto�� tego obiektu</returns>
        public override double F(double t)
        {
            return _constant;
        }
    }
}
