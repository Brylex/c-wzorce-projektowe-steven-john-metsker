using System;
namespace Reservations
{
    /// <summary>
    /// Klasa tworz�ca poprawny obiekt rezerwacji na podstawie otrzymanych
    /// atrybut�w. Metoda <code>build</code> zwraca wyj�tek, je�li brakuje
    /// cho� jednego z parametr�w rezerwacji.
    /// </summary>
    public class UnforgivingBuilder : ReservationBuilder 
    {
        /// <summary>
        /// Tworzy poprawn� rezerwacj�, zwracaj�c wyj�tek w przypadku
        /// stwierdzenia braku wymaganego atrybutu rezerwacji.
        /// </summary>
        public override Reservation Build() 
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
            return new Reservation(
                _date, 
                _headcount, 
                _city, 
                _dollarsPerHead, 
                _hasSite); 
        }
    }
}
