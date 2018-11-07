using System;
using Credit;
namespace Credit.Canada
{  
    /// <summary>
    /// Instancje tej klasy sprawdzaj� atrybuty adresu do fakturowania
    /// w Kanadzie.
    /// </summary>
    public class BillingCheckCanada : IBillingCheck 
    {        
        /// <summary>
        /// Zwraca true je�li adres klienta jest adresem domowym.
        /// </summary>
        /// <returns>true je�li adres klienta jest adresem domowym</returns>
        public bool IsResidential()
        {
            return true;
        }
    }
}
