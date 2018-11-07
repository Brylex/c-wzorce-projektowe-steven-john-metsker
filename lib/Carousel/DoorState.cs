using System;

namespace Carousel
{
	/// <summary>
	/// Nadklasa konkretnych stanów drzwi (na przyk³ad DoorOpen). Klasa 
	/// definiuje interfejs klasy stanu drzwi i dostarcza zmienn¹ instancji
	/// sk³aduj¹c¹ odwo³anie do konkretnych drzwi.
	/// </summary>
	public abstract class DoorState
	{
		protected Door2 _door;

        /// <summary>
        /// Konstrukcja stanu dostarczonych drzwi.
        /// </summary>
        /// <param name="door">drzwi wymagaj¹ce modelu stanu</param>
        public DoorState(Door2 door)
        {
            _door = door;
        }

        /// <summary>
        /// Klasy potomne musz¹ same zdecydowaæ o dzia³aniu podejmowanym
        /// w chwili naciœniêcia przycisku karuzeli przez u¿ytkownika.
        /// </summary>
        public abstract void Touch();

        /// <summary>
        /// Powiadomienia o zakoñczeniu otwierania lub zamykania drzwi s¹
        /// domyœlnie ignorowane.
        /// </summary>
        public virtual void Complete()
        {
        }

        /// <summary>
        /// Powiadomienia o rozpoczêciu zamykania z powodu przekroczenia
        /// czasu otwarcia s¹ domyœlnie ignorowane.
        /// </summary>
        public virtual void Timeout()
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
