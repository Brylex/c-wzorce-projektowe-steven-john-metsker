using System;
namespace Credit
{
    /// <summary>
    /// Fabryka obiektów do sprawdzania zdolności kredytowej.
    /// </summary>
    public abstract class CreditCheckFactory 
    {
        /// <summary>
        /// Zwraca obiekt implementujący ICreditCheck. Jego faktyczna klasa
        /// zależy od aktualnej dostępności agencji kredytowej.
        /// </summary>
        /// <returns>obiekt implementujący ICreditCheck</returns>
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
        /// Zwraca true jeśli agencja kredytowa jest dostępna. Metoda na 
        /// razie nie jest zaimplementowana.
        /// </summary>
        /// <returns>true jeśli agencja kredytowa jest dostępna</returns>
        public static bool IsAgencyUp()
        {
            return true;
        }
        /// <summary>
        /// Zwraca obiekt implementujący IBillingCheck. Jego faktyczna
        /// klasa zależy od konkretnej podklasy.
        /// </summary>
        /// <returns>obiekt implementujący IBillingCheck</returns>
        public abstract IBillingCheck CreateBillingCheck();
        /// <summary>
        /// Zwraca obiekt implementujący ICreditCheck. Jego faktyczna
        /// klasa zależy od konkretnej podklasy.        
        /// </summary>
        /// <returns>obiekt implementujący ICreditCheck</returns>
        public abstract ICreditCheck CreateCreditCheck2();
        /// <summary>
        /// Zwraca obiekt implementujący IShippingCheck. Jego faktyczna
        /// klasa zależy od konkretnej podklasy.
        /// </summary>
        /// <returns>obiekt implementujący IShippingCheck</returns>
        public abstract IShippingCheck CreateShippingCheck();
    }
}
