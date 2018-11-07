using System;
using Fireworks;
namespace Recommendations
{
    /// <summary>
    /// Zaœlepka systemu rekomendacji, wykorzystuj¹cego w swych sugestiach
    /// profile klientów. 
    /// </summary>
    public class Rel8 
    {
        /// <summary>
        /// Polecenie klientowi odpowiedniego produktu, wybranego na podstawie
        /// porównania upodobañ klienta w kwestii muzyki i sportów ekstremalnych
        /// z preferencjami i ulubionymi fajerwerkami innych klientów.
        /// </summary>
        /// <param name="c">klient</param>
        /// <returns>sugerowany fajerwerk</returns>
        public static Object Advise(Customer c)
        {
            return new Firework();
        }
    }
}
