using System;
namespace Functions
{
    /// <summary>
    /// Opakowuje funkcjê Math.Abs() wokó³ wartoœci Ÿród³owej.
    /// </summary>
    public class Abs : Frapper 
    {
        /// <summary>
        /// Konstrukcja funkcji wartoœci bezwzglêdnej, do³¹czanej do
        /// dostarczonej funkcji Ÿród³owej.
        /// </summary>
        /// <param name="f">Inna klasa opakowuj¹ca funkcjê</param>
        public Abs(Frapper f) : base (f)
        {
        }
        /// <summary>
        /// Zwraca wynik zastosowania Math.Abs() do wartoœci funkcji Ÿród³owej
        /// w momencie t.
        /// </summary>
        /// <param name="t">time</param>
        /// <returns>wartoœæ bezwzglêdn¹ wartoœci funkcji Ÿród³owej w momencie t</returns>
        public override double F(double t)
        {
            return Math.Abs(_sources[0].F(t));
        }
    }
}
