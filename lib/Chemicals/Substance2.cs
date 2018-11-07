using System;

namespace Chemicals
{
    /// <summary>
    /// Klasa reprezentuj¹ca partiê zwi¹zku chemicznego.
    /// </summary>
    public class Substance2
    {
        private double _grams;
        private Chemical _chemical;

        /// <summary>
        /// Modeluje partiê substancji. Klasa przekszta³cona z pierwotnej
        /// klasy Substance tak, by zale¿a³a od niezmiennych obiektów klasy
        /// Chemical.
        /// </summary>
        /// <param name="grams">Masa tej partii substancji</param>
        /// <param name="chemical">Sk³ad chemiczny partii</param>
        public Substance2 (double grams, Chemical chemical)
        {
            _grams = grams; 
            _chemical = chemical;
        }
        /// <summary>
        /// Nazwa substancji, na przyk³ad "Saletra".
        /// </summary>
        public string Name
        {
            get
            {
                return _chemical.Name;
            }
        }
        /// <summary>
        /// Wzór chemiczny substancji, na przyk³ad "KNO3".
        /// </summary>
        public string Symbol
        {
            get
            {
                return _chemical.Symbol;
            }
        }
        /// <summary>
        /// Masa atomowa substancji (dla saletry by³oby to 101).
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
