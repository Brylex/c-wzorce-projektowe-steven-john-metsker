using System;

namespace Carousel2
{
	/// <summary>
	/// Przekszta³cona wersja klasy z pierwotnej przestrzeni nazw Carousel.
	/// W tym przypadku obiekt drzwi jest przekazywany miêdzy stanami,
	/// podczas gdy poprzednio wszystkie stany odwo³ywa³y siê do konkretnego
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
        /// Klasy potomne musz¹ same zdecydowaæ o dzia³aniu podejmowanym
        /// w chwili naciœniêcia przycisku karuzeli przez u¿ytkownika.
        /// </summary>
        public abstract void Touch(Door door);

        /// <summary>
        /// Powiadomienia o zakoñczeniu otwierania lub zamykania drzwi s¹
        /// domyœlnie ignorowane.
        /// </summary>
        public virtual void Complete(Door door)
        {
        }

        /// <summary>
        /// Powiadomienia o rozpoczêciu zamykania z powodu przekroczenia
        /// czasu otwarcia s¹ domyœlnie ignorowane.
        /// </summary>
        public virtual void Timeout(Door door)
        {
        }

        /// <summary>
        /// Zwraca tekstowy opis bie¿¹cego stanu.
        /// </summary>
        /// <returns>tekstowy opis bie¿¹cego stanu</returns>
        public String Status()
        {
            return this.GetType().Name;
        }
	}    
}
