using System;
using Fireworks;
namespace Recommendations
{
    /// <summary>
    /// Za�lepka systemu rekomendacji polecaj�cego klientowi produkt
    /// na podstawie historii jego zakup�w w Oozinoz.
    /// </summary>
    public class LikeMyStuff 
    {
        /// <summary>
        /// Poleca klientowi odpowiedni produkt na podstawie jego
        /// dotychczasowych zakup�w.
        /// </summary>
        /// <param name="c">klient</param>
        /// <returns>najlepszy produkt dla tego klienta</returns>
        public static Object Suggest(Customer c)
        {
            return new Firework();
        }
    }
}
