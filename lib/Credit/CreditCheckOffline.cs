using System;
namespace Credit
{
    /// <summary>
    /// Obiekty tej klasy weryfikuj¹ mo¿liwoœci kredytowe klienta na
    /// podstawie serii pytañ zadawanych przez pracownika biura obs³ugi.
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
            // miejsce na kod pobieraj¹cy od pracownika rozs¹dny limit 
            // kredytowy ustalony na podstawie informacji klienta.
            return 0;
        }
    }
}
