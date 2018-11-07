using System;
using System.Collections;
using Utilities;
namespace Enumerators
{
    /// <summary>
    /// Iteracja po komponencie posiadaj¹cym potomków.
    /// </summary>
    public class CompositeEnumerator : ComponentEnumerator 
    {
        protected IEnumerator _childEnumerator;
        protected ComponentEnumerator _subEnumerator;
        /// <summary>
        /// Utworzenie enumeratora nad komponentem posiadaj¹cym potomków.
        /// </summary>
        /// <param name="node">wêze³ do przechodzenia</param>
        /// <param name="children">wêz³y potomne</param>
        /// <param name="visited">zbiór do zapisywania odwiedzonych wêz³ów</param>
        public CompositeEnumerator(Object node, IList children, Set visited) : base (node, visited)
        {
            _childEnumerator = children.GetEnumerator();
        }
        /// <summary>
        /// Zwraca bie¿¹c¹ g³êbokoœæ iteracji. Iteratory przechodz¹ drzewo
        /// w g³¹b, wiêc g³êbokoœæ iteracji to g³êbokoœæ poprzedniej iteracji
        /// plus jeden.
        /// </summary>
        /// <returns>bie¿¹c¹ g³êbokoœæ iteracji (tzn. iloœæ wêz³ów nad bie¿¹cym)</returns>
        public override int Depth()
        {
            if (_subEnumerator != null)
            {
                return _subEnumerator.Depth() + 1;
            }
            return 0;
        }
        /// <summary>
        /// Przesuniêcie enumeratora.
        /// </summary>
        /// <returns>true jeœli dostêpny jest kolejny wêze³</returns>
        public override bool MoveNext()
        {
            if (!_visited.Contains(_head))
            {
                _visited.Add(_head);
                if (ReturnInterior)
                {
                    _current = _head;
                    return true;
                }
            }
            return SubenumeratorNext();
        }
        /// <summary>
        /// Na ogó³ metoda po prostu przechodzi do nastêpnego elementu
        /// poprzedniego iteratora, jednak jeœli takowy nie istnieje lub
        /// nie ma nastêpnego elementu, metoda tworzy enumerator dla 
        /// nastêpnego potomka (jeœli go nie ma, zwracane jest false)
        /// i zwraca nastêpny element tego enumeratora. 
        /// </summary>
        /// <returns>true jeœli dostêpny jest kolejny wêze³</returns>
        protected bool SubenumeratorNext()
        {
            while (true)
            {
                if (_subEnumerator != null)
                {
                    if (_subEnumerator.MoveNext())
                    {
                        _current = _subEnumerator.Current;
                        return true;
                    }
                }
                if (!_childEnumerator.MoveNext())
                {
                    _current = null;
                    return false;
                }
                ICompositeEnumerable c = (ICompositeEnumerable) _childEnumerator.Current;
                if (!_visited.Contains(c))
                {
                    _subEnumerator = c.GetEnumerator(_visited);
                    _subEnumerator.ReturnInterior = ReturnInterior;
                }
            }
        }
    }
}
