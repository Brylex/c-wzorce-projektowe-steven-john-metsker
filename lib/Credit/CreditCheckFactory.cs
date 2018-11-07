using System;
namespace Credit
{
    /// <summary>
    /// Fabryka obiektów do sprawdzania zdolnoœci kredytowej.
    /// </summary>
    public abstract class CreditCheckFactory 
    {
        /// <summary>
        /// Zwraca obiekt implementuj¹cy ICreditCheck. Jego faktyczna klasa
        /// zale¿y od aktualnej dostêpnoœci agencji kredytowej.
        /// </summary>
        /// <returns>obiekt implementuj¹cy ICreditCheck</returns>
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
        /// Zwraca true jeœli agencja kredytowa jest dostêpna. Metoda na 
        /// razie nie jest zaimplementowana.
        /// </summary>
        /// <returns>true jeœli agencja kredytowa jest dostêpna</returns>
        public static bool IsAgencyUp()
        {
            return true;
        }
        /// <summary>
        /// Zwraca obiekt implementuj¹cy IBillingCheck. Jego faktyczna
        /// klasa zale¿y od konkretnej podklasy.
        /// </summary>
        /// <returns>obiekt implementuj¹cy IBillingCheck</returns>
        public abstract IBillingCheck CreateBillingCheck();
        /// <summary>
        /// Zwraca obiekt implementuj¹cy ICreditCheck. Jego faktyczna
        /// klasa zale¿y od konkretnej podklasy.        
        /// </summary>
        /// <returns>obiekt implementuj¹cy ICreditCheck</returns>
        public abstract ICreditCheck CreateCreditCheck2();
        /// <summary>
        /// Zwraca obiekt implementuj¹cy IShippingCheck. Jego faktyczna
        /// klasa zale¿y od konkretnej podklasy.
        /// </summary>
        /// <returns>obiekt implementuj¹cy IShippingCheck</returns>
        public abstract IShippingCheck CreateShippingCheck();
    }
}
