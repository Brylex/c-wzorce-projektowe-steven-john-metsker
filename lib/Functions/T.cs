using System;
namespace Functions
{
    /// <summary>
    /// Funkcja identyczno�ciowa, zwracaj�ca sam� warto�� czasu. Przydaje si�
    /// ona na przyk�ad do bezpo�redniego wprowadzenia czasu dla iloczyn�w
    /// kartezja�skich gdzie x przebiega od 0 do 1.
    /// </summary>
    public class T : Frapper 
    {
        /// <summary>
        /// Konstrukcja funkcji identyczno�ciowej zwracaj�cej warto�� t.
        /// </summary>
        public T() : base (new Frapper[]{})
        {
        }
        /// <summary>
        /// Zwraca bie��c� warto�� t.
        /// </summary>
        /// <param name="t">czas</param>
        /// <returns>czas</returns>
        public override double F(double t)
        {
            return t;
        }
    }
}
