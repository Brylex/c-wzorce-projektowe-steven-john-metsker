using System;
using System.Collections;
using Enumerators;
using Utilities;
namespace Processes
{
    /// <summary>
    /// Obiekty tej klasy reprezentuj� pojedyncze etapy proces�w lub 
    /// z�o�enia etap�w proces�w. Proces to w uproszczeniu przepis przygotowania
    /// okre�lonego produktu - w tym przypadku fajerwerk�w.
    /// </summary>
    public abstract class ProcessComponent : ICompositeEnumerable
    {
        protected String _name;
        /// <summary>
        /// Tworzy komponent procesu o zadanej nazwie.
        /// </summary>
        /// <param name="name">nazwa komponentu procesu</param>
        public ProcessComponent(String name)
        {
            _name = name;
        }
        /// <summary>
        /// Przyjmuje go�cia.
        /// </summary>
        /// <param name="v">go��</param>
        public abstract void Accept(IProcessVisitor v);
        /// <summary>
        /// Zwraca nazw� komponentu.
        /// </summary>
        public String Name
        {
            get 
            {
                return _name;
            }
        }
        /// <summary>
        /// Zwraca enumerator do bezpiecznego przechodzenia tego kompozytu.
        /// </summary>
        /// <returns>enumerator do bezpiecznego przechodzenia tego kompozytu</returns>
        public IEnumerator GetEnumerator()
        {
            return GetEnumerator(new Set());
        }
        /// <summary>
        /// Zwraca odpowiedniego typu iterator komponent�w.
        /// </summary>
        /// <param name="visited">Zbi�r poprzednio odwiedzonych w�z��w</param>
        /// <returns>odpowiedniego typu iterator komponent�w</returns>
        public abstract ComponentEnumerator GetEnumerator(Set visited);

        /// <summary>
        /// Zwraca liczb� etap�w b�d�cych li��mi bie��cego kompozytu.
        /// </summary>
        /// <returns>liczb� etap�w b�d�cych li��mi bie��cego kompozytu</returns>
        public int GetStepCount()
        {
            return GetStepCount(new Hashtable());
        }
        /// <summary>
        /// Zwraca liczb� etap�w b�d�cych li��mi bie��cego kompozytu.
        /// </summary>
        /// <param name="visited">zbi�r komponent�w ju� odwiedzonych w ramach 
        /// przechodzenia bie��cego w�z�a</param>
        /// <returns>liczb� etap�w b�d�cych li��mi bie��cego kompozytu</returns>
        public abstract int GetStepCount(Hashtable visited);
        /// <summary>
        /// Zwraca tekstow� reprezentacj� bie��cego komponentu.
        /// </summary>
        /// <returns>tekstow� reprezentacj� bie��cego komponentu</returns>
        public override String ToString()
        {
            return _name;
        }
    }
}
