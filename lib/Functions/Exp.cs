using System;
namespace Functions
{
    /// <summary>
    /// Opakowuje funkcj� Math.Exp() wok� dostarczonego �r�d�a.
    /// </summary>
    public class Exp : Frapper 
    {
        /// <summary>
        /// Konstrukcja funkcji wyk�adniczej opakowuj�cej podan� funkcj�
        /// �r�d�ow�.
        /// </summary>
        /// <param name="f">Inna klasa opakowuj�ca funkcj�</param>
        public Exp(Frapper f) : base (f)
        {
        }
        /// <summary>
        /// Zwraca wynik wykonania Math.Exp() dla warto�ci funkcji �r�d�owej
        /// w momencie t.
        /// </summary>
        /// <param name="t">czas</param>
        /// <returns>Math.E podniesione do pot�gi warto�ci funkcji �r�d�owej
        /// w momencie t</returns>
        public override double F(double t)
        {
            return Math.Exp(_sources[0].F(t));
        }
    }
}
