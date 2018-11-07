using System;
using Fireworks;
namespace Recommendations
{
    /// <summary>
    /// Implementacja interfejsu Advisor korzystaj�ca z systemu Rel8,
    /// por�wnuj�cego preferencje klienta z upodobaniami innych klient�w.
    /// </summary>
    public class GroupAdvisor : Advisor 
    {
        public static readonly GroupAdvisor singleton = new GroupAdvisor();

        private GroupAdvisor()
        {
        }

        /// <summary>
        /// Polecenie klientowi odpowiedniego produktu, wybranego na podstawie
        /// por�wnania upodoba� klienta w kwestii muzyki i sport�w ekstremalnych
        /// z preferencjami i ulubionymi fajerwerkami innych klient�w.
        /// </summary>
        /// <param name="c">profilowany klient</param>
        /// <returns>odpowiedni produkt dla tego klienta</returns>
        public Firework Recommend(Customer c)
        {
            return (Firework) Rel8.Advise(c);
        }
    }
}
