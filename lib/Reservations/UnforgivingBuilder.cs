using System;
namespace Reservations
{
    /// <summary>
    /// Klasa tworz¹ca poprawny obiekt rezerwacji na podstawie otrzymanych
    /// atrybutów. Metoda <code>build</code> zwraca wyj¹tek, jeœli brakuje
    /// choæ jednego z parametrów rezerwacji.
    /// </summary>
    public class UnforgivingBuilder : ReservationBuilder 
    {
        /// <summary>
        /// Tworzy poprawn¹ rezerwacjê, zwracaj¹c wyj¹tek w przypadku
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
                    "Minimalna iloœæ widzów to " + MINHEAD); 
            }
            if (_dollarsPerHead * _headcount < MINTOTAL) 
            {
                throw new BuilderException(
                    "Minimalny ³¹czny koszt to " + MINTOTAL); 
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
