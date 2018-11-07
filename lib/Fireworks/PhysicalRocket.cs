using System;

namespace Fireworks
{
    /// <summary>
    /// Fizyczny model rakiety, u¿ywany w symulacjach.
    /// </summary>
    public class PhysicalRocket
    { 
        private double _burnArea; 
        private double _burnRate;
        private double _initialFuelMass;
        private double _totalMass;

        private double _totalBurnTime;

        private static double SPECIFIC_IMPULSE = 620; // niutony/Kg
        private static double FUEL_DENSITY = 1800; // Kg/M**3

        public PhysicalRocket(
            double burnArea, double burnRate, double fuelMass, double totalMass)
        {
            _burnArea = burnArea;
            _burnRate = burnRate;
            _initialFuelMass = fuelMass;
            _totalMass = totalMass;
            
            double _initialFuelVolume = _initialFuelMass / FUEL_DENSITY;
            _totalBurnTime = _initialFuelVolume / (_burnRate * _burnArea);
        }
        /// <summary>
        /// Pozosta³a masa rakiety po spaleniu czêœci paliwa.
        /// </summary>
        /// <param name="time">czas od zap³onu</param>
        /// <returns></returns>
        public double GetMass(double t)
        {
            if (t > _totalBurnTime) return _totalMass - _initialFuelMass;
            double burntFuelVolume = _burnRate * _burnArea * t;
            return _totalMass - burntFuelVolume * FUEL_DENSITY;
        }
        /// <summary>
        /// Obliczenie ci¹gu za pomoc¹ standardowego wzoru Oozinoz.
        /// </summary>
        /// <param name="time">czas od zap³onu</param>
        /// <returns></returns>
        public double GetThrust(double time)
        {  
            if (time > _totalBurnTime) return 0;
            return FUEL_DENSITY * SPECIFIC_IMPULSE * _burnRate * _burnArea;
        }
        /// <summary>
        /// Zwraca czas spalania paliwa danej rakiety.
        /// </summary>
        /// <returns>czas spalania paliwa danej rakiety</returns>
        public double GetBurnTime()
        {
            return _totalBurnTime;
        }
    }
}
