using System;

namespace Chemicals
{
    /// <summary>
    /// Klasa reprezentuj�ca okre�lon� parti� zwi�zku chemicznego.
    /// </summary>
    public class Substance 
    {
        private string _name;
        private string _symbol;
        private double _atomicWeight;
        private double _grams;

        /// <summary>
        /// Modeluje parti� substancji.
        /// </summary>
        /// <param name="name">Nazwa substancji, na przyk�ad "Saletra".</param>
        /// <param name="symbol">Wz�r chemiczny substancji, na przyk�ad "KNO3".</param>
        /// <param name="atomicWeight">Masa atomowa substancji (dla saletry by�oby to 101).</param>
        /// <param name="grams">Masa tej partii substancji.</param>
        public Substance (
            string name,
            string symbol,
            double atomicWeight,
            double grams)
        {
            _name = name;
            _symbol = symbol;
            _atomicWeight = atomicWeight;
            _grams = grams; 
        }
        /// <summary>
        /// Nazwa substancji, na przyk�ad "Saletra".
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
        }
        /// <summary>
        /// Wz�r chemiczny substancji, na przyk�ad "KNO3".
        /// </summary>
        public string Symbol
        {
            get
            {
                return _symbol;
            }
        }
        /// <summary>
        /// Masa atomowa substancji (dla saletry by�oby to 101).
        /// </summary>
        public double AtomicWeight
        {
            get
            {
                return _atomicWeight;
            }
        }
        /// <summary>
        /// Masa tej partii substancji.
        /// </summary>
        public double Grams
        {
            get
            {
                return _grams;
            }
        }
        /// <summary>
        /// Liczba moli w tej partii.
        /// </summary>
        public double Moles
        {
            get
            {
                return _grams / _atomicWeight;
            }
        }
    }
}
