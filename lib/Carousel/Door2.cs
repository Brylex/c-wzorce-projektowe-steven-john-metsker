using System;

namespace Carousel
{
    /// <summary>
    /// Przekszta�cona wersja klasy Door. Logika obs�ugi stanu drzwi
    /// zosta�a umieszczona w osobnej hierarchii klas.
    /// </summary>
    public class Door2
    {
        public readonly DoorState CLOSED;
        public readonly DoorState CLOSING; 
        public readonly DoorState OPEN; 
        public readonly DoorState OPENING; 
        public readonly DoorState STAYOPEN; 
        //
        public ChangeHandler Change;
        private DoorState _state; 

        /// <summary>
        /// Inicjalizacja drzwi.
        /// </summary>
        public Door2()
        {
            CLOSED   = new DoorClosed(this);
            CLOSING  = new DoorClosing(this);
            OPEN     = new DoorOpen(this);
            OPENING  = new DoorOpening(this);
            STAYOPEN = new DoorStayOpen(this);
            _state = CLOSED;
        }

        //
        /// <summary>
        ///  U�ytkownik karuzeli nacisn�� jej przycisk. Jest to przycisk
        ///  wielofunkcyjny, a jego zachowanie zale�y od bie��cego stanu
        ///  drzwi.
        /// </summary>
        public void Touch()
        {
            _state.Touch();
        }

        /// <summary>
        /// Powiadomienie od fizycznej karuzeli, �e zako�czy�o si� 
        /// otwieranie lub zamykanie jej drzwi.
        /// </summary>
        public void Complete()
        {
            _state.Complete();
        }

        internal void SetState(DoorState state)
        {
            this._state = state;
            if (Change != null) Change();
        }

        /// <summary>
        /// Zwraca tekstowy opis bie��cego stanu drzwi.
        /// </summary>
        /// <returns>tekstowy opis bie��cego stanu drzwi</returns>
        public String Status()
        {
            return _state.Status();
        }

        /// <summary>
        /// Powiadomienie od fizycznej karuzeli, �e tolerowany czas otwarcia
        /// drzwi min��.
        /// </summary>
        public void Timeout()
        {
            _state.Timeout();
        }
    }
}
