using System;
namespace Credit
{
    /// <summary>
    /// Fabryka obiekt�w do sprawdzania zdolno�ci kredytowej.
    /// </summary>
    public abstract class CreditCheckFactory 
    {
        /// <summary>
        /// Zwraca obiekt implementuj�cy ICreditCheck. Jego faktyczna klasa
        /// zale�y od aktualnej dost�pno�ci agencji kredytowej.
        /// </summary>
        /// <returns>obiekt implementuj�cy ICreditCheck</returns>
        public static ICreditCheck CreateCreditCheck()
        {
            if (IsAgencyUp())
            {
                return new CreditCheckOnline();
            }
            else
            {
                return new CreditCheckOffline();
            }
        }
        /// <summary>
        /// Zwraca true je�li agencja kredytowa jest dost�pna. Metoda na 
        /// razie nie jest zaimplementowana.
        /// </summary>
        /// <returns>true je�li agencja kredytowa jest dost�pna</returns>
        public static bool IsAgencyUp()
        {
            return true;
        }
        /// <summary>
        /// Zwraca obiekt implementuj�cy IBillingCheck. Jego faktyczna
        /// klasa zale�y od konkretnej podklasy.
        /// </summary>
        /// <returns>obiekt implementuj�cy IBillingCheck</returns>
        public abstract IBillingCheck CreateBillingCheck();
        /// <summary>
        /// Zwraca obiekt implementuj�cy ICreditCheck. Jego faktyczna
        /// klasa zale�y od konkretnej podklasy.        
        /// </summary>
        /// <returns>obiekt implementuj�cy ICreditCheck</returns>
        public abstract ICreditCheck CreateCreditCheck2();
        /// <summary>
        /// Zwraca obiekt implementuj�cy IShippingCheck. Jego faktyczna
        /// klasa zale�y od konkretnej podklasy.
        /// </summary>
        /// <returns>obiekt implementuj�cy IShippingCheck</returns>
        public abstract IShippingCheck CreateShippingCheck();
    }
}
