using System;

namespace Fireworks
{
	/// <summary>
   /// Fajerwerk wystrzeliwany z moŸdzierza i eksploduj¹cy wysoko na niebie.
	/// </summary>
	public class Shell : Firework
	{
        private double _muzzleVelocity;
        /// <summary>
        /// Tworzy pust¹ petardê.
        /// </summary>
        public Shell()
        {
        }
        /// <summary>
        /// Tworzy petardê o podanych w³aœciwoœciach.
        /// </summary>
        /// <param name="muzzleVelocity">Prêdkoœæ wylotowa (w metrach na sekundê)
        /// petardy opuszczaj¹cej lufê moŸdzierza</param>
        /// Opis pozosta³ych parametrów w definicji nadklasy.
        public Shell (
            string name, double mass, decimal price, double muzzleVelocity) : 
            base (name, mass, price)
        {
            MuzzleVelocity = muzzleVelocity;
        }
        /// <summary>
        /// Prêdkoœæ wylotowa (w metrach na sekundê) petardy opuszczaj¹cej 
        /// lufê moŸdzierza.
        /// </summary>
        public double MuzzleVelocity
        {
            get
            {
                return _muzzleVelocity;
            }
            set
            {
                _muzzleVelocity = value;
            }
        }
	}
}
