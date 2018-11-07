using System;

namespace Reservations
{
    /// <summary>
    /// Klasa tworz�ca poprawny obiekt rezerwacji na podstawie otrzymanych
    /// atrybut�w i w miar� mo�liwo�ci wype�niaj�ca brakuj�ce warto�ci.
    /// Miasto i data s� wymagane, a w razie braku danych dla pozosta�ych 
    /// atrybut�w ustawione zostan� rozs�dne warto�ci.
    /// </summary>
    public class ForgivingBuilder : ReservationBuilder 
    {
        public override Reservation Build()  
        {
            bool noHeadcount = (_headcount == 0);
            bool noDollarsPerHead = (_dollarsPerHead == 0M);
            //
            if (noHeadcount && noDollarsPerHead)
            {
                _headcount = MINHEAD;
                _dollarsPerHead = MINTOTAL / _headcount;
            }
            else if (noHeadcount)
            {
                _headcount = (int) Math.Ceiling((double)(MINTOTAL / _dollarsPerHead));
                _headcount = Math.Max(_headcount, MINHEAD);
            }
            else if (noDollarsPerHead)
            {
                _dollarsPerHead = MINTOTAL / _headcount;
            }
            //
            Check();
            return new Reservation(
                _date,
                _headcount,
                _city,
                _dollarsPerHead,
                _hasSite);
        }

        protected void Check() 
        {
            if (_date == DateTime.MinValue)
            {
                throw new BuilderException("Nie znaleziono poprawnej daty!");
            }
            if (_city == null)
            {
                throw new BuilderException("Nie znaleziono poprawnego miasta!");
            }
            if (_headcount < MINHEAD)
            {
                throw new BuilderException(
                    "Minimalna ilo�� widz�w to " + MINHEAD);
            }
            if (_dollarsPerHead * _headcount < MINTOTAL)
            {
                throw new BuilderException(
                    "Minimalny ��czny koszt to " + MINTOTAL);
            }
        }
    }
}