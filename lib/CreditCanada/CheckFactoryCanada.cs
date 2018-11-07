using System;
using Credit;
namespace Credit.Canada
{
    /// <summary>
    /// Fabryka obiekt�w do sprawdzania zdolno�ci kredytowej, adres�w do
    /// fakturowania i adres�w wysy�ki w Kanadzie.
    /// </summary>
    public class CheckFactoryCanada : CreditCheckFactory 
    {
        /// <summary>
        /// Zwraca obiekt implementuj�cy IBillingCheck dla klient�w kanadyjskich.
        /// </summary>
        /// <returns>obiekt implementuj�cy IBillingCheck dla klient�w kanadyjskich</returns>
        public override IBillingCheck CreateBillingCheck()
        {
            return new BillingCheckCanada();
        } 
        /// <summary>
        /// Zwraca obiekt implementuj�cy ICreditCheck dla klient�w kanadyjskich.
        /// </summary>
        /// <returns>obiekt implementuj�cy ICreditCheck dla klient�w kanadyjskich</returns>
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
        /// Zwraca obiekt implementuj�cy IShippingCheck dla klient�w kanadyjskich.
        /// </summary>
        /// <returns>obiekt implementuj�cy IShippingCheck dla klient�w kanadyjskich</returns>
        public override IShippingCheck CreateShippingCheck()
        {
            return new ShippingCheckCanada();
        }
    }
}
