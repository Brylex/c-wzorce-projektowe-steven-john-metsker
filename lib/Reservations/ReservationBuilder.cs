using System;

namespace Reservations
{
    /// <summary>
    /// Klasy dziedzicz¹ce z tej klasy abstrakcyjnej sprawdzaj¹ poprawnoœæ
    /// atrybutów rezerwacji przed utworzeniem obiektu Reservation.
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
        /// Przesuniêcie daty w przesz³oœæ poprzez zwiêkszenie roku.
        /// </summary>
        /// <param name="inDate">data do przesuniêcia</param>
        /// <returns>tak¹ sam¹ datê, jak dostarczona, ale z rokiem zmienionym
        /// tak, by by³a ona w przysz³oœci</returns>
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
        /// atrybutów. Klasy potomne mog¹ zg³osiæ wyj¹tek, jeœli nie da siê
        /// utworzyæ poprawnej rezerwacji.
        /// </summary>
        /// <returns>poprawn¹ rezerwacjê</returns>
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
        /// Cena od osoby, jak¹ klient zap³aci za pokaz.
        /// </summary>
        public decimal DollarsPerHead
        {
            get { return _dollarsPerHead; }
            set { _dollarsPerHead = value;}
        }
        /// <summary>
        /// Okreœla, czy klient wybra³ ju¿ konkretn¹ lokalizacjê dla pokazu.
        /// </summary>
        public bool HasSite
        {
            get { return _hasSite; }
            set { _hasSite = value;}
        }
        /// <summary>
        /// Iloœæ widzów gwarantowana przez klienta.
        /// </summary>
        public int Headcount
        {
            get { return _headcount; }
            set { _headcount = value;}
        }
    }
}
