using System;
namespace Machines
{
    /// <summary>
    /// Interfejs stanowi¹cy czêœæ interfejsu u¿ytkownika dla symulacji
    /// omówionej w rozdziale Chain of Responsibility.
    /// </summary>
    public interface VisualizationItem 
    {
        /// <summary>
        /// Zwraca in¿yniera odpowiedzialnego za maszynê modelowan¹
        /// przez dany obiekt symulacji.
        /// </summary>
        Engineer Responsible { get;}
    }
}
