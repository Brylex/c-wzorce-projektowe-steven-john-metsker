using System;
namespace Functions
{
    /// <summary>
    /// Opakowuje funkcj� Math.Abs() wok� warto�ci �r�d�owej.
    /// </summary>
    public class Abs : Frapper 
    {
        /// <summary>
        /// Konstrukcja funkcji warto�ci bezwzgl�dnej, do��czanej do
        /// dostarczonej funkcji �r�d�owej.
        /// </summary>
        /// <param name="f">Inna klasa opakowuj�ca funkcj�</param>
        public Abs(Frapper f) : base (f)
        {
        }
        /// <summary>
        /// Zwraca wynik zastosowania Math.Abs() do warto�ci funkcji �r�d�owej
        /// w momencie t.
        /// </summary>
        /// <param name="t">time</param>
        /// <returns>warto�� bezwzgl�dn� warto�ci funkcji �r�d�owej w momencie t</returns>
        public override double F(double t)
        {
            return Math.Abs(_sources[0].F(t));
        }
    }
}
