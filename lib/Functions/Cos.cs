using System;
namespace Functions
{
    /// <summary>
    /// Opakowuje funkcjê Math.Cos() wokó³ podanego Ÿród³a.
    /// </summary>
    public class Cos : Frapper 
    {
        /// <summary>
        /// Konstrukcja funkcji cosinusa do³¹czanej do dostarczonej funkcji
        /// Ÿród³owej.
        /// </summary>
        /// <param name="f">Inna klasa opakowuj¹ca funkcjê</param>
        public Cos(Frapper f) : base (f)
        {
        }
        /// <summary>
        /// Zwraca wynik wykonania Math.Cos() na wartoœci funkcji Ÿród³owej
        /// w momencie t.
        /// </summary>
        /// <param name="t">czas</param>
        /// <returns>cosinus wartoœci funkcji Ÿród³owej w momencie t</returns>
        public override double F(double t)
        {
            return Math.Cos(_sources[0].F(t));
        }
    }
}
