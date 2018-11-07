using System;
namespace Machines
{
    /// <summary>
    /// Interfejs stanowi�cy cz�� interfejsu u�ytkownika dla symulacji
    /// om�wionej w rozdziale Chain of Responsibility.
    /// </summary>
    public interface VisualizationItem 
    {
        /// <summary>
        /// Zwraca in�yniera odpowiedzialnego za maszyn� modelowan�
        /// przez dany obiekt symulacji.
        /// </summary>
        Engineer Responsible { get;}
    }
}
