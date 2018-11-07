namespace Credit
{
    /// <summary>
    /// Interfejs definiuj¹cy metody sprawdzania adresu do wysy³ki.
    /// </summary>
    public interface IShippingCheck 
    {
        /// <summary>
        /// Zwraca true jeœli adres klienta jest adresem domowym.
        /// </summary>
        /// <returns>true jeœli adres klienta jest adresem domowym</returns>
        bool HasTariff();
    }
}

 