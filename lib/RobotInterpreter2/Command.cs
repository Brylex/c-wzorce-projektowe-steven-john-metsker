using System;
namespace RobotInterpreter2
{
    /// <summary>
    /// Klasa abstrakcyjna reprezentuj�ca hierarchi� klas odpowiadaj�cych
    /// poleceniom. Obiekt polecenia to operacja, kt�ra jest wykonywane
    /// dopiero wtedy, gdy obiekt wywo�uj�cy tego za��da.
    /// 
    /// Klasy potomne najcz�ciej odpowiadaj� jakiej� podstawowej funkcji
    /// i dopuszczaj� parametry dostrajaj�ce polecenie dla konkretnego celu.
    /// Wszystkie klasy polece� musz� implementowa� metod� Execute(), kt�ra
    /// tutaj jest abstrakcyjna.
    /// </summary>
    public abstract class Command 
    {
        /// <summary>
        /// Wykonanie ��dania uj�tego w tym poleceniu.
        /// </summary>
        public abstract void Execute();
    }
}
