using System;
using Fireworks;

namespace Recommendations
{
    /// <summary>
    ///  Implementacja interfejsu Advisor korzystaj¹ca z systemu LikeMyStuff,
    ///  modeluj¹cego preferencje klienta na podstawie jego dotychczasowych
    ///  zakupów.
    /// </summary>
    public class ItemAdvisor : Advisor 
    {
        public static readonly ItemAdvisor singleton = new ItemAdvisor();
        private ItemAdvisor()
        {
        }

        /// <summary>
        /// Polecenie klientowi odpowiedniego produktu, wybranego na podstawie
        /// modelu ostatnich wydatków klienta w Oozinoz.
        /// </summary>
        /// <param name="c">profilowany klient</param>
        /// <returns>odpowiedni produkt dla tego klienta</returns>
        public Firework Recommend(Customer c)
        {
            return (Firework) LikeMyStuff.Suggest(c);
        }
    }
}
