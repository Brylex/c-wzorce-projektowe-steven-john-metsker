using System;

namespace Machines
{
    /// <summary>
    /// Model maszyny mieszaj¹cej chemikalia.
    /// </summary>
    public class Mixer : Machine
    {
        /// <summary>
        /// Tworzy maszynê o podanym identyfikatorze i maszynie macierzystej.
        /// </summary>
        /// <param name="id">identyfikator maszyny</param>
        public Mixer(int id) : base (id)
        {
        }
    }
}
