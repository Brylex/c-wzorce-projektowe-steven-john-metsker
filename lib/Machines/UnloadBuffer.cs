using System;
namespace Machines
{
    /// <summary>
    /// Modeluje pas transmisyjny zawierający pojemniki gotowych materiałów.
    /// </summary>
    public class UnloadBuffer : Machine
    {
        /// <summary>
        /// Tworzy maszynę o podanym identyfikatorze i maszynie macierzystej.
        /// </summary>
        /// <param name="id">identyfikator maszyny</param>
        public UnloadBuffer(int id) : base (id)
        {
        }
    }
}
