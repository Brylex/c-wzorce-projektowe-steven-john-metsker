using System;

namespace Machines
{
    /// <summary>
    /// Model maszyny montuj�cej lonty w petardzie powietrznej.
    /// </summary>
    public class Fuser : Machine
    {
        /// <summary>
        /// Tworzy maszyn� o podanym identyfikatorze i podanej maszynie
        /// macierzystej.
        /// </summary>
        /// <param name="id">identyfikator maszyny</param>
        public Fuser(int id) : base (id)
        {
        }
    }
}
