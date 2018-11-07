using System;
namespace Functions
{
    /// <summary>
    /// Opakowuje funkcj� Math.Sin() wok� podanego �r�d�a.
    /// </summary>
    public class Sin : Frapper 
    {
        /// <summary>
        /// Konstrukcja funkcji sinusa do��czanej do dostarczonej funkcji
        /// �r�d�owej.
        /// </summary>
        /// <param name="f">Inna klasa opakowuj�ca funkcj�</param>
        public Sin(Frapper f) : base (f)
        {
        }
        /// <summary>
        /// Zwraca wynik wykonania Math.Sin() na warto�ci funkcji �r�d�owej
        /// w momencie t.
        /// </summary>
        /// <param name="t">czas</param>
        /// <returns>sinus warto�ci funkcji �r�d�owej w momencie t</returns>
        public override double F(double t)
        {
            return Math.Sin(_sources[0].F(t));
        }
    }
}
