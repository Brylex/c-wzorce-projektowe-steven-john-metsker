using System;

namespace Fireworks
{
    /// <summary>
    /// Fajerwerk z w³asnym napêdem.
    /// </summary>
    public class Rocket : Firework
    {
        private double _apogee;
        private double _thrust;

        /// Umo¿liwia tworzenie pustych obiektów w celu obs³u¿enia rekonstrukcji
        /// z pamiêci trwa³ej.
        public Rocket()
        {
        }
        /// <summary>
        /// Utworzenie rakiety o podanych w³asnoœciach.
        /// </summary>
        /// <param name="apogee">Maksymalna wysokoœæ (w metrach), jak¹
        /// rakieta ma osi¹gaæ</param>
        /// <param name="thrust">Nominalny ci¹g (si³a w niutonach) dla tej
        /// rakiety</param>
        /// Opis pozosta³ych parametrów w definicji nadklasy
        public Rocket(string name, double mass, decimal price, double apogee, double thrust) : 
            base (name, mass, price)
        {
            Apogee = apogee;
            Thrust = thrust;
        }
        /// <summary>
        /// Maksymalna wysokoœæ (w metrach), jak¹ rakieta ma osi¹gaæ.
        /// </summary>
        public double Apogee 
        {
            get
            {
                return _apogee;
            }
            set  
            {
                _apogee = value;
            }
        }
        /// <summary>
        /// Nominalny ci¹g (si³a w niutonach) dla tej rakiety.
        /// </summary>
        public double Thrust 
        {
            get
            {
                return _thrust;
            }
            set  
            {
                _thrust = value;
            }
        }
    }
}
