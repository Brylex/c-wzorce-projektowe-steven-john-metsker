using System;
namespace RobotInterpreter2
{
    /// <summary>
    /// Klasa abstrakcyjna reprezentuj¹ca hierarchiê klas odpowiadaj¹cych
    /// poleceniom. Obiekt polecenia to operacja, która jest wykonywane
    /// dopiero wtedy, gdy obiekt wywo³uj¹cy tego za¿¹da.
    /// 
    /// Klasy potomne najczêœciej odpowiadaj¹ jakiejœ podstawowej funkcji
    /// i dopuszczaj¹ parametry dostrajaj¹ce polecenie dla konkretnego celu.
    /// Wszystkie klasy poleceñ musz¹ implementowaæ metodê Execute(), która
    /// tutaj jest abstrakcyjna.
    /// </summary>
    public abstract class Command 
    {
        /// <summary>
        /// Wykonanie ¿¹dania ujêtego w tym poleceniu.
        /// </summary>
        public abstract void Execute();
    }
}
