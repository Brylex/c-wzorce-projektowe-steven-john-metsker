using System;

namespace Simulation
{
    /// <summary>
    /// Instancje tej klasy symuluj¹ rakiety. Symulacja obejmuje przede
    /// wszystkim zachowanie spalanego paliwa.
    /// </summary>
    public class Skyrocket
    {
        private double _mass;
        private double _thrust;
        private double _burnTime;
        protected double _simTime;

        /// <summary>
        /// Tworzy model rakiety.
        /// </summary>
        /// <param name="mass">pocz¹tkowa masa rakiety</param>
        /// <param name="thrust">pocz¹tkowy ci¹g rakiety</param>
        /// <param name="burnTime">czas spalania paliwa rakiety</param>
        public Skyrocket (
            double mass, double thrust, double burnTime) 
        {
            _mass = mass;
            _thrust = thrust;
            _burnTime = burnTime;
        }

        /// <summary>
        /// Model masy polegaj¹cy na jej liniowej redukcji do zera przez 
        /// ca³y czas istnienia paliwa.
        /// </summary>
        /// <returns>masê</returns>
        public virtual double GetMass()   
        {
            if (_simTime > _burnTime) return 0;            
            return _mass * (1 - (_simTime / _burnTime));
        }

        /// <summary>
        /// Model ci¹gu jako wartoœci sta³ej przez ca³y czas istnienia paliwa.
        /// </summary>
        /// <returns>ci¹g</returns>
        public virtual double GetThrust()  
        {
           if (_simTime > _burnTime) return 0;   
           return _thrust;
        }

        /// <summary>
        /// Zapisanie czasu w momencie aktualizacji zegara symulacji.
        /// </summary>
        /// <param name="t">czas symulacji</param>
        public virtual void SetSimTime(double t)
        {
            _simTime = t;
        }
    }
}
