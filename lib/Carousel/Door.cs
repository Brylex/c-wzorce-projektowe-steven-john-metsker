using System;

namespace Carousel
{
    /// <summary>
    /// Klasa dostarczaj¹ca pocz¹tkowy model drzwi karuzeli, zarz¹dzaj¹cy
    /// swym stanem bez umieszczania logiki zwi¹zanej ze stanem w osobnych
    /// klasach.
    /// </summary>
    public class Door  
    {
        public const int CLOSED   = -1;
        public const int OPENING  = -2;
        public const int OPEN     = -3;
        public const int CLOSING  = -4;
        public const int STAYOPEN = -5;
        //
        public ChangeHandler Change;
        private int _state = CLOSED;

        /// <summary>
        ///  U¿ytkownik karuzeli nacisn¹³ jej przycisk. Jest to przycisk
        ///  wielofunkcyjny, a jego zachowanie zale¿y od bie¿¹cego stanu
        ///  drzwi.
        /// </summary>
        public void Touch()
        {
            if (_state == CLOSED)
            {
                SetState(OPENING);
            }
            else if (_state == OPENING || _state == STAYOPEN)
            {
                SetState(CLOSING);
            }
            else if (_state == OPEN)
            {
                SetState(STAYOPEN);
            }
            else if (_state == CLOSING)
            {
                SetState(OPENING);
            }
        }

        /// <summary>
        /// Powiadomienie od fizycznej karuzeli, ¿e zakoñczy³o siê 
        /// otwieranie lub zamykanie jej drzwi.
        /// </summary>
        public void Complete()
        {
            if (_state == OPENING)
            {
                SetState(OPEN);
            }
            else if (_state == CLOSING)
            {
                SetState(CLOSED);
            }
        }

        private void SetState(int state)
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
            switch (_state)
            {
                case OPENING :
                    return "Otwieranie";
                case OPEN :
                    return "Otwarte";
                case CLOSING :
                    return "Zamykanie";
                case STAYOPEN :
                    return "Otwarte na sta³e";
                default :
                    return "Zamkniête";
            }
        }

        /// <summary>
        /// Powiadomienie od fizycznej karuzeli, ¿e tolerowany czas otwarcia
        /// drzwi min¹³.
        /// </summary>
        public void Timeout()
        {
            SetState(CLOSING);
        }
    }
}
