using System;
using Fireworks;
namespace Recommendations
{
    /// <summary>
    /// Za�lepka systemu rekomendacji, wykorzystuj�cego w swych sugestiach
    /// profile klient�w. 
    /// </summary>
    public class Rel8 
    {
        /// <summary>
        /// Polecenie klientowi odpowiedniego produktu, wybranego na podstawie
        /// por�wnania upodoba� klienta w kwestii muzyki i sport�w ekstremalnych
        /// z preferencjami i ulubionymi fajerwerkami innych klient�w.
        /// </summary>
        /// <param name="c">klient</param>
        /// <returns>sugerowany fajerwerk</returns>
        public static Object Advise(Customer c)
        {
            return new Firework();
        }
    }
}
