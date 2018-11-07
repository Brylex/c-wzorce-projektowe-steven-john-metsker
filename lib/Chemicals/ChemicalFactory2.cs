using System;
using System.Collections;

namespace Chemicals
{
    /// <summary>
    ///  Klasa tworz¹ca i zwracaj¹ca obiekty implementuj¹ce IChemical.
    ///  jest to wersja przekszta³cona, zapewniaj¹ca ¿e tylko klasa
    ///  fabryczna mo¿e tworzyæ obiekty klasy Chemical.
    /// </summary>
    public class ChemicalFactory2 
    {
        private static Hashtable _chemicals = new Hashtable();
        private class ChemicalImpl : IChemical
        {
            private String _name;
            private String _symbol;
            private double _atomicWeight;
            internal ChemicalImpl (
                String name, String symbol, double atomicWeight)
            {
                _name = name;
                _symbol = symbol;
                _atomicWeight = atomicWeight;
            }
            public string Name
            {
                get { return _name; }
            }
            public string Symbol
            {
                get { return _symbol; }
            }
            public double AtomicWeight
            {
                get { return _atomicWeight; }
            }
        }
        static ChemicalFactory2 ()
        {          
            _chemicals["wegiel"] = new ChemicalImpl("Wêgiel", "C", 12);
            _chemicals["siarka"] = new ChemicalImpl("Siarka", "S", 32);
            _chemicals["saletra"] = new ChemicalImpl("Saletra", "KNO3", 101);
            //...
        }
        /// <summary>
        /// Zwraca obiekt IChemical o zadanej nazwie.
        /// </summary>
        /// <param name="name">nazwa po¿¹danego zwi¹zku</param>
        /// <returns>obiekt IChemical o podanej nazwie</returns>
        public static IChemical GetChemical(String name)
        {
            return (IChemical) _chemicals[name.ToLower()];
        }
    }
}
