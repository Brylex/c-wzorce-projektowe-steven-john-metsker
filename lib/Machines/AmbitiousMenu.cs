using System;

namespace Machines
{
    /// <summary>
    /// Ta nieco dysfunkcyjna klasa pokazuje metodê ze zbyt ambitnego menu,
    /// samodzielnie lokalizuj¹c¹ in¿yniera odpowiedzialnego za dany sprzêt.
    /// W rozdziale Chain of Responsibility, kod tej metody jest przekszta³cony 
    /// tak, by to obiekty z dziedziny problemu ustala³y in¿yniera 
    /// odpowiedzialnego.
    /// </summary>
    public class AmbitiousMenu 
    {
        /// <summary>
        /// Zwraca in¿yniera odpowiedzialnego za maszynê lub narzêdzie 
        /// reprezentowany przez dany obiekt.
        /// </summary>
        /// <param name="item">sprawdzany obiekt</param>
        /// <returns>in¿ynier odpowiedzialny</returns>
        public Engineer GetResponsible(VisualizationItem item)
        {
            if (item is Tool)
            {
                Tool t = (Tool) item;
                return t.ToolCart.Responsible;
            }
            if (item is ToolCart)
            {
                ToolCart tc = (ToolCart) item;
                return tc.Responsible;
            }
            if (item is MachineComponent)
            {
                MachineComponent c = (MachineComponent) item;
                if (c.Responsible != null) 
                {
                    return c.Responsible;
                }
                if (c.Parent != null)
                {
                    return c.Parent.Responsible;
                }
            }
            return null;
        }
    }
}
