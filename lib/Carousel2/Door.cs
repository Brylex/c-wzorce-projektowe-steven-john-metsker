using System;

namespace Carousel2
{
    /// <summary>
    /// Przekszta³cona wersja klasy Door. Logika obs³ugi stanu drzwi
    /// zosta³a umieszczona w osobnej hierarchii klas.
    /// </summary>
    public class Door
    {
        public ChangeHandler Change;
        private DoorState _state; 

        /// <summary>
        /// Inicjalizacja bie¿¹cych drzwi.
        /// </summary>
        public Door()
        {
            _state = DoorState.CLOSED;
        }

        /// <summary>
        ///  U¿ytkownik karuzeli nacisn¹³ jej przycisk. Jest to przycisk
        ///  wielofunkcyjny, a jego zachowanie zale¿y od bie¿¹cego stanu
        ///  drzwi.
        /// </summary>
        public void Touch()
        {
            _state.Touch(this);
        }

        /// <summary>
        /// Powiadomienie od fizycznej karuzeli, ¿e zakoñczy³o siê 
        /// otwieranie lub zamykanie jej drzwi.
        /// </summary>
        public void Complete()
        {
            _state.Complete(this);
        }

        internal void SetState(DoorState state)
        {
            this._state = state;
            if (Change != null) Change();
        }

        /// <summary>
        /// Zwraca tekstowy opis bie¿¹cego stanu drzwi.
        /// </summary>
        /// <returns>tekstowy opis bie¿¹cego stanu drzwi</returns>
        public String Status()
        {
            return _state.Status();
        }

        /// <summary>
        /// Powiadomienie od fizycznej karuzeli, ¿e tolerowany czas otwarcia
        /// drzwi min¹³.
        /// </summary>
        public void Timeout()
        {
            _state.Timeout(this);
        }
    }
}
