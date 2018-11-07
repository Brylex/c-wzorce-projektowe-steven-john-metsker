using System;

namespace Machines
{
    /// <summary>
    /// Ta nieco dysfunkcyjna klasa pokazuje metod� ze zbyt ambitnego menu,
    /// samodzielnie lokalizuj�c� in�yniera odpowiedzialnego za dany sprz�t.
    /// W rozdziale Chain of Responsibility, kod tej metody jest przekszta�cony 
    /// tak, by to obiekty z dziedziny problemu ustala�y in�yniera 
    /// odpowiedzialnego.
    /// </summary>
    public class AmbitiousMenu 
    {
        /// <summary>
        /// Zwraca in�yniera odpowiedzialnego za maszyn� lub narz�dzie 
        /// reprezentowany przez dany obiekt.
        /// </summary>
        /// <param name="item">sprawdzany obiekt</param>
        /// <returns>in�ynier odpowiedzialny</returns>
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
