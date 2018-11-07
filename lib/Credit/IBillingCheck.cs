namespace Credit
{
    /// <summary>
    /// Interfejs definiuj�cy metody sprawdzania adresu do fakturowania.
    /// </summary>
    public interface IBillingCheck 
    {
        /// <summary>
        /// Zwraca true je�li adres klienta jest adresem domowym.
        /// </summary>
        /// <returns>true je�li adres klienta jest adresem domowym</returns>
        bool IsResidential();
    }
}

 