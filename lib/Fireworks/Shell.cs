using System;

namespace Fireworks
{
	/// <summary>
   /// Fajerwerk wystrzeliwany z mo�dzierza i eksploduj�cy wysoko na niebie.
	/// </summary>
	public class Shell : Firework
	{
        private double _muzzleVelocity;
        /// <summary>
        /// Tworzy pust� petard�.
        /// </summary>
        public Shell()
        {
        }
        /// <summary>
        /// Tworzy petard� o podanych w�a�ciwo�ciach.
        /// </summary>
        /// <param name="muzzleVelocity">Pr�dko�� wylotowa (w metrach na sekund�)
        /// petardy opuszczaj�cej luf� mo�dzierza</param>
        /// Opis pozosta�ych parametr�w w definicji nadklasy.
        public Shell (
            string name, double mass, decimal price, double muzzleVelocity) : 
            base (name, mass, price)
        {
            MuzzleVelocity = muzzleVelocity;
        }
        /// <summary>
        /// Pr�dko�� wylotowa (w metrach na sekund�) petardy opuszczaj�cej 
        /// luf� mo�dzierza.
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
