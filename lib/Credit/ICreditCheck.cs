namespace Credit
{
    /// <summary>
    /// Interfejs definiuj¹cy wspólne metody dla klas sprawdzaj¹cych 
    /// limit kredytowy online i offline.
    /// </summary>
    public interface ICreditCheck 
    {
        /// <summary>
        /// Zwraca dopuszczalny limit kredytowy dla klienta o podanym
        /// identyfikatorze.
        /// </summary>
        /// <param name="id">identyfikator klienta</param>
        /// <returns>limit kredytowy</returns>
        double CreditLimit(int id);
    }
}

 