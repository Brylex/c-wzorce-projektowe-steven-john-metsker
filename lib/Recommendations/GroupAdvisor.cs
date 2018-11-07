using System;
using Fireworks;
namespace Recommendations
{
    /// <summary>
    /// Implementacja interfejsu Advisor korzystaj¹ca z systemu Rel8,
    /// porównuj¹cego preferencje klienta z upodobaniami innych klientów.
    /// </summary>
    public class GroupAdvisor : Advisor 
    {
        public static readonly GroupAdvisor singleton = new GroupAdvisor();

        private GroupAdvisor()
        {
        }

        /// <summary>
        /// Polecenie klientowi odpowiedniego produktu, wybranego na podstawie
        /// porównania upodobañ klienta w kwestii muzyki i sportów ekstremalnych
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
