using System;
using Fireworks;
namespace Recommendations
{
    /// <summary>
    /// Implementacja interfejsu Advisor, zwracaj¹ca losowy wybrany fajerwerk.
    /// </summary>
    public class RandomAdvisor : Advisor 
    {
        public static readonly RandomAdvisor singleton = new RandomAdvisor();
        private RandomAdvisor()
        {
        }

        /// <summary>
        /// Poleca losowy fajerwerk.
        /// </summary>
        /// <param name="c">klient</param>
        /// <returns>losowy wybrany fajerwerk</returns>
        public Firework Recommend(Customer c)
        {
            return Firework.GetRandom();
        }
    }
}
