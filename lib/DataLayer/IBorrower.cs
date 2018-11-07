using System.Data;
namespace DataLayer 
{
    /// <summary>
    /// Definicja interfejsu pozwalaj�cego klientom po�ycza� obiekt czytaj�cy
    /// z bazy bez troszczenia si� o konieczno�� jego zwolnienia.
    /// </summary>
    public interface IBorrower
    {
        /// <summary>
        /// Korzysta z dostarczonego obiektu czytaj�cego, wiedz�c �e 
        /// obiekt wywo�uj�cy zwolni obiekt po wywo�aniu. Zwraca wynik
        /// wywo�ania lub null.
        /// </summary>
        /// <param name="reader">Obiekt czytaj�cy z bazy</param>
        object BorrowReader(IDataReader reader);
    }
}