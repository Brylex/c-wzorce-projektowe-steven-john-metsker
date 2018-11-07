using System;
namespace Machines
{
    /// <summary>
    /// Modeluje pas transmisyjny zawieraj�cy pojemniki gotowych materia��w.
    /// </summary>
    public class UnloadBuffer : Machine
    {
        /// <summary>
        /// Tworzy maszyn� o podanym identyfikatorze i maszynie macierzystej.
        /// </summary>
        /// <param name="id">identyfikator maszyny</param>
        public UnloadBuffer(int id) : base (id)
        {
        }
    }
}
