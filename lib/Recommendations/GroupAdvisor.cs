using System;
using Fireworks;
namespace Recommendations
{
    /// <summary>
    /// Implementacja interfejsu Advisor korzystająca z systemu Rel8,
    /// porównującego preferencje klienta z upodobaniami innych klientów.
    /// </summary>
    public class GroupAdvisor : Advisor 
    {
        public static readonly GroupAdvisor singleton = new GroupAdvisor();

        private GroupAdvisor()
        {
        }

        /// <summary>
        /// Polecenie klientowi odpowiedniego produktu, wybranego na podstawie
        /// porównania upodobań klienta w kwestii muzyki i sportów ekstremalnych
        /// z preferencjami i ulubionymi fajerwerkami innych klientów.
        /// </summary>
        /// <param name="c">profilowany klient</param>
        /// <returns>odpowiedni produkt dla tego klienta</returns>
        public Firework Recommend(Customer c)
        {
            return (Firework) Rel8.Advise(c);
        }
    }
}
