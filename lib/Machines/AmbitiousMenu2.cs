using System;

namespace Machines
{
    /// <summary>
    /// Klasa pokazuj¹ca zalety refaktoryzacji klasy AmbitiousMenu poprzez
    /// wprowadzenie wzorca Chain of Responsibility.
    /// </summary>
    public class AmbitiousMenu2 
    {
        /// <summary>
        /// Zwraca in¿yniera odpowiedzialnego za maszynê lub narzêdzie 
        /// reprezentowany przez dany obiekt.
        /// </summary>
        /// <param name="item">sprawdzany obiekt</param>
        /// <returns>in¿ynier odpowiedzialny</returns>
        public Engineer GetResponsible(VisualizationItem item)
        {
            return item.Responsible;
        }
    }
}
