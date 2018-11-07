using System;

namespace Chemicals
{
    /// <summary>
    /// Klasa reprezentuj�ca parti� zwi�zku chemicznego.
    /// </summary>
    public class Substance2
    {
        private double _grams;
        private Chemical _chemical;

        /// <summary>
        /// Modeluje parti� substancji. Klasa przekszta�cona z pierwotnej
        /// klasy Substance tak, by zale�a�a od niezmiennych obiekt�w klasy
        /// Chemical.
        /// </summary>
        /// <param name="grams">Masa tej partii substancji</param>
        /// <param name="chemical">Sk�ad chemiczny partii</param>
        public Substance2 (double grams, Chemical chemical)
        {
            _grams = grams; 
            _chemical = chemical;
        }
        /// <summary>
        /// Nazwa substancji, na przyk�ad "Saletra".
        /// </summary>
        public string Name
        {
            get
            {
                return _chemical.Name;
            }
        }
        /// <summary>
        /// Wz�r chemiczny substancji, na przyk�ad "KNO3".
        /// </summary>
        public string Symbol
        {
            get
            {
                return _chemical.Symbol;
            }
        }
        /// <summary>
        /// Masa atomowa substancji (dla saletry by�oby to 101).
        /// </summary>
        public double AtomicWeight
        {
            get
            {
                return _chemical.AtomicWeight;
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
                return _grams / AtomicWeight;
            }
        }
    }
}
