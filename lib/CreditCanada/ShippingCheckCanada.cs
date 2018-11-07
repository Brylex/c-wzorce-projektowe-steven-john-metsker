using System;
using Credit;
namespace Credit.Canada
{
    /// <summary>
    /// Instancje tej klasy sprawdzaj� atrybuty adresu do wysy�ki
    /// w Kanadzie.
    /// </summary>
    public class ShippingCheckCanada : IShippingCheck 
    { 
        /// <summary>
        /// Zwraca true je�li wysy�ka na ten adres wi��e si� z dodatkow� op�at�.
        /// </summary>
        /// <returns>true je�li adres wi��e si� z dodatkow� op�at�</returns>
        public bool HasTariff()
        {
            return true;
        }
    }
}
