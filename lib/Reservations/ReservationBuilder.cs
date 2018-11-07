using System;

namespace Reservations
{
    /// <summary>
    /// Klasy dziedzicz�ce z tej klasy abstrakcyjnej sprawdzaj� poprawno��
    /// atrybut�w rezerwacji przed utworzeniem obiektu Reservation.
    /// </summary>
    public abstract class ReservationBuilder      
    {
        public static readonly int MINHEAD = 25;
        public static readonly decimal MINTOTAL = 495.95M;

        protected DateTime _date = DateTime.MinValue;
        protected String _city;
        protected int _headcount;
        protected decimal _dollarsPerHead;
        protected bool _hasSite;

        /// <summary>
        /// Przesuni�cie daty w przesz�o�� poprzez zwi�kszenie roku.
        /// </summary>
        /// <param name="inDate">data do przesuni�cia</param>
        /// <returns>tak� sam� dat�, jak dostarczona, ale z rokiem zmienionym
        /// tak, by by�a ona w przysz�o�ci</returns>
        public static DateTime Futurize(DateTime inDate)
        {
            DateTime outDate = inDate;
            while (outDate.CompareTo(DateTime.Now) < 0)
            {
                outDate = outDate.AddYears(1);
            }
            return outDate;
        }
        /// <summary>
        /// Konstrukcja poprawnej rezerwacji na podstawie dostarczonych
        /// atrybut�w. Klasy potomne mog� zg�osi� wyj�tek, je�li nie da si�
        /// utworzy� poprawnej rezerwacji.
        /// </summary>
        /// <returns>poprawn� rezerwacj�</returns>
        public abstract Reservation Build();

        /// <summary>
        /// Miasto rezerwacji.
        /// </summary>
        public String City
        {
            get { return _city; }
            set { _city = value;}
        }
        /// <summary>
        /// Data rezerwacji.
        /// </summary>
        public DateTime Date
        {
            get { return _date; }
            set { _date = value;}
        }
        /// <summary>
        /// Cena od osoby, jak� klient zap�aci za pokaz.
        /// </summary>
        public decimal DollarsPerHead
        {
            get { return _dollarsPerHead; }
            set { _dollarsPerHead = value;}
        }
        /// <summary>
        /// Okre�la, czy klient wybra� ju� konkretn� lokalizacj� dla pokazu.
        /// </summary>
        public bool HasSite
        {
            get { return _hasSite; }
            set { _hasSite = value;}
        }
        /// <summary>
        /// Ilo�� widz�w gwarantowana przez klienta.
        /// </summary>
        public int Headcount
        {
            get { return _headcount; }
            set { _headcount = value;}
        }
    }
}
