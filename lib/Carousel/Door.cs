using System;

namespace Carousel
{
    /// <summary>
    /// Klasa dostarczaj�ca pocz�tkowy model drzwi karuzeli, zarz�dzaj�cy
    /// swym stanem bez umieszczania logiki zwi�zanej ze stanem w osobnych
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
        ///  U�ytkownik karuzeli nacisn�� jej przycisk. Jest to przycisk
        ///  wielofunkcyjny, a jego zachowanie zale�y od bie��cego stanu
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
        /// Powiadomienie od fizycznej karuzeli, �e zako�czy�o si� 
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
        /// Zwraca tekstowy opis bie��cego stanu drzwi.
        /// </summary>
        /// <returns>tekstowy opis bie��cego stanu drzwi</returns>
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
                    return "Otwarte na sta�e";
                default :
                    return "Zamkni�te";
            }
        }

        /// <summary>
        /// Powiadomienie od fizycznej karuzeli, �e tolerowany czas otwarcia
        /// drzwi min��.
        /// </summary>
        public void Timeout()
        {
            SetState(CLOSING);
        }
    }
}
