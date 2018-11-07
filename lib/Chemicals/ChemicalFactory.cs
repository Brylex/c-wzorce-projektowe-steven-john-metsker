using System;
using System.Collections;

namespace Chemicals
{
    /// <summary>
    ///  Klasa tworz¹ca i zwracaj¹ca obiekty klasy Chemical. Przekszta³cimy
    ///  j¹ tak, by uczyniæ Chemical interfejsem.
    /// </summary>
    public class ChemicalFactory 
    {
        private static Hashtable _chemicals = new Hashtable();
        static ChemicalFactory ()
        {          
            _chemicals["wegiel"] = new Chemical("Wêgiel", "C", 12);
            _chemicals["siarka"] = new Chemical("Siarka", "S", 32);
            _chemicals["saletra"] = new Chemical("Saletra", "KNO3", 101);
            //...
        }
        /// <summary>
        /// Zwraca obiekt Chemical odpowiadaj¹cy zadanej nazwie.
        /// </summary>
        /// <param name="name">nazwa po¿¹danego zwi¹zku</param>
        /// <returns>obiekt Chemical o zadanej nazwie</returns>
        public static Chemical GetChemical(String name)
        {
            return (Chemical) _chemicals[name.ToLower()];
        }
    }
}
