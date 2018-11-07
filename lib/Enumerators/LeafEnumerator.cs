using System;
using Utilities;
namespace Enumerators
{
    /// <summary>
    /// "Enumeracja" liœcia, czyli pojedyncze jego zwrócenie.
    /// </summary>
    public class LeafEnumerator: ComponentEnumerator 
    {
        /// <summary>
        /// Utworzenie "enumeratora" dla bezdzietnego wêz³a kompozytu.
        /// </summary>
        /// <param name="node">wêze³ do przejœcia</param>
        /// <param name="visited">zbiór odwiedzonych wêz³ów</param>
        public LeafEnumerator(Object node, Set visited) : base(node, visited)
        {        
        }

        /// <summary>
        /// Zwraca zero, gdy¿ g³êbokoœæ iteratora poni¿ej liœcia jest
        /// zawsze równa zero.
        /// </summary>
        /// <returns>zero, gdy¿ g³êbokoœæ iteratora poni¿ej liœcia jest
        /// zawsze równa zero</returns>
        public override int Depth()
        {
            return 0;
        }

        /// <summary>
        /// Ustawienie wêz³a jako bie¿¹cego, jeœli jeszcze na nim nie jesteœmy.
        /// W przeciwnym razie zwraca false.
        /// </summary>
        /// <returns>true jeœli jeszcze nie jesteœmy na tym wêŸle</returns>
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
