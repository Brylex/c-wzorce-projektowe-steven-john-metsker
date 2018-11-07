using System;
namespace Functions
{
    /// <summary>
    /// Opakowuje funkcjê Math.Exp() wokó³ dostarczonego Ÿród³a.
    /// </summary>
    public class Exp : Frapper 
    {
        /// <summary>
        /// Konstrukcja funkcji wyk³adniczej opakowuj¹cej podan¹ funkcjê
        /// Ÿród³ow¹.
        /// </summary>
        /// <param name="f">Inna klasa opakowuj¹ca funkcjê</param>
        public Exp(Frapper f) : base (f)
        {
        }
        /// <summary>
        /// Zwraca wynik wykonania Math.Exp() dla wartoœci funkcji Ÿród³owej
        /// w momencie t.
        /// </summary>
        /// <param name="t">czas</param>
        /// <returns>Math.E podniesione do potêgi wartoœci funkcji Ÿród³owej
        /// w momencie t</returns>
        public override double F(double t)
        {
            return Math.Exp(_sources[0].F(t));
        }
    }
}
