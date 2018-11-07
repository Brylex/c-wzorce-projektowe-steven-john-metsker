using System; 

namespace Chemicals
{
    /// <summary>
    /// Klasa reprezentuj¹ca zwi¹zek chemiczny.
    /// </summary>
    public class Chemical
    {
        private String _name;
        private String _symbol;
        private double _atomicWeight;

        /// <summary>
        /// Modeluje zwi¹zek chemiczny, na przyk³ad saletrê.
        /// </summary>
        /// <param name="name">Nazwa zwi¹zku, na przyk³ad "Saletra".</param>
        /// <param name="symbol">Wzór chemiczny zwi¹zku, na przyk³ad "KNO3".</param>
        /// <param name="atomicWeight">Masa atomowa zwi¹zku (dla saletry by³oby to 101).</param>
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
        /// Nazwa zwi¹zku, na przyk³ad "Saletra".
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
        }
        /// <summary>
        /// Wzór chemiczny zwi¹zku, na przyk³ad "KNO3".
        /// </summary>
        public string Symbol
        {
            get
            {
                return _symbol;
            }
        }
        /// <summary>
        /// Masa atomowa zwi¹zku (dla saletry by³oby to 101).
        /// </summary>
        public double AtomicWeight
        {
            get
            {
                return _atomicWeight;
            }
        }
        /// <summary>
        /// Opis zwi¹zku chemicznego.
        /// </summary>
        /// <returns>tekstowy opis zwi¹zku</returns>
        public override String ToString()
        {
            return _name + "(" + _symbol + ")[" + _atomicWeight + "]";
        }
    }
}
