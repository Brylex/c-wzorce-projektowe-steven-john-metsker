using System;
using Utilities;
namespace Enumerators
{
    /// <summary>
    /// "Enumeracja" li�cia, czyli pojedyncze jego zwr�cenie.
    /// </summary>
    public class LeafEnumerator: ComponentEnumerator 
    {
        /// <summary>
        /// Utworzenie "enumeratora" dla bezdzietnego w�z�a kompozytu.
        /// </summary>
        /// <param name="node">w�ze� do przej�cia</param>
        /// <param name="visited">zbi�r odwiedzonych w�z��w</param>
        public LeafEnumerator(Object node, Set visited) : base(node, visited)
        {        
        }

        /// <summary>
        /// Zwraca zero, gdy� g��boko�� iteratora poni�ej li�cia jest
        /// zawsze r�wna zero.
        /// </summary>
        /// <returns>zero, gdy� g��boko�� iteratora poni�ej li�cia jest
        /// zawsze r�wna zero</returns>
        public override int Depth()
        {
            return 0;
        }

        /// <summary>
        /// Ustawienie w�z�a jako bie��cego, je�li jeszcze na nim nie jeste�my.
        /// W przeciwnym razie zwraca false.
        /// </summary>
        /// <returns>true je�li jeszcze nie jeste�my na tym w�le</returns>
        public override bool MoveNext()
        {
            if (_visited.Contains(_head))
            {
                _current = null;
                return false;
            }
            _visited.Add(_head);
            _current = _head;
            return true;
        }
    }
}
