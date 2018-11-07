namespace Credit
{
    /// <summary>
    /// Interfejs definiuj�cy metody sprawdzania adresu do wysy�ki.
    /// </summary>
    public interface IShippingCheck 
    {
        /// <summary>
        /// Zwraca true je�li adres klienta jest adresem domowym.
        /// </summary>
        /// <returns>true je�li adres klienta jest adresem domowym</returns>
        bool HasTariff();
    }
}

 