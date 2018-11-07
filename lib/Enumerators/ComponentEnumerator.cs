using System;
using System.Collections;
using Utilities;
namespace Enumerators
{
    /// <summary>
    /// Abstrakcyjna nadklasa dla enumeratorów, definiuj¹ca metody do 
    /// przechodzenia po liœciach i kompozytach w ramach drzewa kompozytów.
    /// </summary>
    public abstract class ComponentEnumerator : IEnumerator
    {
        protected Object _head;
        protected Set _visited;
        protected Object _current;
        protected bool _returnInterior = true;

        /// <summary>
        /// Zwraca bie¿¹cy wêze³.
        /// </summary>
        public Object Current 
        {
            get
            {
                return _current;
            }
        }

        /// <summary>
        /// Okreœla, czy wewnêtrzne wêz³y powinny wystêpowaæ iteracyjnie.
        /// </summary>
        public bool ReturnInterior
        {
            get
            {
                return _returnInterior;
            }
            set 
            {
                _returnInterior = value;
            }
        }
        /// <summary>
        /// Tworzy enumerator nad wêz³em w ramach kompozytu.
        /// </summary>
        /// <param name="node">wêze³ do przechodzenia</param>
        /// <param name="visited">zbiór do zapisywania odwiedzonych wêz³ów</param>
        public ComponentEnumerator(Object head, Set visited)
        {
            _head = head;
            _visited = visited;
        }

        /// <summary>
        /// Zwraca bie¿¹c¹ g³êbokoœæ iteracji.
        /// </summary>
        /// <returns>bie¿¹c¹ g³êbokoœæ iteracji (tzn. iloœæ wêz³ów nad bie¿¹cym)</returns>
        public abstract int Depth();

        /// <summary>
        /// Przesuniêcie enumeratora.
        /// </summary>
        /// <returns>true jeœli dostêpny jest kolejny wêze³</returns>
        public abstract bool MoveNext();

        /// <summary>
        /// Operacja nieobs³ugiwana.
        /// </summary>
        public void Reset() 
        { 
            throw new InvalidOperationException("Funkcja Reset() nie jest jeszcze obs³ugiwana!"); 
        }
    }
}
