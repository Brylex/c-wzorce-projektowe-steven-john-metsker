using System;
namespace Machines
{
    /// <summary>
    /// Modeluje pas transmisyjny zawieraj¹cy pojemniki gotowych materia³ów.
    /// </summary>
    public class UnloadBuffer : Machine
    {
        /// <summary>
        /// Tworzy maszynê o podanym identyfikatorze i maszynie macierzystej.
        /// </summary>
        /// <param name="id">identyfikator maszyny</param>
        public UnloadBuffer(int id) : base (id)
        {
        }
    }
}
