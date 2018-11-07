using System;
namespace Functions
{
    /// <summary>
    /// Opakowuje funkcj� Math.Cos() wok� podanego �r�d�a.
    /// </summary>
    public class Cos : Frapper 
    {
        /// <summary>
        /// Konstrukcja funkcji cosinusa do��czanej do dostarczonej funkcji
        /// �r�d�owej.
        /// </summary>
        /// <param name="f">Inna klasa opakowuj�ca funkcj�</param>
        public Cos(Frapper f) : base (f)
        {
        }
        /// <summary>
        /// Zwraca wynik wykonania Math.Cos() na warto�ci funkcji �r�d�owej
        /// w momencie t.
        /// </summary>
        /// <param name="t">czas</param>
        /// <returns>cosinus warto�ci funkcji �r�d�owej w momencie t</returns>
        public override double F(double t)
        {
            return Math.Cos(_sources[0].F(t));
        }
    }
}
