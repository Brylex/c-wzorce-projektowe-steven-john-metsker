using System;

namespace Credit
{
    /// <summary>
    /// Obiekty tej klasy sprawdzaj� limit kredytowy ��cz�c si�
    /// z zewn�trzn� agencj� kredytow�.
    /// </summary>
    public class CreditCheckOnline : ICreditCheck 
    {
        /// <summary>
        /// Zwraca dopuszczalny limit kredytowy dla klienta o podanym
        /// identyfikatorze.
        /// </summary>
        /// <param name="id">identyfikator klienta</param>
        /// <returns>limit kredytowy</returns>
        public double CreditLimit(int id)
        {
            // miejsce na kod nawi�zuj�cy kontakt z agencj� kredytow�
            return 0;
        }
    }
}
