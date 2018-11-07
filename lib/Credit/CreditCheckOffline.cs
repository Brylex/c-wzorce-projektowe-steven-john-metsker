using System;
namespace Credit
{
    /// <summary>
    /// Obiekty tej klasy weryfikuj� mo�liwo�ci kredytowe klienta na
    /// podstawie serii pyta� zadawanych przez pracownika biura obs�ugi.
    /// </summary>
    public class CreditCheckOffline : ICreditCheck 
    {
        /// <summary>
        /// Zwraca dopuszczalny limit kredytowy dla klienta o podanym
        /// identyfikatorze.
        /// </summary>
        /// <param name="id">identyfikator klienta</param>
        /// <returns>limit kredytowy</returns>
        public double CreditLimit(int id)
        {
            // miejsce na kod pobieraj�cy od pracownika rozs�dny limit 
            // kredytowy ustalony na podstawie informacji klienta.
            return 0;
        }
    }
}
