using System;
namespace Functions
{
    /// <summary>
    /// Dostarcza "funkcjê" ignoruj¹c¹ parametr czasu t i zawsze zwracaj¹c¹
    /// sta³¹ wartoœæ.
    /// </summary>
    public class Constant : Frapper 
    {
        protected double _constant;
        /// <summary>
        /// Konstrukcja "funkcji" ignoruj¹cej parametr czasu t i zawsze 
        /// zwracaj¹cej sta³¹ wartoœæ.
        /// </summary>
        /// <param name="constant">sta³¹</param>
        public Constant(double constant) : base (new Frapper[]{})
        {
            _constant = constant;
        }
        /// <summary>
        /// Zwraca sta³¹ wartoœæ tego obiektu.
        /// </summary>
        /// <param name="t">czas, ignorowany</param>
        /// <returns>sta³¹ wartoœæ tego obiektu</returns>
        public override double F(double t)
        {
            return _constant;
        }
    }
}
