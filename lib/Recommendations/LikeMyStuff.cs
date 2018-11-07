using System;
using Fireworks;
namespace Recommendations
{
    /// <summary>
    /// Zaœlepka systemu rekomendacji polecaj¹cego klientowi produkt
    /// na podstawie historii jego zakupów w Oozinoz.
    /// </summary>
    public class LikeMyStuff 
    {
        /// <summary>
        /// Poleca klientowi odpowiedni produkt na podstawie jego
        /// dotychczasowych zakupów.
        /// </summary>
        /// <param name="c">klient</param>
        /// <returns>najlepszy produkt dla tego klienta</returns>
        public static Object Suggest(Customer c)
        {
            return new Firework();
        }
    }
}
