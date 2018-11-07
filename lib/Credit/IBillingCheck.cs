namespace Credit
{
    /// <summary>
    /// Interfejs definiuj¹cy metody sprawdzania adresu do fakturowania.
    /// </summary>
    public interface IBillingCheck 
    {
        /// <summary>
        /// Zwraca true jeœli adres klienta jest adresem domowym.
        /// </summary>
        /// <returns>true jeœli adres klienta jest adresem domowym</returns>
        bool IsResidential();
    }
}

 