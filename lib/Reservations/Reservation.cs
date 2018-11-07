using System;
using System.Text;

namespace Reservations
{
    /// <summary>
    /// Obiekty tej klasy reprezentuj� rezerwacje pokaz�w fajerwerk�w,
    /// ale klasa nie jest doko�czona. Jest ona jedynie przyk�adem dla
    /// klas z tego pakietu, ilustruj�cych wykorzystanie obiekt�w buduj�cych.
    /// </summary>
    [Serializable]
    public class Reservation 
    {
        private DateTime _date;
        private int _headcount; 
        private String _city;
        private decimal _dollarsPerHead;
        private bool _hasSite;
        /// <summary>
        /// Konstrukcja rezerwacji o zadanych parametrach. Prawid�owym 
        /// sposobem konstruowania rezerwacji jest wykorzystanie jednego 
        /// z obiekt�w buduj�cych z tego pakietu, wi�c metoda jest prywatna.
        /// </summary>
        /// <param name="date">data pokazu</param>
        /// <param name="headcount">ilu widz�w pokazu klient mo�e zagwarantowa�</param>
        /// <param name="city">miasto (lub najbli�sze miasto) pokazu</param>
        /// <param name="dollarsPerHead">ponoszony przez klienta koszt od osoby</param>
        /// <param name="hasSite">true, je�li klient wybra� ju� konkretn� lokalizacj�</param>
        internal Reservation(
            DateTime date,
            int headcount,
            String city,
            decimal dollarsPerHead,
            bool hasSite)
        {
            _date = date;
            _headcount = headcount;
            _city = city;
            _dollarsPerHead = dollarsPerHead;
            _hasSite = hasSite;
        }
        /// <summary>
        /// Zwraca tekstowy opis rezerwacji.
        /// </summary>
        /// <returns>tekstowy opis rezerwacji</returns>
        public override String ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Data: ");
            sb.Append(_date.ToString("d"));
            sb.Append(", Ilo�� widz�w: ");
            sb.Append(_headcount);
            sb.Append(", Miasto: ");
            sb.Append(_city);
            sb.Append(", Cena/osob�: ");
            sb.Append(_dollarsPerHead);
            sb.Append(", Jest miejsce: ");
            sb.Append(_hasSite);
            return sb.ToString();
        }  
        /// <summary>
        /// Um�wiona lub proponowana data pokazu.
        /// </summary>
        public DateTime Date { get { return _date;}}
        /// <summary>
        /// Ilo�� widz�w gwarantowana przez klienta.
        /// </summary>
        public int Headcount { get { return _headcount;}}
        /// <summary>
        /// Najbli�sze miasto.
        /// </summary>
        public String City { get { return _city;}}
        /// <summary>
        /// Cena od widza.
        /// </summary>
        public decimal DollarsPerHead { get { return _dollarsPerHead;}}
        /// <summary>
        /// Okre�la, czy klient wybra� ju� konkretn� lokalizacj�.
        /// </summary>
        public bool HasSite { get { return _hasSite;}}
    }
}
