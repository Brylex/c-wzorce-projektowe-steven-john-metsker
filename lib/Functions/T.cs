using System;
namespace Functions
{
    /// <summary>
    /// Funkcja identycznoœciowa, zwracaj¹ca sam¹ wartoœæ czasu. Przydaje siê
    /// ona na przyk³ad do bezpoœredniego wprowadzenia czasu dla iloczynów
    /// kartezjañskich gdzie x przebiega od 0 do 1.
    /// </summary>
    public class T : Frapper 
    {
        /// <summary>
        /// Konstrukcja funkcji identycznoœciowej zwracaj¹cej wartoœæ t.
        /// </summary>
        public T() : base (new Frapper[]{})
        {
        }
        /// <summary>
        /// Zwraca bie¿¹c¹ wartoœæ t.
        /// </summary>
        /// <param name="t">czas</param>
        /// <returns>czas</returns>
        public override double F(double t)
        {
            return t;
        }
    }
}
