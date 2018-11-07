using System;
using System.Text;

namespace Reservations
{
    /// <summary>
    /// Obiekty tej klasy reprezentuj¹ rezerwacje pokazów fajerwerków,
    /// ale klasa nie jest dokoñczona. Jest ona jedynie przyk³adem dla
    /// klas z tego pakietu, ilustruj¹cych wykorzystanie obiektów buduj¹cych.
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
        /// Konstrukcja rezerwacji o zadanych parametrach. Prawid³owym 
        /// sposobem konstruowania rezerwacji jest wykorzystanie jednego 
        /// z obiektów buduj¹cych z tego pakietu, wiêc metoda jest prywatna.
        /// </summary>
        /// <param name="date">data pokazu</param>
        /// <param name="headcount">ilu widzów pokazu klient mo¿e zagwarantowaæ</param>
        /// <param name="city">miasto (lub najbli¿sze miasto) pokazu</param>
        /// <param name="dollarsPerHead">ponoszony przez klienta koszt od osoby</param>
        /// <param name="hasSite">true, jeœli klient wybra³ ju¿ konkretn¹ lokalizacjê</param>
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
            sb.Append(", Iloœæ widzów: ");
            sb.Append(_headcount);
            sb.Append(", Miasto: ");
            sb.Append(_city);
            sb.Append(", Cena/osobê: ");
            sb.Append(_dollarsPerHead);
            sb.Append(", Jest miejsce: ");
            sb.Append(_hasSite);
            return sb.ToString();
        }  
        /// <summary>
        /// Umówiona lub proponowana data pokazu.
        /// </summary>
        public DateTime Date { get { return _date;}}
        /// <summary>
        /// Iloœæ widzów gwarantowana przez klienta.
        /// </summary>
        public int Headcount { get { return _headcount;}}
        /// <summary>
        /// Najbli¿sze miasto.
        /// </summary>
        public String City { get { return _city;}}
        /// <summary>
        /// Cena od widza.
        /// </summary>
        public decimal DollarsPerHead { get { return _dollarsPerHead;}}
        /// <summary>
        /// Okreœla, czy klient wybra³ ju¿ konkretn¹ lokalizacjê.
        /// </summary>
        public bool HasSite { get { return _hasSite;}}
    }
}
