using System; 

namespace Chemicals
{
    /// <summary>
    /// Klasa reprezentuj�ca zwi�zek chemiczny.
    /// </summary>
    public class Chemical
    {
        private String _name;
        private String _symbol;
        private double _atomicWeight;

        /// <summary>
        /// Modeluje zwi�zek chemiczny, na przyk�ad saletr�.
        /// </summary>
        /// <param name="name">Nazwa zwi�zku, na przyk�ad "Saletra".</param>
        /// <param name="symbol">Wz�r chemiczny zwi�zku, na przyk�ad "KNO3".</param>
        /// <param name="atomicWeight">Masa atomowa zwi�zku (dla saletry by�oby to 101).</param>
        internal Chemical(
            String name,
            String symbol,
            double atomicWeight)
        {
            _name = name;
            _symbol = symbol;
            _atomicWeight = atomicWeight;
        }
        /// <summary>
        /// Nazwa zwi�zku, na przyk�ad "Saletra".
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
        }
        /// <summary>
        /// Wz�r chemiczny zwi�zku, na przyk�ad "KNO3".
        /// </summary>
        public string Symbol
        {
            get
            {
                return _symbol;
            }
        }
        /// <summary>
        /// Masa atomowa zwi�zku (dla saletry by�oby to 101).
        /// </summary>
        public double AtomicWeight
        {
            get
            {
                return _atomicWeight;
            }
        }
        /// <summary>
        /// Opis zwi�zku chemicznego.
        /// </summary>
        /// <returns>tekstowy opis zwi�zku</returns>
        public override String ToString()
        {
            return _name + "(" + _symbol + ")[" + _atomicWeight + "]";
        }
    }
}
