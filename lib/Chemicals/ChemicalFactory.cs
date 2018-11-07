using System;
using System.Collections;

namespace Chemicals
{
    /// <summary>
    ///  Klasa tworz�ca i zwracaj�ca obiekty klasy Chemical. Przekszta�cimy
    ///  j� tak, by uczyni� Chemical interfejsem.
    /// </summary>
    public class ChemicalFactory 
    {
        private static Hashtable _chemicals = new Hashtable();
        static ChemicalFactory ()
        {          
            _chemicals["wegiel"] = new Chemical("W�giel", "C", 12);
            _chemicals["siarka"] = new Chemical("Siarka", "S", 32);
            _chemicals["saletra"] = new Chemical("Saletra", "KNO3", 101);
            //...
        }
        /// <summary>
        /// Zwraca obiekt Chemical odpowiadaj�cy zadanej nazwie.
        /// </summary>
        /// <param name="name">nazwa po��danego zwi�zku</param>
        /// <returns>obiekt Chemical o zadanej nazwie</returns>
        public static Chemical GetChemical(String name)
        {
            return (Chemical) _chemicals[name.ToLower()];
        }
    }
}
