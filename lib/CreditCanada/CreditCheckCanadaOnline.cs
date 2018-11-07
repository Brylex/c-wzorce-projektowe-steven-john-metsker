using System;
using Credit;
namespace Credit.Canada
{
    /// <summary>
    /// Obiekty tej klasy sprawdzaj¹ limit kredytowy ³¹cz¹c siê
    /// z zewnêtrzn¹, kanadyjsk¹ agencj¹ kredytow¹.
    /// </summary>
    public class CreditCheckCanadaOnline : ICreditCheck 
    {
        /// <summary>
        /// Zwraca dopuszczalny limit kredytowy dla klienta o podanym
        /// identyfikatorze.
        /// </summary>
        /// <param name="id">identyfikator klienta</param>
        /// <returns>limit kredytowy</returns>
        public double CreditLimit(int id)
        {
            // miejsce na kod nawi¹zuj¹cy kontakt z kanadyjsk¹ agencj¹ kredytow¹
            return 0;
        }
    }
}
