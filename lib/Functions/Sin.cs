using System;
namespace Functions
{
    /// <summary>
    /// Opakowuje funkcjê Math.Sin() wokó³ podanego Ÿród³a.
    /// </summary>
    public class Sin : Frapper 
    {
        /// <summary>
        /// Konstrukcja funkcji sinusa do³¹czanej do dostarczonej funkcji
        /// Ÿród³owej.
        /// </summary>
        /// <param name="f">Inna klasa opakowuj¹ca funkcjê</param>
        public Sin(Frapper f) : base (f)
        {
        }
        /// <summary>
        /// Zwraca wynik wykonania Math.Sin() na wartoœci funkcji Ÿród³owej
        /// w momencie t.
        /// </summary>
        /// <param name="t">czas</param>
        /// <returns>sinus wartoœci funkcji Ÿród³owej w momencie t</returns>
        public override double F(double t)
        {
            return Math.Sin(_sources[0].F(t));
        }
    }
}
