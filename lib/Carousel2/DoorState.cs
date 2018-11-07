using System;

namespace Carousel2
{
	/// <summary>
	/// Przekszta�cona wersja klasy z pierwotnej przestrzeni nazw Carousel.
	/// W tym przypadku obiekt drzwi jest przekazywany mi�dzy stanami,
	/// podczas gdy poprzednio wszystkie stany odwo�ywa�y si� do konkretnego
   /// obiektu drzwi.
	/// </summary>
	public abstract class DoorState
	{
        public static readonly DoorState CLOSED   = new DoorClosed();
        public static readonly DoorState OPENING  = new DoorOpening();
        public static readonly DoorState OPEN     = new DoorOpen();
        public static readonly DoorState CLOSING  = new DoorClosing();
        public static readonly DoorState STAYOPEN = new DoorStayOpen();

        /// <summary>
        /// Klasy potomne musz� same zdecydowa� o dzia�aniu podejmowanym
        /// w chwili naci�ni�cia przycisku karuzeli przez u�ytkownika.
        /// </summary>
        public abstract void Touch(Door door);

        /// <summary>
        /// Powiadomienia o zako�czeniu otwierania lub zamykania drzwi s�
        /// domy�lnie ignorowane.
        /// </summary>
        public virtual void Complete(Door door)
        {
        }

        /// <summary>
        /// Powiadomienia o rozpocz�ciu zamykania z powodu przekroczenia
        /// czasu otwarcia s� domy�lnie ignorowane.
        /// </summary>
        public virtual void Timeout(Door door)
        {
        }

        /// <summary>
        /// Zwraca tekstowy opis bie��cego stanu.
        /// </summary>
        /// <returns>tekstowy opis bie��cego stanu</returns>
        public String Status()
        {
            return this.GetType().Name;
        }
	}    
}
