using System;

namespace Fireworks
{
    /// <summary>
    /// Fajerwerk z w�asnym nap�dem.
    /// </summary>
    public class Rocket : Firework
    {
        private double _apogee;
        private double _thrust;

        /// Umo�liwia tworzenie pustych obiekt�w w celu obs�u�enia rekonstrukcji
        /// z pami�ci trwa�ej.
        public Rocket()
        {
        }
        /// <summary>
        /// Utworzenie rakiety o podanych w�asno�ciach.
        /// </summary>
        /// <param name="apogee">Maksymalna wysoko�� (w metrach), jak�
        /// rakieta ma osi�ga�</param>
        /// <param name="thrust">Nominalny ci�g (si�a w niutonach) dla tej
        /// rakiety</param>
        /// Opis pozosta�ych parametr�w w definicji nadklasy
        public Rocket(string name, double mass, decimal price, double apogee, double thrust) : 
            base (name, mass, price)
        {
            Apogee = apogee;
            Thrust = thrust;
        }
        /// <summary>
        /// Maksymalna wysoko�� (w metrach), jak� rakieta ma osi�ga�.
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
        /// Nominalny ci�g (si�a w niutonach) dla tej rakiety.
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
