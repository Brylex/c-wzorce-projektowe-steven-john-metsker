using System;
namespace Functions
{
    /// <summary>
    /// Opakowuje funkcjê Math.Sqrt() wokó³ podanego Ÿród³a.
    /// </summary>
    public class Sqrt : Frapper 
    {
        /// <summary>
        /// Konstrukcja funkcji pierwiastka kwadratowego do³¹czanej do 
        /// dostarczonej funkcji Ÿród³owej.
        /// </summary>
        /// <param name="f">Inna klasa opakowuj¹ca funkcjê</param>
        public Sqrt(Frapper f) : base (f)
        {
        }
        /// <summary>
        /// Zwraca wynik wykonania Math.Sqrt() na wartoœci funkcji Ÿród³owej
        /// w momencie t.
        /// </summary>
        /// <param name="t">time</param>
        /// <returns>pierwiastek kwadratowy wartoœci funkcji Ÿród³owej 
        /// w momencie t</returns>
        public override double F(double t)
        {
            return Math.Sqrt(_sources[0].F(t));
        }
    }
}
