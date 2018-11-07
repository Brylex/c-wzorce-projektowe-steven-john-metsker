using System;
using System.Collections;
using Enumerators;
using Utilities;
namespace Processes
{
    /// <summary>
    /// Obiekty tej klasy reprezentuj¹ pojedyncze etapy procesów lub 
    /// z³o¿enia etapów procesów. Proces to w uproszczeniu przepis przygotowania
    /// okreœlonego produktu - w tym przypadku fajerwerków.
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
        /// Przyjmuje goœcia.
        /// </summary>
        /// <param name="v">goœæ</param>
        public abstract void Accept(IProcessVisitor v);
        /// <summary>
        /// Zwraca nazwê komponentu.
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
        /// Zwraca odpowiedniego typu iterator komponentów.
        /// </summary>
        /// <param name="visited">Zbiór poprzednio odwiedzonych wêz³ów</param>
        /// <returns>odpowiedniego typu iterator komponentów</returns>
        public abstract ComponentEnumerator GetEnumerator(Set visited);

        /// <summary>
        /// Zwraca liczbê etapów bêd¹cych liœæmi bie¿¹cego kompozytu.
        /// </summary>
        /// <returns>liczbê etapów bêd¹cych liœæmi bie¿¹cego kompozytu</returns>
        public int GetStepCount()
        {
            return GetStepCount(new Hashtable());
        }
        /// <summary>
        /// Zwraca liczbê etapów bêd¹cych liœæmi bie¿¹cego kompozytu.
        /// </summary>
        /// <param name="visited">zbiór komponentów ju¿ odwiedzonych w ramach 
        /// przechodzenia bie¿¹cego wêz³a</param>
        /// <returns>liczbê etapów bêd¹cych liœæmi bie¿¹cego kompozytu</returns>
        public abstract int GetStepCount(Hashtable visited);
        /// <summary>
        /// Zwraca tekstow¹ reprezentacjê bie¿¹cego komponentu.
        /// </summary>
        /// <returns>tekstow¹ reprezentacjê bie¿¹cego komponentu</returns>
        public override String ToString()
        {
            return _name;
        }
    }
}
