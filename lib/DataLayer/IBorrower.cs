using System.Data;
namespace DataLayer 
{
    /// <summary>
    /// Definicja interfejsu pozwalaj¹cego klientom po¿yczaæ obiekt czytaj¹cy
    /// z bazy bez troszczenia siê o koniecznoœæ jego zwolnienia.
    /// </summary>
    public interface IBorrower
    {
        /// <summary>
        /// Korzysta z dostarczonego obiektu czytaj¹cego, wiedz¹c ¿e 
        /// obiekt wywo³uj¹cy zwolni obiekt po wywo³aniu. Zwraca wynik
        /// wywo³ania lub null.
        /// </summary>
        /// <param name="reader">Obiekt czytaj¹cy z bazy</param>
        object BorrowReader(IDataReader reader);
    }
}