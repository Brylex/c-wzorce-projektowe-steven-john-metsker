using System;
using Credit;
namespace Credit.Canada
{
    /// <summary>
    /// Fabryka obiektów do sprawdzania zdolnoœci kredytowej, adresów do
    /// fakturowania i adresów wysy³ki w Kanadzie.
    /// </summary>
    public class CheckFactoryCanada : CreditCheckFactory 
    {
        /// <summary>
        /// Zwraca obiekt implementuj¹cy IBillingCheck dla klientów kanadyjskich.
        /// </summary>
        /// <returns>obiekt implementuj¹cy IBillingCheck dla klientów kanadyjskich</returns>
        public override IBillingCheck CreateBillingCheck()
        {
            return new BillingCheckCanada();
        } 
        /// <summary>
        /// Zwraca obiekt implementuj¹cy ICreditCheck dla klientów kanadyjskich.
        /// </summary>
        /// <returns>obiekt implementuj¹cy ICreditCheck dla klientów kanadyjskich</returns>
        public override ICreditCheck CreateCreditCheck2()
        {
            if (IsAgencyUp())
            {
                return new CreditCheckCanadaOnline();
            }
            else
            {
                return new CreditCheckOffline();
            }
        } 
        /// <summary>
        /// Zwraca obiekt implementuj¹cy IShippingCheck dla klientów kanadyjskich.
        /// </summary>
        /// <returns>obiekt implementuj¹cy IShippingCheck dla klientów kanadyjskich</returns>
        public override IShippingCheck CreateShippingCheck()
        {
            return new ShippingCheckCanada();
        }
    }
}
