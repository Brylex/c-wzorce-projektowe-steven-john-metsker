using System;
using Credit;
namespace Credit.Canada
{
    /// <summary>
    /// Obiekty tej klasy sprawdzaj� limit kredytowy ��cz�c si�
    /// z zewn�trzn�, kanadyjsk� agencj� kredytow�.
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
            // miejsce na kod nawi�zuj�cy kontakt z kanadyjsk� agencj� kredytow�
            return 0;
        }
    }
}
