using System;
using Credit;
namespace Credit.Canada
{
    /// <summary>
    /// Instancje tej klasy sprawdzaj¹ atrybuty adresu do wysy³ki
    /// w Kanadzie.
    /// </summary>
    public class ShippingCheckCanada : IShippingCheck 
    { 
        /// <summary>
        /// Zwraca true jeœli wysy³ka na ten adres wi¹¿e siê z dodatkow¹ op³at¹.
        /// </summary>
        /// <returns>true jeœli adres wi¹¿e siê z dodatkow¹ op³at¹</returns>
        public bool HasTariff()
        {
            return true;
        }
    }
}
