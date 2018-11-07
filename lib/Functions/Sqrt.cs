using System;
namespace Functions
{
    /// <summary>
    /// Opakowuje funkcj� Math.Sqrt() wok� podanego �r�d�a.
    /// </summary>
    public class Sqrt : Frapper 
    {
        /// <summary>
        /// Konstrukcja funkcji pierwiastka kwadratowego do��czanej do 
        /// dostarczonej funkcji �r�d�owej.
        /// </summary>
        /// <param name="f">Inna klasa opakowuj�ca funkcj�</param>
        public Sqrt(Frapper f) : base (f)
        {
        }
        /// <summary>
        /// Zwraca wynik wykonania Math.Sqrt() na warto�ci funkcji �r�d�owej
        /// w momencie t.
        /// </summary>
        /// <param name="t">time</param>
        /// <returns>pierwiastek kwadratowy warto�ci funkcji �r�d�owej 
        /// w momencie t</returns>
        public override double F(double t)
        {
            return Math.Sqrt(_sources[0].F(t));
        }
    }
}
