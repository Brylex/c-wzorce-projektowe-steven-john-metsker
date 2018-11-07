using System;
using System.Collections;
using Utilities;
namespace Enumerators
{
    /// <summary>
    /// Definicja typu obiektu mog�cego tworzy� iterator.
    /// </summary>
    public interface ICompositeEnumerable: IEnumerable
    {
        /// <summary>
        /// Zwraca iterator komponentu.
        /// </summary>
        ComponentEnumerator GetEnumerator(Set visited);
    }
}
