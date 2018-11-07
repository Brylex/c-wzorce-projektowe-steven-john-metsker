using System;

namespace Reservations
{
    /// <summary>
    /// Klasa tworz¹ca poprawny obiekt rezerwacji na podstawie otrzymanych
    /// atrybutów i w miarê mo¿liwoœci wype³niaj¹ca brakuj¹ce wartoœci.
    /// Miasto i data s¹ wymagane, a w razie braku danych dla pozosta³ych 
    /// atrybutów ustawione zostan¹ rozs¹dne wartoœci.
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
                    "Minimalna iloœæ widzów to " + MINHEAD);
            }
            if (_dollarsPerHead * _headcount < MINTOTAL)
            {
                throw new BuilderException(
                    "Minimalny ³¹czny koszt to " + MINTOTAL);
            }
        }
    }
}