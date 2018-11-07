using System;
using System.Collections;
using Utilities;
namespace Enumerators
{
    /// <summary>
    /// Iteracja po komponencie posiadaj�cym potomk�w.
    /// </summary>
    public class CompositeEnumerator : ComponentEnumerator 
    {
        protected IEnumerator _childEnumerator;
        protected ComponentEnumerator _subEnumerator;
        /// <summary>
        /// Utworzenie enumeratora nad komponentem posiadaj�cym potomk�w.
        /// </summary>
        /// <param name="node">w�ze� do przechodzenia</param>
        /// <param name="children">w�z�y potomne</param>
        /// <param name="visited">zbi�r do zapisywania odwiedzonych w�z��w</param>
        public CompositeEnumerator(Object node, IList children, Set visited) : base (node, visited)
        {
            _childEnumerator = children.GetEnumerator();
        }
        /// <summary>
        /// Zwraca bie��c� g��boko�� iteracji. Iteratory przechodz� drzewo
        /// w g��b, wi�c g��boko�� iteracji to g��boko�� poprzedniej iteracji
        /// plus jeden.
        /// </summary>
        /// <returns>bie��c� g��boko�� iteracji (tzn. ilo�� w�z��w nad bie��cym)</returns>
        public override int Depth()
        {
            if (_subEnumerator != null)
            {
                return _subEnumerator.Depth() + 1;
            }
            return 0;
        }
        /// <summary>
        /// Przesuni�cie enumeratora.
        /// </summary>
        /// <returns>true je�li dost�pny jest kolejny w�ze�</returns>
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
        /// Na og� metoda po prostu przechodzi do nast�pnego elementu
        /// poprzedniego iteratora, jednak je�li takowy nie istnieje lub
        /// nie ma nast�pnego elementu, metoda tworzy enumerator dla 
        /// nast�pnego potomka (je�li go nie ma, zwracane jest false)
        /// i zwraca nast�pny element tego enumeratora. 
        /// </summary>
        /// <returns>true je�li dost�pny jest kolejny w�ze�</returns>
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
