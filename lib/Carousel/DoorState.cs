using System;

namespace Carousel
{
	/// <summary>
	/// Nadklasa konkretnych stan�w drzwi (na przyk�ad DoorOpen). Klasa 
	/// definiuje interfejs klasy stanu drzwi i dostarcza zmienn� instancji
	/// sk�aduj�c� odwo�anie do konkretnych drzwi.
	/// </summary>
	public abstract class DoorState
	{
		protected Door2 _door;

        /// <summary>
        /// Konstrukcja stanu dostarczonych drzwi.
        /// </summary>
        /// <param name="door">drzwi wymagaj�ce modelu stanu</param>
        public DoorState(Door2 door)
        {
            _door = door;
        }

        /// <summary>
        /// Klasy potomne musz� same zdecydowa� o dzia�aniu podejmowanym
        /// w chwili naci�ni�cia przycisku karuzeli przez u�ytkownika.
        /// </summary>
        public abstract void Touch();

        /// <summary>
        /// Powiadomienia o zako�czeniu otwierania lub zamykania drzwi s�
        /// domy�lnie ignorowane.
        /// </summary>
        public virtual void Complete()
        {
        }

        /// <summary>
        /// Powiadomienia o rozpocz�ciu zamykania z powodu przekroczenia
        /// czasu otwarcia s� domy�lnie ignorowane.
        /// </summary>
        public virtual void Timeout()
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
