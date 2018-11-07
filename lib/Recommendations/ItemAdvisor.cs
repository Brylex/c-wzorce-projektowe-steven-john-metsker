using System;
using Fireworks;

namespace Recommendations
{
    /// <summary>
    ///  Implementacja interfejsu Advisor korzystaj�ca z systemu LikeMyStuff,
    ///  modeluj�cego preferencje klienta na podstawie jego dotychczasowych
    ///  zakup�w.
    /// </summary>
    public class ItemAdvisor : Advisor 
    {
        public static readonly ItemAdvisor singleton = new ItemAdvisor();
        private ItemAdvisor()
        {
        }

        /// <summary>
        /// Polecenie klientowi odpowiedniego produktu, wybranego na podstawie
        /// modelu ostatnich wydatk�w klienta w Oozinoz.
        /// </summary>
        /// <param name="c">profilowany klient</param>
        /// <returns>odpowiedni produkt dla tego klienta</returns>
        public Firework Recommend(Customer c)
        {
            return (Firework) LikeMyStuff.Suggest(c);
        }
    }
}
