using System;
using Credit;
namespace Credit.Canada
{
    /// <summary>
    /// Fabryka obiektów do sprawdzania zdolności kredytowej, adresów do
    /// fakturowania i adresów wysyłki w Kanadzie.
    /// </summary>
    public class CheckFactoryCanada : CreditCheckFactory 
    {
        /// <summary>
        /// Zwraca obiekt implementujący IBillingCheck dla klientów kanadyjskich.
        /// </summary>
        /// <returns>obiekt implementujący IBillingCheck dla klientów kanadyjskich</returns>
        public override IBillingCheck CreateBillingCheck()
        {
            return new BillingCheckCanada();
        } 
        /// <summary>
        /// Zwraca obiekt implementujący ICreditCheck dla klientów kanadyjskich.
        /// </summary>
        /// <returns>obiekt implementujący ICreditCheck dla klientów kanadyjskich</returns>
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
        /// Zwraca obiekt implementujący IShippingCheck dla klientów kanadyjskich.
        /// </summary>
        /// <returns>obiekt implementujący IShippingCheck dla klientów kanadyjskich</returns>
        public override IShippingCheck CreateShippingCheck()
        {
            return new ShippingCheckCanada();
        }
    }
}
